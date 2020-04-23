using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.DTO.AuthenticationDTO
{
   public class TokenRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
