using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OpencvMe.Common.Constant;
using OpencvMe.Common.Helper;
using OpencvMe.DTO.AuthenticationDTO;
using OpencvMe.Service.Interface;

namespace OpencvMe.WebApi.Controller
{
    [Route("v1/authentication")]
    // [ApiController]
    public class AuthenticationV1Controller : ControllerBase
    {
        IUserService _userService;
        public AuthenticationV1Controller(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost,Route("token")]
        public TokenResponseDTO token([FromBody] TokenRequestDTO request)
        {
            var response = new TokenResponseDTO();
            var user = _userService.LoginUser(request);
            if(user != null )
            {
                var claims = new[]
                {
                    new Claim("id",user.UserId.ToString()),
                    new Claim("date",new DateTime().ToString())
                };

                var secretBytes = Encoding.UTF8.GetBytes(AuthenticationConstant.SecretKey);
                var key = new SymmetricSecurityKey(secretBytes);
                var algorithm = SecurityAlgorithms.HmacSha256;
                var signingCredentials = new SigningCredentials(key, algorithm);
                var expireDate = DateTime.Now.AddDays(30);
                var token = new JwtSecurityToken(
                    AuthenticationConstant.Issuer,
                    AuthenticationConstant.Audience,
                    claims,
                    notBefore:DateTime.Now,
                    expires: expireDate,
                    signingCredentials
                );

                response.IsLogin = true;
                response.ExpireDate = expireDate;
                response.Message = "İşlem Başarılı";
                response.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
                return response;
            }
            else {
                response.IsLogin = false;
                response.Message = "Kullanı Adı veya Şifre Hatalı";
                return response;
            }
        }
    }
}