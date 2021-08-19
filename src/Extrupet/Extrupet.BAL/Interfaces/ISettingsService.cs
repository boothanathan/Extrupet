using Extrupet.BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.BAL.Interfaces
{
    public interface ISettingsService
    {
        IEnumerable<UserRoleMasterGet> GetUserRoles();

        GradeGet AddOrUpdateGradeMaster(GradeSet grade);
        IEnumerable<GradeGet> GetAllGradeMasters();

        GradeTypeGet AddOrUpdateGradeTypeMaster(GradeTypeSet grade);
        IEnumerable<GradeTypeGet> GetAllGradeTypeMasters();

        IEnumerable<CompanyDataGet> GetCompanyData();
        CompanyDataGet SaveCompanyData(CompanyDataSet companyDataSet);


        //void SaveQualityMeasurementUnit();
        //void GetAllQualityMeasurementUnit();
        //void SaveQualityParameter();
        //void GetAllQualityParameter();
        //void GetQualityParameterById();
        //void SaveTestMethod()
        //void  GetAllTestMethod()
        //void SaveGradeWiseQualityParameterBaseData()
        //void GetAllGradeWiseQualityParameterBaseData()
        //void GetGradeWiseQualityParameterBaseDataById()
    }
}
