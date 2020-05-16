using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.DTO.SchoolDTO
{
    public class UserSchoolResponseDTO
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string Section { get; set; } //okuduğu bölüm
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsContinue { get; set; }
        public int licenseDegree { get; set; }
        public string Description { get; set; }
        public string StartDateStr { get; set; }
        public string EndDateStr { get; set; }
        public int UserSchoolId { get; set; }
    }
}
