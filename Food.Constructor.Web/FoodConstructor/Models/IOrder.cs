using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace FoodConstructor.Models
{
    public enum OrderState
    {
        None,
        Waiting,
        InProgress,
        Done,
        Error
    }

    public interface IOrder
    {
        [BsonId]
        Guid Id { get; }
        Guid CompanyId { get; set; }
        Guid IssuePointId { get; set; }
        Guid CustomerId { get; set; }
        OrderState State { get; set; }
        IList<KeyValuePair<OrderState, DateTime>> History { get; }
        KeyValuePair<OrderState, DateTime> GetLastState { get; }
    }
}
