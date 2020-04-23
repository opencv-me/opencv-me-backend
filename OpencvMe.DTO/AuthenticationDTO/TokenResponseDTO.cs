using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.DTO.AuthenticationDTO
{
   public class TokenResponseDTO
    {
        public string Message { get; set; }
        public bool IsLogin { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
