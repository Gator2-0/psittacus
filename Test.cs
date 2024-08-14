using Microsoft.ML;
using psittacus.Services;
using System;
using psittacus.Models;

/*class Test
{
    static void Main(string[] args)
    {
        var mlContext = new MLContext();

        // Load the trained model
        ITransformer model = mlContext.Model.Load("path/to/your/model.zip", out var modelInputSchema);

        // Create a prediction engine
        var predictionEngine = mlContext.Model.CreatePredictionEngine<UserQuery, QueryPrediction>(model);

        // Sample data to test
        var sampleQuery = new UserQuery
        {
            Text = "What are the diving conditions like?"
        };

        // Make a prediction
        var prediction = predictionEngine.Predict(sampleQuery);

        Console.WriteLine($"Predicted Label: {prediction.PredictedLabel}");
    }
}
*/
