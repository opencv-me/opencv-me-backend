using OpencvMe.DTO.CompanyDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.Service.Interface
{
    public interface ICompanyService
    {
      List<UserCompanyResponseDTO> GetUserCompanies(int userId);
      List<CompanyResponseDTO> SearchCompany(string searchText);
      int CreateCompany(CompanyCreateDTO company);
      bool AddUserCompanyList(List<UserCompanyCreateDTO> request, int userId);
      int AddUserCompany(UserCompanyCreateDTO request, int userId);
      bool UpdateUserCompany(UserCompanyUpdateDTO request, int userId);
      bool DeleteUserCompany(int userCompanyId);

    }
}
