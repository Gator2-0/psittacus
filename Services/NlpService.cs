using Microsoft.ML;
using Microsoft.ML.Data;
using psittacus.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace psittacus.Services
{
    public class NlpService
    {
        private readonly PredictionEngine<UserQuery, QueryPrediction> _predictionEngine;
        private readonly HttpClient _httpClient;

        public NlpService(PredictionEngine<UserQuery, QueryPrediction> predictionEngine, HttpClient httpClient)
        {
            _predictionEngine = predictionEngine;
            _httpClient = httpClient;
        }

        public async Task<NlpResponse> ProcessQuery(string input)
        {
            var prediction = _predictionEngine.Predict(new UserQuery { Text = input });
            string label = prediction.PredictedLabel;
            label = label.Trim('\"');  // Removes surrounding quotes
            Console.WriteLine("Label: " + label);
            object result = null;

            switch (label) 
            {
                case "DivingConditionsQuery":
                    result = await FetchDivingConditions();
                    
                    break;

                case "WeatherForecastQuery":
     
                    result = "Unknown";
                    break;

                case "unknownQuery":
                    Console.WriteLine("Query not recognized. Please rephrase your question.");
                    // Provide feedback or guide the user
                    result = "unknown";
                    break;

                default:
                    Console.WriteLine("Unknown query type.");
                    result = "unknown";
                    break;
            }
            return new NlpResponse { Label = label, Data = result };
        }

        private async Task<List<WeatherCondition>> FetchDivingConditions()
        {
            // Call your API or perform actions to get diving conditions
            Console.WriteLine("Fetching diving conditions...");
            string apiUrl = "https://localhost:7116/DivingControllers/divingForecast";
            try 
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                Console.WriteLine("FetchDivingConditions(), response: " + response.Content);

                /*List <WeatherCondition> weatherConditions = await response.Content.ReadFromJsonAsync<List<WeatherCondition>>(); ;

                Console.WriteLine("FetchWeatherConditions(), response:");
                foreach (var condition in weatherConditions)
                {
                    Console.WriteLine($"{condition.Date.ToShortDateString()}: {condition.Condition} at {condition.Temperature}°C");
                }*/

                List <WeatherCondition> weatherConditions = await response.Content.ReadFromJsonAsync<List<WeatherCondition>>();
                Console.WriteLine(weatherConditions);

                return weatherConditions;
            }
            catch(HttpRequestException e) 
            {
                Console.WriteLine("Request error:");
                Console.WriteLine(e.Message);
                return new List<WeatherCondition>() ; // Return an empty list on error
            }
            
        }

        private void FetchWeatherForecast()
        {
            // Call your API or perform actions to get the weather forecast
            Console.WriteLine("Fetching weather forecast...");
        }
    }

}

