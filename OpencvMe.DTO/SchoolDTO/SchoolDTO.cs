using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpencvMe.DTO.SchoolDTO
{
    public class SchoolDTO
    {
        // public int UserSchoolI { get; set; }
        public int SchoolId { get; set; }

        [StringLength(350)]
        public string SchoolName { get; set; }
    }
}
