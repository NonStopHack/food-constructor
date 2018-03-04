using System;
using System.Collections.Generic;

namespace FoodConstructor.Models
{
    public class Dish : IDish
    {
        Dish()
        {
            _title = "Default title";
            _description = "Default description";
            _components = new List<Component>();
            _id = Guid.NewGuid();
        }

        Dish(string title)
        {
            _title = title;
            _id = Guid.NewGuid();
        }

        private IList<Component> _components;
        public IList<Component> Components
        {
            get
            {
                return _components;
            }

            set
            {
                _components = value;
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
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

        private Guid _id;
        public Guid Id
        {
            get
            {
                return _id;
            }
        }
    }
}