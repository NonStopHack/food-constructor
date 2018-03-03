using System;
using System.Collections.Generic;

namespace FoodConstructor.Models
{
    public interface IIssuePoint
    {
        Guid Id { get; }
        string Title { get; set; }
        string Address { get; set; }
        KeyValuePair<double, double> Geoposition { get; set; }
        IList<IComponent> AvailableComponents { get; set; }
    }
}
