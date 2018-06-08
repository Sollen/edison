using System;
using System.Collections.Generic;
using System.Threading;

namespace Edison.Models
{
    public class Psychic
    {
        public Psychic(int id, string name)
        {
            Id = id;
            Name = name;
            Confidence = 0;
            Prediction = new List<int>();
        }

        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Confidence { get; set; }
        public List<int> Prediction { get; set; }

        public int GetPrediction()
        {
            Thread.Sleep(1);
            Random rnd = new Random(DateTime.Now.Millisecond);
            int prediction = rnd.Next(10, 99);
            Prediction.Add(prediction);
            return prediction;
        }
    }


}