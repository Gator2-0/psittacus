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
            var result = _predictionEngine.Predict(new UserQuery { Text = input });
            return result.PredictedLabel;
        }
    }
}
