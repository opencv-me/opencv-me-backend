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
using OpencvMe.Common.Helper;
using OpencvMe.Common.Model;
using System.IO;

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


        public ServiceResponse<int> RegisterUser(UserDTO userRequest)
        {
            var serviceResponse = new ServiceResponse<int>();
            var user = _mapper.Map<User>(userRequest);
            var checkUser = _userRepository.Get(x => x.Email == user.Email);

            if (checkUser != null) return serviceResponse.Error("Bu Email Adresi Kullanılıyor");

           
            _userRepository.Create(user);
            serviceResponse.Data = user.UserId;
            return serviceResponse.Success();

        }



        public ServiceResponse<UserDTO> GetUserInformation(int id)
        {

            var serviceResponse = new ServiceResponse<UserDTO>();

            var user = _userRepository.Get(x => x.UserId == id);
            if (user == null) return serviceResponse.Error("Kullanıcı Bulunamadı");
            serviceResponse.Data = _mapper.Map<UserDTO>(user);

            var cv = _cvRepository.Get(x => x.UserId == id);
            if (cv == null) return serviceResponse.Success("Bu Kullanıcının Cv'si Oluşturulmamış");



            serviceResponse.Data.Cv = _mapper.Map<CvDTO>(cv);
            serviceResponse.Data.Cv.Socials = new SocialsDTO()
            {
                Facebook = cv.Facebook,
                Twitter = cv.Twitter,
                Youtube = cv.Youtube,
                Instagram = cv.Instagram,
                Linkedin = cv.Linkedin,
                Medium = cv.Medium
            };


            serviceResponse.Data.Cv.UserSchools = _schoolService.GetUserSchools(id).Data;
            serviceResponse.Data.Cv.UserCompanies = _companyService.GetUserCompanies(id).Data;
            serviceResponse.Data.IsCvCreated = cv != null;

            return serviceResponse.Success();

        }

        public ServiceResponse<CvDTO> GetUserCv (string url)
        {
           var serviceResponse = new ServiceResponse<CvDTO>();
           var cv = _cvRepository.Get(x => x.CvUrl == url);

           if (cv == null) return serviceResponse.Error("Cv Bulunamadı..");

           var cvResponse = _mapper.Map<CvDTO>(cv);
           cvResponse.BirthDayStr = cvResponse.BirthDay.CustomFullDateStr();

           serviceResponse.Data = cvResponse;

           return serviceResponse.Success();
        }
        public ServiceResponse<CvDTO> GetUserCv(int userId)
        {
            var serviceResponse = new ServiceResponse<CvDTO>();
            var cv = _cvRepository.Get(x => x.UserId == userId);
            serviceResponse.Data = _mapper.Map<CvDTO>(cv);
            return serviceResponse.Success();
        }
        public ServiceResponse<int> CreateCv (CvDTO cvRequest,int userId)
        {
            var serviceResponse = new ServiceResponse<int>();
            try
            {
                var cv = _mapper.Map<Cv>(cvRequest);


                if(cvRequest.Socials != null)
                {
                    cv.Facebook = cvRequest.Socials.Facebook;
                    cv.Instagram = cvRequest.Socials.Instagram;
                    cv.Twitter = cvRequest.Socials.Twitter;
                    cv.Linkedin = cvRequest.Socials.Linkedin;
                    cv.Medium = cvRequest.Socials.Medium;
                    cv.Youtube = cvRequest.Socials.Youtube;
                }

                if (IsUsedCvUrl(cvRequest.CvUrl, userId)) return serviceResponse.Error("Bu Url Adresi kullanılıyor");

                _cvRepository.Create(cv);

                if (cv.CvId < 1) return serviceResponse.Error("Cv Oluşturulamadı");

                var isAddSchools = _schoolService.AddUserSchoolList(cvRequest.UserSchools, userId);

                var isAddCompanies = _companyService.AddUserCompanyList(cvRequest.UserCompanies, userId);

                return serviceResponse.Success();
            }
            catch (Exception ex)
            {
               return  serviceResponse.Error("Cv oluşturulamadı");
            }
          
        }
        public ServiceResponse<bool> UpdateCv (CvDTO cvRequest,int userId)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                if (IsUsedCvUrl(cvRequest.CvUrl, userId)) return serviceResponse.Error("Bu Url Adresi kullanılıyor");

                var cv = _cvRepository.Get(x => x.UserId == userId);

                cv.PhoneNumber = cvRequest.PhoneNumber;
                cv.AboutDescription = cvRequest.AboutDescription;
                cv.BirthDay = cvRequest.BirthDay;
                cv.CvUrl = cvRequest.CvUrl;
                cv.Email = cvRequest.Email;
                cv.Location = cvRequest.Location;
                cv.Name = cvRequest.Name;
                cv.SurName = cvRequest.SurName;
                cv.Website = cvRequest.Website;
                cv.City = cvRequest.City;
                _cvRepository.Update(cv);
                serviceResponse.Data = true;
                return serviceResponse.Success();
            }
            catch (Exception ex)
            {
                return serviceResponse.Error("Cv Bilgileri Güncellenemedi");
            }
           
        }
        public ServiceResponse<UserDTO> LoginUser(TokenRequestDTO request)
        {
            var serviceResponse = new ServiceResponse<UserDTO>();

            try
            { 

                var user = _userRepository.Get(x => x.Email == request.Email && x.Password == request.Password);
                if (user == null) return serviceResponse.Error("Kullanıcı Adı Veya Şifre Yanlış");

                serviceResponse.Data = new UserDTO();
                serviceResponse.Data = _mapper.Map<UserDTO>(user);
                return serviceResponse.Success();
            }
            catch (Exception ex)
            {
                return serviceResponse.Error("Bilinmeyen Bir Hata Oluştu");
            }

        }
         
        public ServiceResponse<bool> CheckCvUrl(string url,int userId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                serviceResponse.Data = IsUsedCvUrl(url, userId);

                if (serviceResponse.Data) return serviceResponse.Error("Bu url başkası tarafından kullanılıyor");

                return serviceResponse.Success();
            }
            catch (Exception ex)
            {
                return serviceResponse.Error("Bilinmeyen Bir Hata Oluştu");
            }

        }

        public ServiceResponse<bool> UpdateSocials(SocialsDTO socialsUpdateDTO, int userId)
        {
            var serviceResponse = new ServiceResponse<bool>();


            try
            {
                var cv = _cvRepository.Get(x => x.UserId == userId);

                cv.Facebook = socialsUpdateDTO.Facebook;
                cv.Twitter = socialsUpdateDTO.Twitter;
                cv.Medium = socialsUpdateDTO.Medium;
                cv.Instagram = socialsUpdateDTO.Instagram;
                cv.Linkedin = socialsUpdateDTO.Linkedin;
                cv.Youtube = socialsUpdateDTO.Youtube;

                _cvRepository.Update(cv);
                serviceResponse.Data = true;
                return serviceResponse.Success();
            }
            catch (Exception ex)
            {
                return serviceResponse.Error("Sosyal Medya Hesapları Güncellenemedi");
            }
        }

        public ServiceResponse<bool> UpdatePassword(string password, int userId)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                var user = _userRepository.Get(x => x.UserId == userId);
                user.Password = password;
                _userRepository.Update(user);
                serviceResponse.Data = true;
                return serviceResponse.Success();
            }
            catch (Exception ex)
            {
                return serviceResponse.Error("Şifre Güncellenemedi");
            }

        }

        public ServiceResponse<bool> UpdateSetting(SettingUpdateDTO request,int userId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {

                if (IsUsedMail(request.Email,userId))
                    return serviceResponse.Error("Bu Mail Adresi Kullanılıyor");
                

                var user = _userRepository.Get(x => x.UserId == userId);

                user.Email = request.Email;
                user.FullName = request.FullName;
                user.IsMale = request.IsMale.ToString();
                user.IsActive = request.IsActive;
                _userRepository.Update(user);
                serviceResponse.Data = true;

                return serviceResponse.Success();
            }
            catch (Exception ex)
            {
                return serviceResponse.Error("Kullanıcı Ayarları güncellenemedi");
            }


        }


        protected bool IsUsedMail (string email,int userId)
        {
            var user = _userRepository.Get(x => x.Email == email && x.UserId != userId);

            if (user == null)
                return false;
            else
                return true;

        }
        protected bool IsUsedCvUrl(string cvUrl, int userId)
        {
            var user = _cvRepository.Get(x => x.CvUrl == cvUrl && x.UserId != userId);

            if (user == null)
                return false;
            else
                return true;

        }


    }
}
