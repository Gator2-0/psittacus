using Microsoft.ML;
using Microsoft.ML.Data;
using psittacus.Models;

namespace psittacus.Services
{
    public class NlpService
    {
        private readonly PredictionEngine<UserQuery, QueryPrediction> _predictionEngine;

        public NlpService(PredictionEngine<UserQuery, QueryPrediction> predictionEngine)
        {
            _predictionEngine = predictionEngine;
        }

        public string ProcessQuery(string input)
        {
            var prediction = _predictionEngine.Predict(new UserQuery { Text = input });
            string label = prediction.PredictedLabel;

            string result = string.Empty;

            switch (label) 
            {
                case "DivingConditionsQuery":
                    FetchDivingConditions();
                    result = "diving";
                    break;

                case "WeatherForecastQuery":
                    FetchWeatherForecast();
                    result = "weather";
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
            return result;
        }

        private void FetchDivingConditions()
        {
            // Call your API or perform actions to get diving conditions
            Console.WriteLine("Fetching diving conditions...");
        }

        private void FetchWeatherForecast()
        {
            // Call your API or perform actions to get the weather forecast
            Console.WriteLine("Fetching weather forecast...");
        }
    }

}

