using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDemo.MLModels;
using Microsoft.Extensions.ML;

namespace BlazorDemo.Data
{
    public class SentimentAnalysisService
    {
        private readonly PredictionEnginePool<SentimentAnalysisInput, SentimentAnalysisOutput> _predictionEnginePool;

        public SentimentAnalysisService(PredictionEnginePool<SentimentAnalysisInput, SentimentAnalysisOutput> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        public float GetSentimentPrediction(string sentimentText)
        {
            var sampleData = new SentimentAnalysisInput
            {
                Text = sentimentText
            };

            var prediction = _predictionEnginePool.Predict(sampleData);

            return CalculatePercentage(prediction.Score);
        }

        private float CalculatePercentage(double value)
        {
            return 100 * (1.0f / (1.0f + (float)Math.Exp(-value)));
        }
    }
}
