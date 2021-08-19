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
    public class SettingsService : ISettingsService
    {
        private readonly Mapper mapper;
        private readonly UserRoleMasterRepository userDAL;
        private readonly GradeMasterRepository gradeMasterRepository;
        private readonly GradeTypeMasterRepository gradeTypeMasterRepository;
        private readonly CompanyDataRepository companyDataRepository;

        public SettingsService()
        {
            var entity = new ExtrupetEntities();
            userDAL = new UserRoleMasterRepository(entity);
            gradeMasterRepository = new GradeMasterRepository(entity);
            gradeTypeMasterRepository = new GradeTypeMasterRepository(entity);
            companyDataRepository = new CompanyDataRepository(entity);

            mapper = new MapperProfile().Mapper;
        }

        public IEnumerable<UserRoleMasterGet> GetUserRoles()
        {
            var userRoleMaster = userDAL.GetUserRoles()?.ToList();
            var userGets = new List<UserRoleMasterGet>();
            foreach (var um in userRoleMaster)
            {
                userGets.Add(mapper.Map<UserRoleMasterGet>(um));
            }

            return userGets;
        }

        public IEnumerable<GradeGet> GetAllGradeMasters()
        {
            var grads = gradeMasterRepository.GetAllGradeMasters()?.ToList();
            var companyGets = new List<GradeGet>();
            foreach (var grade in grads)
            {
                var companyGet = mapper.Map<GradeGet>(grade);
                companyGets.Add(companyGet);
            }

            return companyGets;
        }


        public GradeGet AddOrUpdateGradeMaster(GradeSet grade)
        {
            GradeMaster gradeMaster = mapper.Map<GradeMaster>(grade);
            gradeMaster.LastUpdatedOnUTC = DateTime.UtcNow;
            var grad = gradeMasterRepository.AddOrUpdateGradeMaster(gradeMaster);
            return mapper.Map<GradeGet>(grad);
        }

        public GradeTypeGet AddOrUpdateGradeTypeMaster(GradeTypeSet grade)
        {
            var gtm = mapper.Map<GradeTypeMaster>(grade);
            var gradetype = gradeTypeMasterRepository.AddOrUpdateGradeTypeMaster(gtm);
            return mapper.Map<GradeTypeGet>(gradetype);
        }

        public IEnumerable<GradeTypeGet> GetAllGradeTypeMasters()
        {
            var grads = gradeTypeMasterRepository.GetAllGradeTypeMasters()?.ToList();
            var companyGets = new List<GradeTypeGet>();
            foreach (var gtm in grads)
            {
                var companyGet = mapper.Map<GradeTypeGet>(gtm);
                companyGets.Add(companyGet);
            }

            return companyGets;
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
            CompanySetup companySetup = mapper.Map<CompanySetup>(companyDataSet);
            //companySetup.LastUpdatedBy= null;
            companySetup = companyDataRepository.SaveCompanyData(companySetup);
            return mapper.Map<CompanyDataGet>(companySetup);
        }
    }
}
