using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading;
using System.Web;

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

        private Random _rand;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Confidence { get; set; }
        public List<int> Prediction { get; set; }

        public void GetPrediction(int number)
        {
            Thread.Sleep(1);
            Random rnd = new Random(DateTime.Now.Millisecond);
            int prediction = rnd.Next(10, 99);
            Confidence = number == prediction ? ++Confidence: --Confidence;
            Prediction.Add(prediction);
        }
    }


}