using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpencvMe.Common.Model;
using OpencvMe.DTO.CompanyDTO;
using OpencvMe.Service.Interface;

namespace OpencvMe.WebApi.Controller
{
    [Route("v1/company")]
    [ApiController]
    public class CompanyV1Controller : ControllerBase
    {
        ICompanyService _companyService;
        public CompanyV1Controller(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet, Route("search")]
        public ApiResponse<List<CompanyResponseDTO>> SearchCompany([FromQuery]string searchText)
        {
            var response = new ApiResponse<List<CompanyResponseDTO>>();
            response.Data = _companyService.SearchCompany(searchText);
            return response.Success();
        }
        [HttpPost, Route("")]
        public ApiResponse<int> CreateCompany(CompanyCreateDTO companyRequest)
        {
            var response = new ApiResponse<int>();
            response.Data = _companyService.CreateCompany(companyRequest);
            return response.Success();
        }

    }
}