using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

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
        [BsonId]
        Guid Id { get; set; }
        string Title { get; set; }
        Measurement Measurement { get; set; }
        double Quantity { get; set; }
        IList<string> Categories { get; set; }
        NutritionalValue NutritionalValue { get; set; }
        string ImageBase64 { get; set; }
    }
}
