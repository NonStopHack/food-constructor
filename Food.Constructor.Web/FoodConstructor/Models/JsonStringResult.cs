using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodConstructor.Models
{
    public class JsonStringResult : System.Web.Mvc.ContentResult
    {
        public JsonStringResult(string json = "")
        {
            Content = json;
            ContentType = "application/json";
        }
    }
}