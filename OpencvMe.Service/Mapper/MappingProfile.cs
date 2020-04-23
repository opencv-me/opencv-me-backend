using AutoMapper;
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
            CreateMap<UserCreateDTO,User >();
            CreateMap<UserUpdateDTO,User >();
            CreateMap<User, UserResponseDTO>();
            #endregion

            #region Cv Mapping 
            CreateMap<CvCreateDTO, Cv>();
            CreateMap<Cv, CvResponseDTO>();
            #endregion

            #region School Mapping 
            CreateMap<School, SchoolResponseDTO>()
            .ForMember(x => x.SchoolName, x => x.MapFrom(src => src.Name));

            CreateMap<SchoolCreateDTO,School>();
            CreateMap<UserSchoolCreateDTO, UserSchool>();
            #endregion

            #region Company Mapping
            //CreateMap<Company, CompanyResponseDTO>>();
            CreateMap<Company, CompanyResponseDTO>()
            .ForMember(x => x.CompanyName, x => x.MapFrom(src => src.Name));

            CreateMap<CompanyCreateDTO, Company>();
            CreateMap<UserCompanyCreateDTO, UserCompany>();
            // CreateMap<UserCompany, UserCompanyResponseDTO>();
            #endregion




        }
    }
  
}
