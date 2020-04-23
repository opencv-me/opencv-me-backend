using Microsoft.AspNetCore.Mvc;
using OpencvMe.Common.Helper;
using OpencvMe.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpencvMe.WebApi.Base
{
    public class OpenCvBaseController : ControllerBase
    {

        public string GetBearerToken ()
        {
            var token = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if(!string.IsNullOrEmpty(token.ToString()))
            {
                token = token.ToString().Split(' ')[1];
            }
            return token.ToString();
        }
        public UserClaimModel GetUserClaims()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "id").Value;
            var model = new UserClaimModel()
            {
                UserId = Convert.ToInt32(userId)
            };

            return model;
        }
    }
}
