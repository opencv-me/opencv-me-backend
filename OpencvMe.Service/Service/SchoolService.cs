using AutoMapper;
using OpencvMe.Common.Helper;
using OpencvMe.DTO.SchoolDTO;
using OpencvMe.Model.Model;
using OpencvMe.Repository.Interface;
using OpencvMe.Service.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                    UserSchoolId = us.UserSchoolId,
                    SchoolName = s.Name,
                    SchoolId = s.SchoolId,
                    Description  =us.Description,
                    Section = us.Section,
                    IsContinue = us.IsContinue,
                    StartDate = us.StartDate,
                    EndDate = us.EndDate,
                    StartDateStr = us.StartDate.CustomDateStr(),
                    EndDateStr = us.EndDate?.CustomDateStr(),
                   
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

        public bool AddUserSchoolList(List<UserSchoolCreateDTO> request,int userId)
        {
            var userSchools = _mapper.Map<List<UserSchool>>(request);
            userSchools.ForEach(item => item.UserId = userId);
            var response = _userSchoolRepository.CreateRange(userSchools);
            return response;
        }

        public int AddUserSchool(UserSchoolCreateDTO request,int userId)
        {
            var userSchool = _mapper.Map<UserSchool>(request);
            userSchool.UserId = userId;
            var response = _userSchoolRepository.Create(userSchool);
            return response.UserSchoolId;
        }

        public bool DeleteUserSchool(int userSchoolId)
        {
           return _userSchoolRepository.Delete(userSchoolId);
        }

        public bool UpdateUserSchool(UserSchoolUpdateDTO request, int userId)
        {
            var userSchool = _mapper.Map<UserSchool>(request);
            userSchool.UserId = userId;
            _userSchoolRepository.Update(userSchool);
            return true;
        }
    }
}
