using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodConstructor.Models.Repository
{
    public class Repository : IRepository
    {
        public Guid CreateOrUpdateCompany(ICompany company)
        {
            throw new NotImplementedException();
        }

        public Guid CreateOrUpdateComponent(Guid companyId, Guid issuePointId, IComponent component)
        {
            throw new NotImplementedException();
        }

        public Guid CreateOrUpdateOrder(Guid companyId, Guid issuePointId, IOrder order)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompany(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public IList<IComponent> GetAvailableComponents(Guid companyId, Guid issuePointId)
        {
            throw new NotImplementedException();
        }

        public IList<ICompany> GetCompanies(IList<Guid> companiesIds)
        {
            throw new NotImplementedException();
        }

        public IList<IIssuePoint> GetCompanyIssuePoint(IList<Guid> companiesIds)
        {
            throw new NotImplementedException();
        }
    }
}