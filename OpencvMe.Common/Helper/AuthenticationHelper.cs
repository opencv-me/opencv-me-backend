using OpencvMe.Common.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace OpencvMe.Common.Helper
{
    public class AuthenticationHelper
    {

        public static UserClaimModel GetUserClaims(string token)
        {
          
            var data = new JwtSecurityToken(token);

            var userId = data.Payload.FirstOrDefault(x => x.Key == "id").Value.ToString();
            var model = new UserClaimModel()
            {
                UserId = Convert.ToInt32(userId)
            };

            return model;
        }
    }
}
