using FoodConstructor.Models;
using FoodConstructor.Models.Repository;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Script.Services;

namespace FoodConstructor.Controllers
{
    public class FoodConstructorController : ApiController
    {

        // OPTION http-verb handler
        public string OptionsFoodConstructor()
        {
            return null; // HTTP 200 response with empty body
        }

        [HttpGet]
        [Route(@"api/test")]
        public JsonStringResult Test()
        {
            return new JsonStringResult("Test OK");
        }

        [HttpGet]
        [Route(@"api/AllComponents")]
        public JsonStringResult AllComponents(string category = null) 
        {
            try
            {
                var company = MockDataConfig.Companies.FirstOrDefault();
                var issuePoint = MockDataConfig.IssuePoints.FirstOrDefault(ip => company.IssuePointsIds.Contains(ip.Id));

                IList<IComponent> components = new List<IComponent>();
                if (!string.IsNullOrEmpty(category))
                {
                    Repository rep = new Repository();
                    components = rep.GetAvailableComponents(issuePoint.Id, new List<string> { category });
                }
                else
                {
                    components = issuePoint.AvailableComponents;
                }

                string result = JsonConvert.SerializeObject(components);
                return new JsonStringResult(result);
            }
            catch (Exception ex)
            {
                return new JsonStringResult(); 
            }
        }

        [HttpGet]
        [Route(@"api/Components")]
        public JsonStringResult AvailableComponents(Guid companyId, Guid issuePointId)
        {
            try
            {
                var company = MockDataConfig.Companies.FirstOrDefault(c => c.Id == companyId);
                if (company != null)
                {
                    var issuePoint = MockDataConfig.IssuePoints.FirstOrDefault(ip => ip.Id == company.Id);
                    if(issuePoint != null)
                    {
                        var components = issuePoint.AvailableComponents as IList<IComponent>;
                        var json = JsonConvert.SerializeObject(components);
                        return new JsonStringResult(json);
                    }
                }

                return new JsonStringResult();
            }
            catch (Exception ex)
            {
                return new JsonStringResult();
            }
        }

        [HttpGet]
        [Route(@"api/IssuePoints")]
        public JsonStringResult IssuePoints(Guid companyId)
        {
            try
            {
                var company = MockDataConfig.Companies.FirstOrDefault(c => c.Id == companyId);
                if(company != null)
                {
                    var companyIssuePoints = company.IssuePointsIds as List<Guid>;
                    var json = JsonConvert.SerializeObject(companyIssuePoints);
                    return new JsonStringResult(json);
                }

                return new JsonStringResult();
            }
            catch (Exception ex)
            {
                return new JsonStringResult();
            }
        }

        [HttpGet]
        [Route(@"api/Companies")]
        public JsonStringResult Companies()
        {
            try
            {
                var jsonCompanies = JsonConvert.SerializeObject(MockDataConfig.Companies);
                return new JsonStringResult(jsonCompanies);
            }
            catch (Exception ex)
            {
                return new JsonStringResult();
            }
        }
    }
}
