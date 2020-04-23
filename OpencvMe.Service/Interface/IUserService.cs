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
        int RegisterUser(UserCreateDTO userRequest);
        UserResponseDTO GetUserInformation(int id);
        CvResponseDTO GetUserCv(string url);
        UserResponseDTO LoginUser(TokenRequestDTO request);
        int CreateCv(CvCreateDTO cvReques);
        bool UpdateCv(CvUpdateDTO cvReques);

        bool CheckCvUrl(string url);
    }
}
