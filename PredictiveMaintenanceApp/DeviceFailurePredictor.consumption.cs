﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace PredictiveMaintenanceApp
{
    public partial class DeviceFailurePredictor
    {
        /// <summary>
        /// model input class for DeviceFailurePredictor.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"UDI")]
            public float UDI { get; set; }

            [ColumnName(@"Product ID")]
            public string Product_ID { get; set; }

            [ColumnName(@"Type")]
            public string Type { get; set; }

            [ColumnName(@"Air temperature [K]")]
            public float Air_temperature__K_ { get; set; }

            [ColumnName(@"Process temperature [K]")]
            public float Process_temperature__K_ { get; set; }

            [ColumnName(@"Rotational speed [rpm]")]
            public float Rotational_speed__rpm_ { get; set; }

            [ColumnName(@"Torque [Nm]")]
            public float Torque__Nm_ { get; set; }

            [ColumnName(@"Tool wear [min]")]
            public float Tool_wear__min_ { get; set; }

            [ColumnName(@"Machine failure")]
            public float Machine_failure { get; set; }

            [ColumnName(@"TWF")]
            public float TWF { get; set; }

            [ColumnName(@"HDF")]
            public float HDF { get; set; }

            [ColumnName(@"PWF")]
            public float PWF { get; set; }

            [ColumnName(@"OSF")]
            public float OSF { get; set; }

            [ColumnName(@"RNF")]
            public float RNF { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for DeviceFailurePredictor.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"UDI")]
            public float UDI { get; set; }

            [ColumnName(@"Product ID")]
            public float[] Product_ID { get; set; }

            [ColumnName(@"Type")]
            public float[] Type { get; set; }

            [ColumnName(@"Air temperature [K]")]
            public float Air_temperature__K_ { get; set; }

            [ColumnName(@"Process temperature [K]")]
            public float Process_temperature__K_ { get; set; }

            [ColumnName(@"Rotational speed [rpm]")]
            public float Rotational_speed__rpm_ { get; set; }

            [ColumnName(@"Torque [Nm]")]
            public float Torque__Nm_ { get; set; }

            [ColumnName(@"Tool wear [min]")]
            public float Tool_wear__min_ { get; set; }

            [ColumnName(@"Machine failure")]
            public uint Machine_failure { get; set; }

            [ColumnName(@"TWF")]
            public float TWF { get; set; }

            [ColumnName(@"HDF")]
            public float HDF { get; set; }

            [ColumnName(@"PWF")]
            public float PWF { get; set; }

            [ColumnName(@"OSF")]
            public float OSF { get; set; }

            [ColumnName(@"RNF")]
            public float RNF { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"PredictedLabel")]
            public float PredictedLabel { get; set; }

            [ColumnName(@"Score")]
            public float[] Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("DeviceFailurePredictor.zip");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}