using System.Collections.Generic;

namespace FoodConstructor.Models
{
    public class Dish : IDish
    {
        private IList<IComponent> _components;
        public IList<IComponent> Components
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
    }
}