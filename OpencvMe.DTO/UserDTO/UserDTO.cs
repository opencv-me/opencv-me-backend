using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpencvMe.DTO.UserDTO
{
    public class UserDTO
    {

        public int UserId { get; set; }
        [Required,StringLength(350,MinimumLength = 2)]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        public bool IsMale { get; set; }
        public bool IsCvCreated { get; set; }
        public DateTime? BirthDate { get; set; }
        public CvDTO.CvDTO? Cv { get; set; }

        [Required,StringLength(200,MinimumLength = 6)]
        public string Password { get; set; }

        public string Language { get; set; }

    }
}
