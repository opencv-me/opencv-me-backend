using OpencvMe.Common.Model;
using OpencvMe.DTO.CompanyDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.Service.Interface
{
    public interface ICompanyService
    {
      ServiceResponse<List<UserCompanyDTO>> GetUserCompanies(int userId);
      ServiceResponse<List<CompanyDTO>> SearchCompany(string searchText);
      ServiceResponse<int> CreateCompany(string companyName);
      ServiceResponse<bool> AddUserCompanyList(List<UserCompanyDTO> request, int userId);
      ServiceResponse<int> AddUserCompany(UserCompanyDTO request, int userId);
      ServiceResponse<bool> UpdateUserCompany(UserCompanyDTO request, int userId);
      ServiceResponse<bool> DeleteUserCompany(int userCompanyId);

    }
}
