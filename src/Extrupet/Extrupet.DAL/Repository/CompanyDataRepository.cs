using Extrupet.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.DAL.Repository
{
    public class CompanyDataRepository : GenericQuery<CompanySetup>
    {

        public CompanyDataRepository(ExtrupetEntities context) : base(context)
        {

        }

        public IEnumerable<CompanySetup> GetCompayData()
        {
            return base.GetQuery(null);
        }

        public CompanySetup SaveCompanyData(CompanySetup companySetup)
        {
            companySetup.LastUpdatedOnUTC = DateTime.UtcNow;
            if (companySetup.CompanyId == 0)
                companySetup = base.Add(companySetup);
            else
                companySetup = base.Update(companySetup);
            return companySetup;
        }

    }
}
