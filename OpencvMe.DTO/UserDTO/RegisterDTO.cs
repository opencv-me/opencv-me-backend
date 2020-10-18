using System;
using System.ComponentModel.DataAnnotations;

namespace OpencvMe.DTO.UserDTO
{
    public class RegisterDTO
    {
        public RegisterDTO()
        {

        }

        [Required, StringLength(300)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public bool IsMale { get; set; }

        [Required, StringLength(100,MinimumLength = 6)]
        public string Password { get; set; }
        public string Language { get; set; }
    }
}
