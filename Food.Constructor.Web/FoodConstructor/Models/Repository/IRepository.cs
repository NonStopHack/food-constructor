using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodConstructor.Models.Repository
{
    interface IRepository
    {
        Guid CreateOrUpdateCompany(ICompany company);
        void DeleteCompany(Guid companyId);
        IList<ICompany> GetCompanies(IList<Guid> companiesIds);
        IList<IIssuePoint> GetCompanyIssuePoint(IList<Guid> companiesIds);
        IList<IComponent> GetAvailableComponents(Guid companyId, Guid issuePointId);
        Guid CreateOrUpdateComponent(Guid companyId, Guid issuePointId, IComponent component);
        Guid CreateOrUpdateOrder(Guid companyId, Guid issuePointId, IOrder order);
    }
}
