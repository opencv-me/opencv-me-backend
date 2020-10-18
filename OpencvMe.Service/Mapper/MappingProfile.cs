using AutoMapper;
using OpencvMe.Common.Model;
using OpencvMe.DTO.CompanyDTO;
using OpencvMe.DTO.CvDTO;
using OpencvMe.DTO.SchoolDTO;
using OpencvMe.DTO.UserDTO;
using OpencvMe.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region User Mapping
            CreateMap<UserDTO,User >();
            CreateMap<User, UserDTO>();
            #endregion

            #region Cv Mapping 
            CreateMap<CvDTO, Cv>();
            CreateMap<Cv, CvDTO>();
            #endregion

            #region School Mapping 
            CreateMap<School, SchoolDTO>()
            .ForMember(x => x.SchoolName, x => x.MapFrom(src => src.Name));

            CreateMap<SchoolDTO,School>();
            CreateMap<UserSchoolDTO, UserSchool>();
            #endregion

            #region Company Mapping
            //CreateMap<Company, CompanyResponseDTO>>();
            CreateMap<Company, CompanyDTO>()
            .ForMember(x => x.CompanyName, x => x.MapFrom(src => src.Name));

            CreateMap<CompanyDTO, Company>();
            CreateMap<UserCompanyDTO, UserCompany>();
            // CreateMap<UserCompany, UserCompanyResponseDTO>();
            #endregion

            CreateMap(typeof(ApiResponse<>), typeof(ServiceResponse<>));

        }
    }
  
}
