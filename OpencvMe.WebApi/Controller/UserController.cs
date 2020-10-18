using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpencvMe.Common.Constant;
using OpencvMe.Common.Model;
using OpencvMe.DTO.CompanyDTO;
using OpencvMe.DTO.CvDTO;
using OpencvMe.DTO.SchoolDTO;
using OpencvMe.DTO.UserDTO;
using OpencvMe.Service.Interface;
using OpencvMe.WebApi.Base;
using OpencvMe.WebApi.Filter;

namespace OpencvMe.WebApi.Controller
{
    [Route("v1/user")]
    [ValidationFilter]
    public class UserV1Controller : OpenCvBaseController
    {
        IUserService _userService;
        ISchoolService _schoolService;
        ICompanyService _companyService;
        IMapper _mapper;
        public UserV1Controller(
            IUserService userService,
            ISchoolService schoolService,
            ICompanyService companyService,
            IMapper mapper)
        {
            _userService = userService;
            _companyService = companyService;
            _schoolService = schoolService;
            _mapper = mapper;
        }

        [HttpPost, Route("register")]
        public ServiceResponse<int> RegisterUser([FromBody]UserDTO user)
        {
            return _userService.RegisterUser(user);
        }

        // Kullanıcı kendi bilgilerini çeker
        [Authorize, HttpGet, Route("")]
        public ServiceResponse<UserDTO> GetUserInformation()
        {
            var claims = GetUserClaims();
            return _userService.GetUserInformation(claims.UserId);
        }

        // birinin cv'sini  incelediğimizde çağırılan servis
        [HttpGet, Route("cv/{url}")]
        public ServiceResponse<CvDTO> GetUserCv(string url)
        {
            var response = _userService.GetUserCv(url);
            if(response.Data != null)
            {
                response.Data.UserSchools = _schoolService.GetUserSchools(response.Data.UserId).Data;
                response.Data.UserCompanies = _companyService.GetUserCompanies(response.Data.UserId).Data;
            }
            return response;
        }



        [Authorize, HttpPost, Route("cv")]
        public ServiceResponse<int> CreateCv([FromBody]CvDTO cvCreateDTO)
        {
            var claims = GetUserClaims();
            cvCreateDTO.UserId = claims.UserId;

            return _userService.CreateCv(cvCreateDTO,claims.UserId);
        }


        [HttpPut, Route("cv")]
        public ServiceResponse<bool> UpdateCv([FromBody]CvDTO cvUpdateDTO)
        {
            var claims = GetUserClaims();
            var response = new ServiceResponse<bool>();

            var usedCvResponse = _userService.CheckCvUrl(cvUpdateDTO.CvUrl,claims.UserId);


            if (!usedCvResponse.Data)
                response = _userService.UpdateCv(cvUpdateDTO, claims.UserId);
            else { 
                response.IsSuccess = false;
                response.Message = usedCvResponse.Message;
            }   


            return response;
            

        }
        [HttpPut, Route("cv/socials")]
        public ServiceResponse<bool> UpdateSocials([FromBody]SocialsDTO socialsUpdateDTO)
        {
            var claims = GetUserClaims();

            var isValid = ModelState.IsValid;

            return _userService.UpdateSocials(socialsUpdateDTO, claims.UserId);
        }

        [HttpGet, Route("cv/{url}/check")]
        public ServiceResponse<bool> CheckCv([FromRoute] string url)
        {
            var claims = GetUserClaims();
            return _userService.CheckCvUrl(url,claims.UserId);
        }

        #region School

        [HttpPost, Route("school")]
        public ServiceResponse<int> AddUserSchool([FromBody] UserSchoolDTO request)
        {
            var claims = GetUserClaims();
            return _schoolService.AddUserSchool(request, claims.UserId);
        }
        [HttpDelete, Route("school")]
        public ServiceResponse<bool> DeleteUserSchool(int userSchoolId)
        {
            return _schoolService.DeleteUserSchool(userSchoolId);
        }
        [HttpPut, Route("school")]
        public ServiceResponse<bool> UpdateUserSchool([FromBody]UserSchoolDTO request)
        {

            var claims = GetUserClaims();
            return _schoolService.UpdateUserSchool(request,claims.UserId);
        }
        #endregion

        #region Company

        [HttpPost, Route("company")]
        public ServiceResponse<int> AddUserCompany([FromBody]UserCompanyDTO request)
        {
            var claims = GetUserClaims();
            return _companyService.AddUserCompany(request, claims.UserId);
        }
        [HttpPut, Route("company")]
        public ServiceResponse<bool> UpdateUserCompany([FromBody]UserCompanyDTO request)
        {
            var claims = GetUserClaims();
            return _companyService.UpdateUserCompany(request, claims.UserId);
        }

        [HttpDelete, Route("company")]
        public ServiceResponse<bool> DeleteUserCompany(int userCompanyId)
        {
            return _companyService.DeleteUserCompany(userCompanyId);
        }

        [HttpPut, Route("password")]

        public ServiceResponse<bool> UpdatePassword([FromBody] UpdatePasswordDTO request)
        {
            var claims = GetUserClaims();
            return  _userService.UpdatePassword(request.Password,claims.UserId);
        }

        [HttpPut, Route("setting")]

        public ServiceResponse<bool> UpdateSetting([FromBody] SettingUpdateDTO request)
        {
            var claims = GetUserClaims();
            return _userService.UpdateSetting(request, claims.UserId);

        }
        #endregion

    }
}