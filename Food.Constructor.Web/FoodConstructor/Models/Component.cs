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
            testComponents = new List<Component>
            {
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Salt",
                    Quantity = 5
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Sugar",
                    Quantity = 7
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Potatoes",
                    Quantity = 50
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Cucumber",
                    Quantity = 12
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Tomatoes",
                    Quantity = 6
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.gr,
                    Title = "Pepper",
                    Quantity = 700
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Chiken",
                    Quantity = 15
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Chiken",
                    Quantity = 15
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.liters,
                    Title = "Water",
                    Quantity = 105
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Onien",
                    Quantity = 25
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Butter",
                    Quantity = 3
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.liters,
                    Title = "Oil",
                    Quantity = 3
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.kg,
                    Title = "Eggs",
                    Quantity = 105
                },
                new Component()
                {
                    Id = Guid.NewGuid(),
                    Measurement = Measurement.liters,
                    Title = "Milk",
                    Quantity = 5
                }
            };
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