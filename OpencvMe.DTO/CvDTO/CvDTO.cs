using OpencvMe.DTO.CompanyDTO;
using OpencvMe.DTO.SchoolDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpencvMe.DTO.CvDTO
{
    public class CvDTO
    {
        public int UserId { get; set; }

        [Required,StringLength(200)]
        public string CvUrl { get; set; }

        [Required,StringLength(200,MinimumLength = 2)]
        public string Name { get; set; }

        [Required,StringLength(200, MinimumLength = 2)]
        public string SurName { get; set; }

        [StringLength(1000, MinimumLength = 2)]
        public string AboutDescription { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }

        [Required,StringLength(200, MinimumLength = 2)]
        public string Location { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }
        public string BirthDayStr { get; set; }

        public bool IsPublic { get; set; }
        [StringLength(200, MinimumLength = 2)]
        public string City { get; set; }

        [StringLength(200)]
        public string Website { get; set; }

        public string ImageUrl { get; set; }
        public string ImageBase64 { get; set; }


        public SocialsDTO Socials { get; set; }
        public List<UserSchoolDTO> UserSchools { get; set; }
        public List<UserCompanyDTO> UserCompanies { get; set; }

    }
}
