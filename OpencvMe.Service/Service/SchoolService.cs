using AutoMapper;
using OpencvMe.Common.Helper;
using OpencvMe.Common.Model;
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


        public ServiceResponse<List<UserSchoolDTO>> GetUserSchools(int userId)
        {
            var serviceResponse = new ServiceResponse<List<UserSchoolDTO>>();
            serviceResponse.Data = (
                from us in _userSchoolRepository.Find(x=> x.UserId == userId)
                join s in _schoolRepository.GetAll() on us.SchoolId equals s.SchoolId
                where s.SchoolId == us.SchoolId
                select new UserSchoolDTO()
                {
                    UserSchoolId = us.UserSchoolId,
                    SchoolName = s.Name,
                    SchoolId = s.SchoolId,
                    Description  =us.Description,
                    Section = us.Section,
                    IsContinue = us.IsContinue,
                    StartDate = us.StartDate,
                    EndDate = us.EndDate,
                    LicenseDegree = us.LicenseDegree,
                    StartDateStr = us.StartDate.CustomDateStr(),
                    EndDateStr = us.IsContinue ? " Devam ediyor " : us.EndDate?.CustomDateStr(),
                   
                }
            ).ToList();
            return serviceResponse.Success();
        }

        public ServiceResponse<List<SchoolDTO>> SearchSchool(string searchText)
        {
            var serviceResponse = new ServiceResponse<List<SchoolDTO>>();
            var schools = _schoolRepository.Find(x => x.Name.Contains(searchText)).ToList();
            serviceResponse.Data = _mapper.Map<List<SchoolDTO>>(schools);
            return serviceResponse.Success();
        }

        public ServiceResponse<int> CreateSchool(string schoolName)
        {
            var serviceResponse = new ServiceResponse<int>();

            var school = new School() { Name = schoolName };
            _schoolRepository.Create(school);
            serviceResponse.Data = school.SchoolId;
            return serviceResponse.Success();
        }

        public ServiceResponse<bool> AddUserSchoolList(List<UserSchoolDTO> request,int userId)
        {
            var serviceResponse = new ServiceResponse<bool>();


            request.ForEach(item =>
            {
                if(item.SchoolId < 1)
                    item.SchoolId = CreateSchool(item.SchoolName).Data;
            });


            var userSchools = _mapper.Map<List<UserSchool>>(request);
            userSchools.ForEach(item => item.UserId = userId);
            serviceResponse.Data = _userSchoolRepository.CreateRange(userSchools);

            return serviceResponse.Success();
        }

        public ServiceResponse<int> AddUserSchool(UserSchoolDTO request,int userId)
        {
            var serviceResponse = new ServiceResponse<int>();

            if (request.SchoolId < 1) // eğer yeni bir okul ekliyorsa kaydet
              request.SchoolId = CreateSchool(request.SchoolName).Data;
           
            var userSchool = _mapper.Map<UserSchool>(request);
            userSchool.UserId = userId;
            _userSchoolRepository.Create(userSchool);
            serviceResponse.Data = userSchool.UserSchoolId;
            return serviceResponse.Success();
        }

        public ServiceResponse<bool> DeleteUserSchool(int userSchoolId)
        {
            var serviceResponse = new ServiceResponse<bool>();
            serviceResponse.Data = _userSchoolRepository.Delete(userSchoolId);
            return serviceResponse.Success();
        }

        public ServiceResponse<bool> UpdateUserSchool(UserSchoolDTO request, int userId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            if (request.SchoolId < 1) // eğer yeni bir okul ekliyorsa kaydet
                request.SchoolId = CreateSchool(request.SchoolName).Data;

            var userSchool = _mapper.Map<UserSchool>(request);
            userSchool.UserId = userId;
            _userSchoolRepository.Update(userSchool);
            serviceResponse.Data = true;
            return serviceResponse.Success();
        }
    }
}
