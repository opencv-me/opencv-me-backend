using System;
using System.ComponentModel.DataAnnotations;

namespace OpencvMe.DTO.UserDTO
{
    public class SettingUpdateDTO
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        public bool IsPublic { get; set; }
        public bool IsMale { get; set; }
        public bool IsActive { get; set; }
        [Required,StringLength(350)]
        public string FullName { get; set; }
    }

}
