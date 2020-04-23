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
    }
}
