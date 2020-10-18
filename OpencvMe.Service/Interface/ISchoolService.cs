using OpencvMe.Common.Model;
using OpencvMe.DTO.SchoolDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.Service.Interface
{
    public interface ISchoolService
    {
        ServiceResponse<List<UserSchoolDTO>> GetUserSchools(int userId);
        ServiceResponse<List<SchoolDTO>> SearchSchool(string searchText);
        ServiceResponse<int> CreateSchool(string schoolName);
        ServiceResponse<bool> AddUserSchoolList(List<UserSchoolDTO> request, int userId);
        ServiceResponse<int> AddUserSchool(UserSchoolDTO request,int userId);
        ServiceResponse<bool> UpdateUserSchool(UserSchoolDTO request, int userId);
        ServiceResponse<bool> DeleteUserSchool(int userSchoolId);
    }
}
