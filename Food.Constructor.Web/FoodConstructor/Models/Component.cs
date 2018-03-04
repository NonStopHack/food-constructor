using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodConstructor.Models
{
    public class Component : IComponent
    {
        private static List<Component> testComponents;
        static Component()
        {
            #region test data initialization
            testComponents = new List<Component>
            {
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Salt",
                    Quantity = 5,
                    Categories = new List<string>() { "test" },
                    NutritionalValue = new NutritionalValue(73)
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Sugar",
                    Quantity = 7,
                    Categories = new List<string>() { "test" },
                    NutritionalValue = new NutritionalValue(68)
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Potatoes",
                    Quantity = 50,
                    Categories = new List<string>() { "vegetables" },
                    NutritionalValue = new NutritionalValue(35)
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Cucumber",
                    Quantity = 12,
                    Categories = new List<string>() { "vegetables" },
                    NutritionalValue = new NutritionalValue(25)
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Tomatoes",
                    Quantity = 6,
                    Categories = new List<string>() { "vegetables" },
                    NutritionalValue = new NutritionalValue(38)
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.gr,
                    Title = "Pepper",
                    Quantity = 700,
                    Categories = new List<string>() { "vegetables" },
                    NutritionalValue = new NutritionalValue(83)
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Chiken",
                    Quantity = 15,
                    Categories = new List<string>() { "meat" },
                    NutritionalValue = new NutritionalValue(51)
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Chiken",
                    Quantity = 15,
                    Categories = new List<string>() { "meat" },
                    NutritionalValue = new NutritionalValue(27)
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.liters,
                    Title = "Water",
                    Quantity = 105,
                    Categories = new List<string>() { "test" },
                    NutritionalValue = new NutritionalValue(98)
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Onien",
                    Quantity = 25,
                    Categories = new List<string>() { "vegetables" },
                    NutritionalValue = new NutritionalValue(34)
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Butter",
                    Quantity = 3,
                    Categories = new List<string>() { "test" },
                    NutritionalValue = new NutritionalValue(435)
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.liters,
                    Title = "Oil",
                    Quantity = 3,
                    Categories = new List<string>() { "test" },
                    NutritionalValue = new NutritionalValue(664)
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Eggs",
                    Quantity = 105,
                    Categories = new List<string>() { "test" },
                    NutritionalValue = new NutritionalValue(34)
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.liters,
                    Title = "Milk",
                    Quantity = 5,
                    Categories = new List<string>() { "test" },
                    NutritionalValue = new NutritionalValue(12)
                }
            };
            #endregion
        }

        public Component(string title = "")
        {
            _title = title;
            NutritionalValue = new NutritionalValue();
        }

        public Guid Id { get; set; }

        private Measurement _measurement;
        public Measurement Measurement
        {
           
            get
            {
                return _measurement;
            }

            set
            {
                _measurement = value;
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public double Quantity { get; set; }

        private IList<string> _categories;
        public IList<string> Categories
        {
            get
            {
                return _categories;
            }

            set
            {
                _categories = value;
            }
        }
        public NutritionalValue NutritionalValue { get; set; }

        private string _imageBase64;
        public string ImageBase64
        {
            get
            {
                return _imageBase64;
            }

            set
            {
                _imageBase64 = value;
            }
        }

        public static List<IComponent> CreateTestComponents(int componentsCount)
        {
            if(testComponents.Count - 1 < componentsCount)
            {
                componentsCount = testComponents.Count - 1;
            }

            Random rnd = new Random();
            Dictionary<Guid, IComponent> selectedComponents = new Dictionary<Guid, IComponent>();
            while(selectedComponents.Count() < componentsCount)
            {
                int index = rnd.Next(0, testComponents.Count - 1);
                if (!selectedComponents.ContainsKey(testComponents[index].Id))
                {
                    selectedComponents.Add(testComponents[index].Id, testComponents[index]);
                }
            }

            return selectedComponents.Values.ToList();
        }
    }
}