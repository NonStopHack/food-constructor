using System;

namespace FoodConstructor.Models
{
    public enum Measurement
    {
        slice,
        gr,
        kg,
        items,
        liters
    }

    public interface IComponent
    {
        Guid Id { get; set; }
        string Title { get; set; }
        Measurement Measurement { get; set; }
        double Quantity { get; set; }
    }
}
