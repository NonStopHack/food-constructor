using System;
using System.Collections.Generic;

namespace FoodConstructor.Models
{
    public class Company : ICompany
    {
        public Company(string title)
        {
            _id = Guid.NewGuid();
            _title = title;
            _issuePointsIds = new List<Guid>();
        }

        private Guid _id;
        public Guid Id
        {
            get
            {
                return _id;
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
        }

        private IList<Guid> _issuePointsIds;
        public IList<Guid> IssuePointsIds
        {
            get
            {
                return _issuePointsIds;
            }

            set
            {
                _issuePointsIds = value;
            }
        }

        public static Company CreateTestCompany(string title)
        {
            var testCompany = new Company(title);
            return testCompany;
        }
    }
}