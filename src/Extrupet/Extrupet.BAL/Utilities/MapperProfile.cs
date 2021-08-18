using AutoMapper;
using Extrupet.BAL.Models;
using Extrupet.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.BAL.Utilities
{
    public class MapperProfile
    {
        private readonly MapperConfiguration config;
        public readonly Mapper Mapper;
        public MapperProfile()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserRoleMaster, UserRoleMasterGet>();
                cfg.CreateMap<UserRoleMasterSet, UserRoleMaster>();

                cfg.CreateMap<CompanySetup, CompanyDataGet>();
                cfg.CreateMap<CompanyDataSet, CompanySetup>();

                cfg.CreateMap<UserSet, UserMaster>();
                cfg.CreateMap<UserGet, UserSet>();
                cfg.CreateMap<UserMaster, UserGet>();

                cfg.CreateMap<GradeTypeMaster, GradeTypeGet>();
                cfg.CreateMap<GradeTypeSet, GradeTypeMaster>();
                
                cfg.CreateMap<GradeMaster, GradeGet>();
                cfg.CreateMap<GradeSet, GradeMaster>();


            });
            Mapper = new Mapper(config);
        }
    }


    //public static class Mapper<TSrc, TDest> where TSrc : class
    //                            where TDest : class
    //{
    //    public static TDest Map(TSrc parent, TDest child)
    //    {
    //        var parentProperties = parent.GetType().GetProperties();
    //        var childProperties = child.GetType().GetProperties();

    //        foreach (var parentProperty in parentProperties)
    //        {
    //            foreach (var childProperty in childProperties)
    //            {
    //                if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
    //                {
    //                    childProperty.SetValue(child, parentProperty.GetValue(parent));
    //                    break;
    //                }
    //            }
    //        }

    //        return child;
    //    }


    //}
}
