using FoodConstructor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            return new JsonStringResult("Test method successfully invoked");
        }

        [HttpGet]

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [Route(@"api/AllComponents")]
        public JsonStringResult AllComponents()
        {
            try
            {
                var company = MockDataConfig.Companies.FirstOrDefault();
                var issuePoint = MockDataConfig.IssuePoints.FirstOrDefault(ip => company.IssuePointsIds.Contains(ip.Id));
                var components = issuePoint.AvailableComponents as IList<IComponent>;
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
        public string IssuePoints(Guid companyId)
        {
            try
            {
                var company = MockDataConfig.Companies.FirstOrDefault(c => c.Id == companyId);
                if(company != null)
                {
                    return JsonConvert.SerializeObject(company.IssuePointsIds as List<Guid>);
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        [HttpGet]
        [Route(@"api/Companies")]
        public string Companies()
        {
            try
            {
               return JsonConvert.SerializeObject(MockDataConfig.Companies);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
