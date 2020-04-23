using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.DTO.UserDTO
{
    public class UserCreateDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsMale { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }
    }
}
