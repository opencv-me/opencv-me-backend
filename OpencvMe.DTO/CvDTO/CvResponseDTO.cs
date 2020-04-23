using OpencvMe.DTO.CompanyDTO;
using OpencvMe.DTO.SchoolDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.DTO.CvDTO
{
    public class CvResponseDTO
    {
        public List<UserSchoolResponseDTO> Schools { get; set; }
        public List<UserCompanyResponseDTO> Companies { get; set; }

        public int UserId { get; set; }
        public string CvUrl { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string AboutDescription { get; set; }

        public string Email { get; set; }
        public string Location { get; set; }
        public DateTime BirthDay { get; set; }

        // socials
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Medium { get; set; }

        public bool IsPublic { get; set; }



    }
}
