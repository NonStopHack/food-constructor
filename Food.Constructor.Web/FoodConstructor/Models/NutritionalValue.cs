using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodConstructor.Models
{
    public class NutritionalValue
    {
        public NutritionalValue(int seed = 0)
        {
            Random rnd = new Random(seed);
            Proteins = rnd.Next(1, 100);
            Fats = rnd.Next(1, 100);
            Carbohydrates = rnd.Next(1, 100);
            CaloricValue = rnd.Next(1, 100);
        }

        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double CaloricValue { get; set; }
}
}