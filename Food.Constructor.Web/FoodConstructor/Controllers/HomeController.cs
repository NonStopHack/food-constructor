using FoodConstructor.Models;
using FoodConstructor.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FoodConstructor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Use this application to get meal that you want";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Don't be shy to contact us!";

            return View();
        }


        // companies
        [HttpGet]
        public ActionResult Companies()
        {
            Repository rep = new Repository();
            var companies = rep.GetCompanies()  ?? new List<Company>();
            return View(companies);
        }

        [HttpGet]
        public ActionResult DeleteCompany(Guid? companyId)
        {
            if (companyId.HasValue)
            {
                Repository rep = new Repository();
                rep.DeleteCompany(companyId.Value);
            }

            return Redirect("/Home/Companies");
        }

        [HttpGet]
        public ActionResult EditCompany(Guid? companyId)
        {
            ICompany company;
            if (companyId.HasValue)
            {
                Repository rep = new Repository();
                company = rep.GetCompanies(new List<Guid> { companyId.Value }).FirstOrDefault();
            }
            else
            {
                company = new Company("New company");
            }
            
            return View(company);
        }

        [HttpPost]
        public ActionResult EditCompany(Company company)
        {
            if (company != null)
            {
                Repository rep = new Repository();
                rep.CreateOrUpdateCompany(company);

                return Redirect("/Home/Companies");
            }

            return View(company);
        }


        // issue points
        [HttpGet]
        public ActionResult IssuePoints()
        {
            Repository rep = new Repository();
            var issuePoints = rep.GetCompanyIssuePoint() ?? new List<IssuePoint>();
            return View(issuePoints);
        }

        [HttpGet]
        public ActionResult EditIssuePoint(Guid? issuePointId)
        {
            IIssuePoint IssuePoint;
            if (issuePointId.HasValue)
            {
                Repository rep = new Repository();
                IssuePoint = rep.GetCompanyIssuePoint(new List<Guid> { issuePointId.Value }).FirstOrDefault();
            }
            else
            {
                IssuePoint = new IssuePoint("New point", "New address");
            }

            return View(IssuePoint);
        }

        [HttpPost]
        public ActionResult EditIssuePoint(IssuePoint issuePoint)
        {
            if (issuePoint != null)
            {
                Repository rep = new Repository();
                rep.CreateOrUpdateIssuePoint(issuePoint);

                return Redirect("/Home/IssuePoints");
            }

            return View(issuePoint);
        }

        [HttpGet]
        public ActionResult DeleteIssuePoint(Guid? issuePointId)
        {
            if (issuePointId.HasValue)
            {
                Repository rep = new Repository();
                rep.DeleteIssuePoint(issuePointId.Value);
            }

            return Redirect("/Home/IssuePoints");
        }

        // orders
        [HttpGet]
        public ActionResult Orders()
        {
            Repository rep = new Repository();
            var orders = rep.GetOrders() ?? new List<Order>();
            return View(orders);
        }

        [HttpGet]
        public ActionResult EditOrder(Guid? orderId)
        {
            Order Order;
            if (orderId.HasValue)
            {
                Repository rep = new Repository();
                Order = rep.GetOrders(new List<Guid> { orderId.Value }).FirstOrDefault();
            }
            else
            {
                Order = new Order();
            }

            return View(Order);
        }

        [HttpPost]
        public ActionResult EditOrder(Order order)
        {
            if (order != null)
            {
                Repository rep = new Repository();
                rep.CreateOrUpdateOrder(order);

                return Redirect("/Home/Orders");
            }

            return View(order);
        }

        [HttpGet]
        public ActionResult DeleteOrder(Guid? orderId)
        {
            if (orderId.HasValue)
            {
                Repository rep = new Repository();
                rep.DeleteOrder(orderId.Value);
            }

            return Redirect("/Home/Orders");
        }
    }
}