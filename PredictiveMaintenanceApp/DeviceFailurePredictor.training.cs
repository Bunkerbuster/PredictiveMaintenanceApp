﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using Microsoft.ML;

namespace PredictiveMaintenanceApp
{
    public partial class DeviceFailurePredictor
    {
        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process. For more information on how to load data, see aka.ms/loaddata.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainPipeline(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(@"Type", @"Type", outputKind: OneHotEncodingEstimator.OutputKind.Indicator)      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"Air temperature [K]", @"Air temperature [K]"),new InputOutputColumnPair(@"Process temperature [K]", @"Process temperature [K]"),new InputOutputColumnPair(@"Rotational speed [rpm]", @"Rotational speed [rpm]"),new InputOutputColumnPair(@"Torque [Nm]", @"Torque [Nm]"),new InputOutputColumnPair(@"Tool wear [min]", @"Tool wear [min]")}))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"Product ID",outputColumnName:@"Product ID"))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"Type",@"Air temperature [K]",@"Process temperature [K]",@"Rotational speed [rpm]",@"Torque [Nm]",@"Tool wear [min]",@"Product ID"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName:@"Machine failure",inputColumnName:@"Machine failure"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.OneVersusAll(binaryEstimator:mlContext.BinaryClassification.Trainers.FastTree(new FastTreeBinaryTrainer.Options(){NumberOfLeaves=82,MinimumExampleCountPerLeaf=2,NumberOfTrees=5,MaximumBinCountPerFeature=323,FeatureFraction=0.99999999,LearningRate=0.999999776672986,LabelColumnName=@"Machine failure",FeatureColumnName=@"Features"}),labelColumnName: @"Machine failure"))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName:@"PredictedLabel",inputColumnName:@"PredictedLabel"));

            return pipeline;
        }
    }
}
