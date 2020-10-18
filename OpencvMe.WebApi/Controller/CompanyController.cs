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
         public ServiceResponse<List<CompanyDTO>> SearchCompany([FromQuery]string searchText)
         {
             var response = new ServiceResponse<List<CompanyDTO>>();
             var companyServiceResponse = _companyService.SearchCompany(searchText);
        
             response.Data = companyServiceResponse.Data;
             response.Message = companyServiceResponse.Message;
             response.IsSuccess = companyServiceResponse.IsSuccess;
             return response;
        
         }

    }
}