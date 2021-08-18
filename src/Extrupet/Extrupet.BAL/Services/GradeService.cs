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
    public class GradeService : IGradeService
    {
        private readonly Mapper mapper;
        private readonly GradeMasterRepository gradeMasterRepository;
        private readonly GradeTypeMasterRepository gradeTypeMasterRepository;
        public GradeService()
        {
            var entity = new ExtrupetEntities();
            gradeMasterRepository = new GradeMasterRepository(entity);
            gradeTypeMasterRepository = new GradeTypeMasterRepository(entity);
            mapper = new MapperProfile().Mapper;
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
    }
}
