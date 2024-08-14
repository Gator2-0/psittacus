using Microsoft.ML;
using psittacus.Models;

namespace psittacus.Services
{
    public class ModelTrainer
    {
        public static ITransformer TrainModel(MLContext mlContext, string dataPath)
        {
            // Load data from the CSV file
            var dataView = mlContext.Data.LoadFromTextFile<UserQuery>(dataPath, hasHeader: true);

            // Define a pipeline for training
            var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", nameof(UserQuery.Text))
                .Append(mlContext.Transforms.Conversion.MapValueToKey("Label"))
                .Append(mlContext.Transforms.NormalizeMinMax("Features"))
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy())
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            // Train the model
            var model = pipeline.Fit(dataView);

            return model;
        } 
    }
}
