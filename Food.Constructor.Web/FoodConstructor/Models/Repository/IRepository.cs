using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodConstructor.Models.Repository
{
    interface IRepository
    {
        // companies
        IList<Company> GetCompanies(IList<Guid> companiesIds = null);
        Guid CreateOrUpdateCompany(Company company);
        void DeleteCompany(Guid companyId);

        // issue points
        IList<IssuePoint> GetCompanyIssuePoint(IList<Guid> companiesIds);
        Guid CreateOrUpdateIssuePoint(IssuePoint issuePoint);
        void DeleteIssuePoint(Guid issuePointId);

        // components
        IList<IComponent> GetAvailableComponents(Guid issuePointId, IList<string> categories);
        Guid CreateOrUpdateComponent(Guid issuePointId, Component component);

        // orders
        IList<Order> GetOrders(IList<Guid> ordersId = null);
        Guid CreateOrUpdateOrder(Order order);
    }
}
