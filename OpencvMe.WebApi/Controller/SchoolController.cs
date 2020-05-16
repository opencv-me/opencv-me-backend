using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpencvMe.Common.Model;
using OpencvMe.DTO.SchoolDTO;
using OpencvMe.Service.Interface;

namespace OpencvMe.WebApi.Controller
{
    [Route("v1/school")]
    [ApiController]
    public class SchoolV1Controller : ControllerBase
    {
        ISchoolService _schoolService;
        public SchoolV1Controller(ISchoolService schoolService)
        {
            _schoolService = schoolService;

        }
        [HttpGet,Route("search")]
        public ApiResponse<List<SchoolResponseDTO>> SearchSchool([FromQuery]string searchText)
        {
            var response = new ApiResponse<List<SchoolResponseDTO>>();
            response.Data = _schoolService.SearchSchool(searchText);
            return response.Success();
        }
        [HttpPost, Route("")]
        public ApiResponse<SchoolResponseDTO> CreateSchool(SchoolCreateDTO schoolRequest)
        {
            var response = new ApiResponse<SchoolResponseDTO>();
            response.Data = new SchoolResponseDTO();
            response.Data.SchoolId = _schoolService.CreateSchool(schoolRequest);
            response.Data.SchoolName = schoolRequest.Name;
            return response.Success();
        }

    }
}