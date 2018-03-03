using System;
using System.Collections.Generic;

namespace FoodConstructor.Models
{
    public class IssuePoint : IIssuePoint
    {
        public IssuePoint(string title, string address)
        {
            _id = Guid.NewGuid();
            _title = title;
            _address = address;
            _availableComponents = new List<IComponent>();
        }

        private Guid _id;
        public Guid Id
        {
            get
            {
                return _id;
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

        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
            }
        }

        private KeyValuePair<double, double> _geoposition;
        public KeyValuePair<double, double> Geoposition
        {
            get
            {
                return _geoposition;
            }

            set
            {
                _geoposition = value;
            }
        }

        private IList<IComponent> _availableComponents;
        public IList<IComponent> AvailableComponents
        {
           get
            {
                return _availableComponents;
            }

            set
            {
                _availableComponents = value;
            }
        }

        public static IssuePoint CreateTestIssuePoint(string title)
        {
            var issuePoint = new IssuePoint(title, "Saint-Petersburg, random avenue");
            Random rnd = new Random();
            int componentsCount = rnd.Next(10, 15);
            issuePoint._availableComponents = Component.CreateTestComponents(componentsCount);
            return issuePoint; 
        }
    }
}