using AutoMapper;
using OpencvMe.DTO.AuthenticationDTO;
using OpencvMe.DTO.CvDTO;
using OpencvMe.DTO.UserDTO;
using OpencvMe.Model.Model;
using OpencvMe.Repository.Interface;
using OpencvMe.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using OpencvMe.Common.Constant;

namespace OpencvMe.Service.Service
{
    public class UserService : IUserService
    {

        IUserRepository _userRepository;
        ICvRepository _cvRepository;
        IMapper _mapper;
        ISchoolService _schoolService;
        ICompanyService _companyService;

        public UserService(IUserRepository userRepository,
            ICvRepository cvRepository,
            IMapper mapper,
            ISchoolService schoolService,
            ICompanyService companyService)
        {
            _userRepository = userRepository;
            _cvRepository = cvRepository;
            _mapper = mapper;
            _schoolService = schoolService;
            _companyService = companyService;
        }


        public int RegisterUser(UserCreateDTO userRequest)
        {
            var user = _mapper.Map<User>(userRequest);
            var checkUser = _userRepository.Get(x => x.Email == user.Email);

            if(checkUser == null)
            {
                _userRepository.Create(user);
                return user.UserId;
            }
            else
            {
                return ErrorConstant.HasMail;
            }

        }
        public UserResponseDTO GetUserInformation(int id)
        {
            var user = _userRepository.Get(x => x.UserId == id);
            var cv = _cvRepository.Get(x => x.UserId == id);


            var userResponse = _mapper.Map<UserResponseDTO>(user);
            userResponse.Cv = _mapper.Map<CvResponseDTO>(cv);
            if(userResponse.Cv != null)
            {
                userResponse.Cv.Schools = _schoolService.GetUserSchools(id); ;
                userResponse.Cv.Companies = _companyService.GetUserCompanies(id);
            }
            userResponse.IsCvCreated = cv != null;

            return userResponse;
        }
        public CvResponseDTO GetUserCv (string url)
        {
           var response = new CvResponseDTO();
           var cv = _cvRepository.Get(x => x.CvUrl == url);

           response = _mapper.Map<CvResponseDTO>(cv);
          // response.Schools = _schoolService.GetUserSchools(cv.UserId);
          // response.Companies = _companyService.GetUserCompanies(cv.UserId);

           return response;
        }
        public int CreateCv (CvCreateDTO cvRequest,int userId)
        {
            var cv = _mapper.Map<Cv>(cvRequest);
            _cvRepository.Create(cv);
            var isAddSchools =  _schoolService.AddUserSchoolList(cvRequest.UserSchools, userId);
            var isAddCompanies = _companyService.AddUserCompanyList(cvRequest.UserCompanies, userId);
            return cv.CvId;
        }
        public bool UpdateCv (CvUpdateDTO cvRequest)
        {
            try
            {
                var cv = _mapper.Map<Cv>(cvRequest);
                _cvRepository.Update(cv);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }
        public UserResponseDTO LoginUser(TokenRequestDTO request)
        {
            var user = _userRepository.Get(x => x.Email == request.Email && x.Password == request.Password);
            if (user != null) {
                var response = new UserResponseDTO();
                response = _mapper.Map<UserResponseDTO>(user);
                return response;
            }
            else {
                return null;
            }


            
        }
         
        public bool CheckCvUrl(string url)
        {
            var cv = _cvRepository.Get(x => x.CvUrl == url);

            if (cv == null)
                return true;
            else
               return false;

        }
    }
}
