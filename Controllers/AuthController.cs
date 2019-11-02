using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreSample.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace MusicStoreSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost]

        public ActionResult Post(User user)
        {
            if (user.UserName == "abc" && user.UserPassowrd == "abc1243")
            {
                string privateKeystring = "SPIL20191101BORALESGAMUWA";
                var privateKey = Encoding.ASCII.GetBytes(privateKeystring);

                var tokenDescriptor = new SecurityTokenDescriptor();
                tokenDescriptor.Audience = "spil";
                tokenDescriptor.IssuedAt = DateTime.Now;

                var claimsIdentity = new ClaimsIdentity();
                claimsIdentity.AddClaim(new Claim("name", user.UserName));
                claimsIdentity.AddClaim(new Claim("userID", "20000"));
                claimsIdentity.AddClaim(new Claim("role", "Manager"));
                tokenDescriptor.Subject = claimsIdentity;

                tokenDescriptor.Expires = DateTime.Now.AddDays(10);

                var signtaureCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(privateKey), SecurityAlgorithms.HmacSha256Signature 
                    );
                tokenDescriptor.SigningCredentials = signtaureCredentials;
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
                var gerateToekn = tokenHandler.WriteToken(token);
                return Ok(gerateToekn);
            }
            else
            {
                return Ok("User Name or password incorrect");
            }
        }
    }
}