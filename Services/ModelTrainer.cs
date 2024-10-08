﻿using Microsoft.ML;
using psittacus.Models;
using System;

namespace psittacus.Services
{
    public class ModelTrainer
    {
        public static ITransformer TrainModel(MLContext mlContext, string dataPath)
        {
            // Load data from the CSV file
            IDataView dataView = mlContext.Data.LoadFromTextFile<UserQuery>(
                path: dataPath,
                hasHeader: true,
                separatorChar: ',');

            var dataPreview = dataView.Preview(); // Preview data to debug
            Console.WriteLine("Data preview:");
            foreach (var row in dataPreview.RowView)
            {
                Console.WriteLine(string.Join(", ", row.Values.Select(v => v.Value)));
            }

            // Define a pipeline for training
            var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", nameof(UserQuery.Text))
                .Append(mlContext.Transforms.Conversion.MapValueToKey("Label"))
                .Append(mlContext.Transforms.NormalizeMinMax("Features"))
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy())
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            // Train the model
            var model = pipeline.Fit(dataView);
            Console.WriteLine(model.ToString());
            return model;
        } 
    }
}
