using AutoMapper;
using Extrupet.BAL.Interfaces;
using Extrupet.BAL.Models;
using Extrupet.BAL.Utilities;
using Extrupet.DAL.Entity;
using Extrupet.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.BAL.Services
{
    public class CompanyDataService : ICompanyDataService
    {
        private readonly Mapper mapper;
        private readonly CompanyDataRepository companyDataRepository;
        public CompanyDataService()
        {
            companyDataRepository = new CompanyDataRepository(new ExtrupetEntities());
            mapper = new MapperProfile().Mapper;
        }

        public IEnumerable<CompanyDataGet> GetCompanyData()
        {
            var companyMaster = companyDataRepository.GetCompayData()?.ToList();
            var companyGets = new List<CompanyDataGet>();
            foreach (var um in companyMaster)
            {
                var companyGet = mapper.Map<CompanyDataGet>(um);                
                companyGets.Add(companyGet);
            }

            return companyGets;
        }

        public CompanyDataGet SaveCompanyData(CompanyDataSet companyDataSet)
        {
            CompanySetup companySetup= mapper.Map<CompanySetup>(companyDataSet);
            //companySetup.LastUpdatedBy= null;
            companySetup = companyDataRepository.SaveCompanyData(companySetup);
            return mapper.Map<CompanyDataGet>(companySetup);
        }
    }
}
