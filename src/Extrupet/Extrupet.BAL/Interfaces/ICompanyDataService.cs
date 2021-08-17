using Extrupet.BAL.Models;
using System.Collections.Generic;

namespace Extrupet.BAL.Interfaces
{
    public interface ICompanyDataService
    {
        IEnumerable<CompanyDataGet> GetCompanyData();        
        CompanyDataGet SaveCompanyData(CompanyDataSet companyDataSet);        
    }
}
