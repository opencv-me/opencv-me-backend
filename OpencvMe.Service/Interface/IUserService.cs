using OpencvMe.Common.Model;
using OpencvMe.DTO.AuthenticationDTO;
using OpencvMe.DTO.CvDTO;
using OpencvMe.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.Service.Interface
{
    public interface IUserService
    {
        ServiceResponse<int> RegisterUser(UserDTO userRequest);
        ServiceResponse<UserDTO> GetUserInformation(int id);
        ServiceResponse<CvDTO> GetUserCv(string url);
        ServiceResponse<CvDTO> GetUserCv(int userId);
        ServiceResponse<UserDTO> LoginUser(TokenRequestDTO request);
        ServiceResponse<int> CreateCv(CvDTO cvReques,int userId);
        ServiceResponse<bool> UpdateCv(CvDTO cvReques,int userId);
        ServiceResponse<bool> UpdateSocials(SocialsDTO socialsUpdateDTO, int userId);
        ServiceResponse<bool> UpdatePassword(string password, int userId);
        ServiceResponse<bool> CheckCvUrl(string url,int userId);
        ServiceResponse<bool> UpdateSetting(SettingUpdateDTO setting, int userId);

    }
}
