using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Microsoft.ProjectOxford.Emotion;
using System.Threading.Tasks;

namespace App5.Class
{
   public class ServiceEmotions
    {
        static string key = "65b532e4e8e34e518750ef7212ce626d";
        
        public static async Task<Dictionary<string, float>> GetEmotions(Stream stream)
        {
            EmotionServiceClient cliente = new EmotionServiceClient(key);
            var emociones = await cliente.RecognizeAsync(stream);

            if (emociones == null || emociones.Count() == 0)
                return null;

            return emociones[0].Scores.ToRankedList().ToDictionary(x => x.Key, x => x.Value);
        }

    }
}