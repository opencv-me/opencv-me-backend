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
        public ServiceResponse<List<SchoolDTO>> SearchSchool([FromQuery]string searchText)
        {
            var response = new ApiResponse<List<SchoolDTO>>();
            return _schoolService.SearchSchool(searchText);
        }

    }
}