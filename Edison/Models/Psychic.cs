using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;

namespace Edison.Models
{
    public class Psychic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Confidence { get; set; }
        public List<int> Prediction { get; set; }

        public void GetPrediction(int number)
        {
            Random rnd = new Random();
            int prediction = rnd.Next(10, 99);
            Confidence = number == prediction ? Confidence++: Confidence--;
            Prediction.Add(prediction);
        }
    }


}