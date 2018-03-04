using System;
using System.Collections.Generic;

namespace FoodConstructor.Models
{
    public class Order : IOrder
    {
        public Order()
        {
            _id = Guid.NewGuid();
            _history = new List<KeyValuePair<OrderState, DateTime>>();
            _history.Add(new KeyValuePair<OrderState, DateTime>(OrderState.Waiting, DateTime.Now));
            _dishes = new List<Dish>();
        }

        public Order(Guid companyId, Guid issuePointId, Guid customerId, Guid contractorId, IList<IDish> dishes)
        {
            _id = Guid.NewGuid();
            _companyId = companyId;
            _dishes = new List<Dish>(); 
            _issuePointId = issuePointId;
            _history = new List<KeyValuePair<OrderState, DateTime>>();
            _history.Add(new KeyValuePair<OrderState, DateTime>(OrderState.Waiting, DateTime.Now));
        }

        private Guid _id;
        public Guid Id
        {
            get
            {
                return _id;
            }
        }

        private Guid _companyId;
        public Guid CompanyId
        {
            get
            {
                return _companyId;
            }

            set
            {
                _companyId = value;
            }
        }

        private Guid _issuePointId;
        public Guid IssuePointId
        {
            get
            {
                return _issuePointId;
            }

            set
            {
                _issuePointId = value;
            }
        }

        private Guid _customerId;
        public Guid CustomerId
        {
            get
            {
                return _customerId;
            }

            set
            {
                _customerId = value;
            }
        }

        private IList<Dish> _dishes;
        public IList<Dish> Dishes
        {
            get
            {
                return _dishes;
            }

            set
            {
                _dishes = value;
            }
        }

        private OrderState _state;
        public OrderState State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }

        private List<KeyValuePair<OrderState, DateTime>> _history;
        public IList<KeyValuePair<OrderState, DateTime>> History
        {
            get
            {
                return _history;
            }
        }

        public KeyValuePair<OrderState, DateTime> GetLastState
        {
            get
            {
                KeyValuePair<OrderState, DateTime> lastState = new KeyValuePair<OrderState, DateTime>(OrderState.None, DateTime.MinValue);
                if (_history != null && _history.Count > 0)
                {
                    lastState = _history[_history.Count - 1];
                }
                return lastState;
            }
        }
    }
}