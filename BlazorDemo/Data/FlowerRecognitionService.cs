using System;
using System.IO;
using System.Threading.Tasks;
using BlazorDemoML.Model;

namespace BlazorDemo.Data
{
    public class FlowerRecognitionService
    {
        public async Task<ModelOutput> GetFlowerNameAsync(byte[] image)
        {
            // create the filename
            string fileName = Guid.NewGuid().ToString() + ".jpg";

            // the full file path
            var filePath = Path.Combine($"./temp/images/{fileName}");

            // write bytes and auto-close stream
            await File.WriteAllBytesAsync(filePath, image);


            ModelInput sampleData = new ModelInput()
            {
                ImageSource = filePath
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);

            File.Delete(filePath);

            return predictionResult;
        }
    }
}
