using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpencvMe.Common.Model;
using OpencvMe.DTO.CvDTO;
using OpencvMe.DTO.UserDTO;
using OpencvMe.Service.Interface;
using OpencvMe.WebApi.Base;

namespace OpencvMe.WebApi.Controller
{
    [Route("v1/user")]
    //[ApiController]
    public class UserV1Controller : OpenCvBaseController
    {
        IUserService _userService;
        ISchoolService _schoolService;
        ICompanyService _companyService;
        public UserV1Controller(
            IUserService userService,
            ISchoolService schoolService,
            ICompanyService companyService)
        {
            _userService = userService;
            _companyService = companyService;
            _schoolService = schoolService;
        }
 
        [Authorize,HttpGet, Route("")]
        public ApiResponse<UserResponseDTO> GetUserInformation()
        {
            var claims = GetUserClaims();
            var response = new ApiResponse<UserResponseDTO>();
            response.Data = _userService.GetUserInformation(claims.UserId);
            return response.Success();
        }

        [HttpGet, Route("cv/{url}")]
        public ApiResponse<CvResponseDTO> GetUserCv (string url)
        {
            var response = new ApiResponse<CvResponseDTO>();
            response.Data = _userService.GetUserCv(url);
            response.Data.Schools = _schoolService.GetUserSchools(response.Data.UserId);
            response.Data.Companies = _companyService.GetUserCompanies(response.Data.UserId);
            return response.Success();
        }

        [HttpPost, Route("register")]
        public ApiResponse<int> RegisterUser([FromBody]UserCreateDTO user)
        {

            var response = new ApiResponse<int>();
            response.Data = _userService.RegisterUser(user);
            return response.Success();
        }

        [Authorize,HttpPost,Route("cv")]
        public ApiResponse<int> CreateCv([FromBody]CvCreateDTO cvCreateDTO)
        {
            var claims = GetUserClaims();
            cvCreateDTO.UserId = claims.UserId;
            var response = new ApiResponse<int>();
            response.Data = _userService.CreateCv(cvCreateDTO);
            return response.Success();
        }

        [HttpPut, Route("cv")]
        public ApiResponse<bool> UpdateCv(CvUpdateDTO cvUpdateDTO)
        {
            var response = new ApiResponse<bool>();
            response.Data = _userService.UpdateCv(cvUpdateDTO);
            return response.Success();
        }

        [HttpGet,Route("cv/{url}/check")]
        public ApiResponse<bool> CheckCv([FromRoute] string url)
        {
            var response = new ApiResponse<bool>();
            response.Data = _userService.CheckCvUrl(url);
            return response.Success();
        }

    }
}