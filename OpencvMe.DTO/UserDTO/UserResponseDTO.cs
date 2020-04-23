using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.DTO.UserDTO
{
    public class UserResponseDTO
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string IsMale { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
