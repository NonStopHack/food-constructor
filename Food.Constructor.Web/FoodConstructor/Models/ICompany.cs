using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace FoodConstructor.Models
{
    public interface ICompany
    {
        [BsonId]
        Guid Id { get; set; }
        string Title { get; set; }
        IList<Guid> IssuePointsIds { get; set; }
    }
}
