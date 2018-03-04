using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace FoodConstructor.Models
{
    public interface IDish
    {
        [BsonId]
        Guid Id { get; }
        string Title { get; set; }
        string Description { get; set; }
        IList<Component> Components { get; set; }
    }
}
