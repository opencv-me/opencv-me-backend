using AutoMapper;
using OpencvMe.DTO.SchoolDTO;
using OpencvMe.Model.Model;
using OpencvMe.Repository.Interface;
using OpencvMe.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpencvMe.Service.Service
{
    public class SchoolService : ISchoolService
    {
        public ISchoolRepository _schoolRepository;
        public IUserSchoolRepository _userSchoolRepository;
        public IMapper _mapper;
        public SchoolService(
            IUserSchoolRepository userSchoolRepository,
            ISchoolRepository schoolRepository,
            IMapper mapper)
        {
            _userSchoolRepository = userSchoolRepository;
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }


        public List<UserSchoolResponseDTO> GetUserSchools(int userId)
        {

            var response = (
                from us in _userSchoolRepository.Find(x=>x.UserId == userId)
                join s in _schoolRepository.GetAll() on us.SchoolId equals s.SchoolId
                where s.SchoolId == us.SchoolId
                select new UserSchoolResponseDTO()
                {
                    SchoolName = s.Name,
                    SchoolId = s.SchoolId,
                    Description  =us.Description,
                    DiplomaPoint = us.DiplomaPoint,
                    EndDate = us.EndDate,
                    IsContinue = us.IsContinue,
                    StartDate = us.StartDate

                }
            ).ToList();

            return response;
        }

        public List<SchoolResponseDTO> SearchSchool(string searchText)
        {
            var schools = _schoolRepository.Find(x => x.Name.Contains(searchText)).ToList();
            var response = _mapper.Map<List<SchoolResponseDTO>>(schools);
            return response;
        }

        public int CreateSchool(SchoolCreateDTO schoolRequest)
        {
            var school = _mapper.Map<School>(schoolRequest);
            _schoolRepository.Create(school);
            return school.SchoolId;
        }
    }
}
