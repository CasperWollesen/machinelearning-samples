﻿// This file was auto-generated by ML.NET Model Builder.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.LightGbm;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace HeartDiseaseDetection
{
    public partial class MLModel1
    {
        public const string RetrainFilePath =  @"C:\Users\Caspe\Desktop\TORM Maren ML\Scrubber Data v1 - Simplified.csv";
        public const char RetrainSeparatorChar = ';';
        public const bool RetrainHasHeader =  true;

         /// <summary>
        /// Train a new model with the provided dataset.
        /// </summary>
        /// <param name="outputModelPath">File path for saving the model. Should be similar to "C:\YourPath\ModelName.mlnet"</param>
        /// <param name="inputDataFilePath">Path to the data file for training.</param>
        /// <param name="separatorChar">Separator character for delimited training file.</param>
        /// <param name="hasHeader">Boolean if training file has a header.</param>
        public static void Train(string outputModelPath, string inputDataFilePath = RetrainFilePath, char separatorChar = RetrainSeparatorChar, bool hasHeader = RetrainHasHeader)
        {
            var mlContext = new MLContext();

            var data = LoadIDataViewFromFile(mlContext, inputDataFilePath, separatorChar, hasHeader);
            var model = RetrainModel(mlContext, data);
            SaveModel(mlContext, model, data, outputModelPath);
        }

        /// <summary>
        /// Load an IDataView from a file path.
        /// </summary>
        /// <param name="mlContext">The common context for all ML.NET operations.</param>
        /// <param name="inputDataFilePath">Path to the data file for training.</param>
        /// <param name="separatorChar">Separator character for delimited training file.</param>
        /// <param name="hasHeader">Boolean if training file has a header.</param>
        /// <returns>IDataView with loaded training data.</returns>
        public static IDataView LoadIDataViewFromFile(MLContext mlContext, string inputDataFilePath, char separatorChar, bool hasHeader)
        {
            return mlContext.Data.LoadFromTextFile<ModelInput>(inputDataFilePath, separatorChar, hasHeader);
        }



        /// <summary>
        /// Save a model at the specified path.
        /// </summary>
        /// <param name="mlContext">The common context for all ML.NET operations.</param>
        /// <param name="model">Model to save.</param>
        /// <param name="data">IDataView used to train the model.</param>
        /// <param name="modelSavePath">File path for saving the model. Should be similar to "C:\YourPath\ModelName.mlnet.</param>
        public static void SaveModel(MLContext mlContext, ITransformer model, IDataView data, string modelSavePath)
        {
            // Pull the data schema from the IDataView used for training the model
            DataViewSchema dataViewSchema = data.Schema;

            using (var fs = File.Create(modelSavePath))
            {
                mlContext.Model.Save(model, dataViewSchema, fs);
            }
        }


        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainModel(MLContext mlContext, IDataView trainData)
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
            var pipeline = mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"Aux1FuelIndexAIi_input", @"Aux1FuelIndexAIi_input"),new InputOutputColumnPair(@"Aux2FuelIndexAIi_input", @"Aux2FuelIndexAIi_input"),new InputOutputColumnPair(@"Aux3FuelIndexAIi_input", @"Aux3FuelIndexAIi_input"),new InputOutputColumnPair(@"MEFuelIndexAIi_input", @"MEFuelIndexAIi_input"),new InputOutputColumnPair(@"BoilerAux1lFuelIndexAIi_input", @"BoilerAux1lFuelIndexAIi_input"),new InputOutputColumnPair(@"SB9_2EGPT1AIi", @"SB9_2EGPT1AIi"),new InputOutputColumnPair(@"SB9_2EGPT2AIi", @"SB9_2EGPT2AIi"),new InputOutputColumnPair(@"SB9_2EGPT3AIi", @"SB9_2EGPT3AIi"),new InputOutputColumnPair(@"SB9_2EGPT4AIi", @"SB9_2EGPT4AIi"),new InputOutputColumnPair(@"SB9_2EGPT5AIi", @"SB9_2EGPT5AIi"),new InputOutputColumnPair(@"NETWAOutletTT31AIi", @"NETWAOutletTT31AIi"),new InputOutputColumnPair(@"SB3_1PT2_1AIi", @"SB3_1PT2_1AIi"),new InputOutputColumnPair(@"SB3_1FT2_1AIi", @"SB3_1FT2_1AIi"),new InputOutputColumnPair(@"SB3_1LT5_1AIi", @"SB3_1LT5_1AIi"),new InputOutputColumnPair(@"SB3_1LT6_1AIi", @"SB3_1LT6_1AIi"),new InputOutputColumnPair(@"SB3_1PDT1_1AIi", @"SB3_1PDT1_1AIi"),new InputOutputColumnPair(@"SB3_1TT5_1AIi", @"SB3_1TT5_1AIi"),new InputOutputColumnPair(@"SB3_1TT6_1AIi", @"SB3_1TT6_1AIi"),new InputOutputColumnPair(@"SB3_1TT7_1AIi", @"SB3_1TT7_1AIi"),new InputOutputColumnPair(@"PF2_1a_FrqCurrRaw", @"PF2_1a_FrqCurrRaw"),new InputOutputColumnPair(@"PF2_1a_Eprw", @"PF2_1a_Eprw"),new InputOutputColumnPair(@"PF2_1a_Spd", @"PF2_1a_Spd"),new InputOutputColumnPair(@"PF2_1b_FrqCurrRaw", @"PF2_1b_FrqCurrRaw"),new InputOutputColumnPair(@"PF2_1b_Eprw", @"PF2_1b_Eprw"),new InputOutputColumnPair(@"PF2_1b_Spd", @"PF2_1b_Spd"),new InputOutputColumnPair(@"NETEGARatioAIi", @"NETEGARatioAIi"),new InputOutputColumnPair(@"NETWAOutletPAHT31AIi", @"NETWAOutletPAHT31AIi"),new InputOutputColumnPair(@"Scrub_EGACO2Coni", @"Scrub_EGACO2Coni"),new InputOutputColumnPair(@"Scrub_EGASO2Coni", @"Scrub_EGASO2Coni"),new InputOutputColumnPair(@"NETWAInletTUET30AIi", @"NETWAInletTUET30AIi"),new InputOutputColumnPair(@"NETWAInletpHT30AIi", @"NETWAInletpHT30AIi")})      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"Timestamp (GPS - UTC)",outputColumnName:@"Timestamp (GPS - UTC)"))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"Aux1FuelIndexAIi_input",@"Aux2FuelIndexAIi_input",@"Aux3FuelIndexAIi_input",@"MEFuelIndexAIi_input",@"BoilerAux1lFuelIndexAIi_input",@"SB9_2EGPT1AIi",@"SB9_2EGPT2AIi",@"SB9_2EGPT3AIi",@"SB9_2EGPT4AIi",@"SB9_2EGPT5AIi",@"NETWAOutletTT31AIi",@"SB3_1PT2_1AIi",@"SB3_1FT2_1AIi",@"SB3_1LT5_1AIi",@"SB3_1LT6_1AIi",@"SB3_1PDT1_1AIi",@"SB3_1TT5_1AIi",@"SB3_1TT6_1AIi",@"SB3_1TT7_1AIi",@"PF2_1a_FrqCurrRaw",@"PF2_1a_Eprw",@"PF2_1a_Spd",@"PF2_1b_FrqCurrRaw",@"PF2_1b_Eprw",@"PF2_1b_Spd",@"NETEGARatioAIi",@"NETWAOutletPAHT31AIi",@"Scrub_EGACO2Coni",@"Scrub_EGASO2Coni",@"NETWAInletTUET30AIi",@"NETWAInletpHT30AIi",@"Timestamp (GPS - UTC)"}))      
                                    .Append(mlContext.Regression.Trainers.LightGbm(new LightGbmRegressionTrainer.Options(){NumberOfLeaves=4,NumberOfIterations=4,MinimumExampleCountPerLeaf=20,LearningRate=1,LabelColumnName=@"NETWAOutletpHT31AIi",FeatureColumnName=@"Features",ExampleWeightColumnName=null,Booster=new GradientBooster.Options(){SubsampleFraction=1,FeatureFraction=1,L1Regularization=2E-10,L2Regularization=1},MaximumBinCountPerFeature=254}));

            return pipeline;
        }
    }
 }
