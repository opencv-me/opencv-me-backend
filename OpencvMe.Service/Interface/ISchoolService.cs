using OpencvMe.DTO.SchoolDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.Service.Interface
{
    public interface ISchoolService
    {
        List<UserSchoolResponseDTO> GetUserSchools(int userId);
        List<SchoolResponseDTO> SearchSchool(string searchText);
        int CreateSchool(SchoolCreateDTO schoolRequest);
        bool AddUserSchoolList(List<UserSchoolCreateDTO> request, int userId);
        int AddUserSchool(UserSchoolCreateDTO request,int userId);
        bool UpdateUserSchool(UserSchoolUpdateDTO request, int userId);
        bool DeleteUserSchool(int userSchoolId);
    }
}
