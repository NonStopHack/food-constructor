using System;
using System.Collections.Generic;

namespace FoodConstructor.Models
{
    public interface IDish
    {
        string Title { get; set; }
        string Description { get; set; }
        IList<IComponent> Components { get; set; }
    }
}
