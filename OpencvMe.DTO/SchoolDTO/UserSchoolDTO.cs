using System;
using System.ComponentModel.DataAnnotations;

namespace OpencvMe.DTO.SchoolDTO
{
    public class UserSchoolDTO
    {

        public int UserId { get; set; }
        public int SchoolId { get; set; }
        [StringLength(350)]
        public string SchoolName { get; set; }
        [StringLength(200)]
        public string Section { get; set; } //okuduğu bölüm

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required]
        public bool IsContinue { get; set; }
        [Required]
        public int LicenseDegree { get; set; }

        [StringLength(350)]
        public string Description { get; set; }
        public int UserSchoolId { get; set; }
        public string StartDateStr { get; set; }
        public string EndDateStr { get; set; }

    }
}
