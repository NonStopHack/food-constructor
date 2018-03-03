using System;
using System.Collections.Generic;

namespace FoodConstructor.Models
{
    public interface ICompany
    {
        Guid Id { get; }
        string Title { get; }
        IList<Guid> IssuePointsIds { get; set; }
    }
}
