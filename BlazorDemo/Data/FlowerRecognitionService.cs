using System;
using System.IO;
using System.Threading.Tasks;
using BlazorDemoML.Model;

namespace BlazorDemo.Data
{
    public class FlowerRecognitionService
    {
        public ModelOutput GetFlowerName(string imageUrl)
        {
            ModelInput sampleData = new ModelInput()
            {
                ImageSource = imageUrl
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);

            return predictionResult;
        }
    }
}
