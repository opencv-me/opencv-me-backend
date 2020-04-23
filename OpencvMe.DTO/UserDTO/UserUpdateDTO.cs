using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.DTO.UserDTO
{
    public class UserUpdateDTO
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsMale { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
