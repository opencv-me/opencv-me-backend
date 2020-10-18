using System;
using System.ComponentModel.DataAnnotations;

namespace OpencvMe.DTO.UserDTO
{
    public class UpdatePasswordDTO
    {
        [Required,StringLength(200,MinimumLength =6)]
        public string Password { get; set; }
        public string RePassword { get; set; }

    }
}
