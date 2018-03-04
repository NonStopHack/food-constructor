using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodConstructor.Models.Repository
{
    interface IRepository
    {
        Guid CreateOrUpdateCompany(Company company);
        void DeleteCompany(Guid companyId);
        IList<Company> GetCompanies(IList<Guid> companiesIds = null);
        IList<IssuePoint> GetCompanyIssuePoint(IList<Guid> companiesIds);
        IList<IComponent> GetAvailableComponents(Guid issuePointId, IList<string> categories);
        Guid CreateOrUpdateComponent(Guid issuePointId, Component component);
        Guid CreateOrUpdateOrder(Order order);
        Guid CreateOrUpdateIssuePoint(IssuePoint issuePointId);
    }
}
