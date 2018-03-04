using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodConstructor.Models.Repository
{
    public class Repository : IRepository
    {
        // companies
        public IList<Company> GetCompanies(IList<Guid> companiesIds = null)
        {
            var client = MongoBDClient.GetClient();
            var db = client.GetDatabase("FoodHackDB");
            var companies = db.GetCollection<Company>("Companies");
            IList<Company> foundCompanies;
            if (companiesIds != null)
            {
                foundCompanies = companies.Find(x => companiesIds.Contains(x.Id)).ToList();
            }
            else
            {
                foundCompanies = companies.Find(x => true).ToList();
            }

            return foundCompanies;
        }
        public Guid CreateOrUpdateCompany(Company company)
        {
            var client = MongoBDClient.GetClient();
            var db = client.GetDatabase("FoodHackDB");
            var companies = db.GetCollection<Company>("Companies");
            var foundCompanies = companies.Find(x => x.Id == company.Id).ToList();

            if (foundCompanies.Any())
            {
                var filter = Builders<Company>.Filter.Eq(s => s.Id, company.Id);
                companies.ReplaceOne(filter, company);
            }
            else
            {
                companies.InsertOne(company);
            }

            return company.Id;
        }
        public void DeleteCompany(Guid companyId)
        {
            var client = MongoBDClient.GetClient();
            var db = client.GetDatabase("FoodHackDB");
            var companies = db.GetCollection<Company>("Companies");
            var result = companies.DeleteOne(x => x.Id == companyId);
        }
        public void DeleteAllCompanies()
        {
            var client = MongoBDClient.GetClient();
            var db = client.GetDatabase("FoodHackDB");
            var companies = db.GetCollection<Company>("Companies");
            var result = companies.DeleteMany(x => true);
        }

        // issue points
        public IList<IssuePoint> GetCompanyIssuePoint(IList<Guid> issuePointsIds = null)
        {
            var client = MongoBDClient.GetClient();
            var db = client.GetDatabase("FoodHackDB");
            var issuePoints = db.GetCollection<IssuePoint>("IssuePoints");
            List<IssuePoint> foundIssuePoints;
            if (issuePointsIds != null)
            {
                foundIssuePoints = issuePoints.Find(x => issuePointsIds.Contains(x.Id)).ToList();
            }
            else
            {
                foundIssuePoints = issuePoints.Find(x => true).ToList();
            }

            return foundIssuePoints;
        }
        public Guid CreateOrUpdateIssuePoint(IssuePoint issuePointId)
        {
            var client = MongoBDClient.GetClient();
            var db = client.GetDatabase("FoodHackDB");
            var issuePoints = db.GetCollection<IssuePoint>("IssuePoints");
            var foundIssuePoints = issuePoints.Find(x => x.Id == issuePointId.Id).ToList();

            if (foundIssuePoints.Any())
            {
                var filter = Builders<IssuePoint>.Filter.Eq(s => s.Id, issuePointId.Id);
                issuePoints.ReplaceOne(filter, issuePointId);
            }
            else
            {
                issuePoints.InsertOne(issuePointId);
            }

            return issuePointId.Id;
        }
        public void DeleteIssuePoint(Guid issuePointId)
        {
            var client = MongoBDClient.GetClient();
            var db = client.GetDatabase("FoodHackDB");
            var issuePoints = db.GetCollection<IssuePoint>("IssuePoints");
            var result = issuePoints.DeleteOne(x => x.Id == issuePointId);
        }
        public void DeleteAllIssuePoints()
        {
            var client = MongoBDClient.GetClient();
            var db = client.GetDatabase("FoodHackDB");
            var issuePoints = db.GetCollection<IssuePoint>("IssuePoints");
            var result = issuePoints.DeleteMany(x => true);
        }

        // components
        public IList<IComponent> GetAvailableComponents(Guid issuePointId, IList<string> categories = null)
        {
            var client = MongoBDClient.GetClient();
            var db = client.GetDatabase("FoodHackDB");
            var companies = db.GetCollection<IssuePoint>("IssuePoints");
            var foundIssuePoint = companies.Find(c => issuePointId == c.Id).FirstOrDefault();
            var availComponents = foundIssuePoint.AvailableComponents;

            IList<IComponent> filteredComponents = new List<IComponent>();
            if (categories != null && categories.Any())
            {
                foreach (var component in availComponents)
                {
                    bool isCategoryApplicable = false;
                    foreach (var componentCategory in component.Categories)
                    {
                        if (categories.Contains(componentCategory, StringComparer.OrdinalIgnoreCase))
                        {
                            isCategoryApplicable = true;
                            break;
                        }
                    }

                    if (isCategoryApplicable)
                    {
                        filteredComponents.Add(component);
                    }
                }
            }

            availComponents = filteredComponents;

            return availComponents;
        }
        public Guid CreateOrUpdateComponent(Guid issuePointId, Component component)
        {
            var client = MongoBDClient.GetClient();
            var db = client.GetDatabase("FoodHackDB");
            var issuePoints = db.GetCollection<IIssuePoint>("IssuePoints");
            var issuePoint = issuePoints.Find(x => x.Id == issuePointId).FirstOrDefault();

            if (issuePoint != null)
            {
                var foundComponent = issuePoint.AvailableComponents.Where(cmp => cmp.Id == component.Id).FirstOrDefault();
                if(foundComponent != null)
                {
                    for(int i = 0; i < issuePoint.AvailableComponents.Count; i++)
                    {
                        if(issuePoint.AvailableComponents[i].Id == component.Id)
                        {
                            issuePoint.AvailableComponents[i] = component;
                            break;
                        }
                    }
                }
                else
                {
                    issuePoint.AvailableComponents.Add(component);
                }

                var filter = Builders<IIssuePoint>.Filter.Eq(s => s.Id, issuePointId);
                issuePoints.ReplaceOne(filter, issuePoint);
            }

            return component.Id;
        }

        // orders
        public IList<Order> GetOrders(IList<Guid> ordersIds = null)
        {
            var client = MongoBDClient.GetClient();
            var db = client.GetDatabase("FoodHackDB");
            var orders = db.GetCollection<Order>("Orders");
            IList<Order> foundOrders;
            if (ordersIds != null)
            {
                foundOrders = orders.Find(x => ordersIds.Contains(x.Id)).ToList();
            }
            else
            {
                foundOrders = orders.Find(x => true).ToList();
            }

            return foundOrders;
        }
        public Guid CreateOrUpdateOrder(Order order)
        {
            var client = MongoBDClient.GetClient();
            var db = client.GetDatabase("FoodHackDB");
            var orders = db.GetCollection<Order>("Orders");
            var foundOrders = orders.Find(x => x.Id == order.Id).ToList();

            if (foundOrders.Any())
            {
                var filter = Builders<Order>.Filter.Eq(s => s.Id, order.Id);
                orders.ReplaceOne(filter, order);
            }
            else
            {
                orders.InsertOne(order);
            }

            return order.Id;
        }
        public void DeleteOrder(Guid orderId)
        {
            var client = MongoBDClient.GetClient();
            var db = client.GetDatabase("FoodHackDB");
            var orders = db.GetCollection<Order>("Orders");
            var result = orders.DeleteOne(x => x.Id == orderId);
        }
        public void DeleteAllOrders()
        {
            var client = MongoBDClient.GetClient();
            var db = client.GetDatabase("FoodHackDB");
            var orders = db.GetCollection<Order>("Orders");
            var result = orders.DeleteMany(x => true);
        }
    }
}