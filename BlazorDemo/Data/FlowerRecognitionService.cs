using System;
using System.IO;
using System.Threading.Tasks;
using BlazorDemo.MLModels;
using Microsoft.Extensions.ML;

namespace BlazorDemo.Data
{
    public class FlowerRecognitionService
    {
        private readonly PredictionEnginePool<FlowerRecognitionInput, FlowerRecognitionOutput> _predictionEnginePool;

        public FlowerRecognitionService(PredictionEnginePool<FlowerRecognitionInput, FlowerRecognitionOutput> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        public FlowerRecognitionOutput GetFlowerName(string imageUrl)
        {
            FlowerRecognitionInput sampleData = new FlowerRecognitionInput()
            {
                ImageSource = imageUrl
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = _predictionEnginePool.Predict(sampleData);

            return predictionResult;
        }
    }
}
