using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.DTO.SchoolDTO
{
    public class UserSchoolResponseDTO
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsContinue { get; set; }
        public string DiplomaPoint { get; set; }
        public string Description { get; set; }
    }
}
