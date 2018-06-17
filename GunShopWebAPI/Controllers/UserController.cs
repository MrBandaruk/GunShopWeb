using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess;
using GunShopWebAPI.Helpers;
using GunShopWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GunShopWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly ShopContext db;

        public UserController(ShopContext db)
        {
            this.db = db;
        }

        [Route("token"), HttpPost, AllowAnonymous]
        public IActionResult Token([FromBody]Login user)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();

            var identity = GetIdentity(user.Username, user.Password);

            if (identity is null)
                return new UnauthorizedResult();


            var jwt = new JwtSecurityToken(
                issuer: JwtOptions.ISSUER,
                audience: JwtOptions.AUDIENCE,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(JwtOptions.LIFETIME),
                claims: identity.Claims,
                signingCredentials: new SigningCredentials(JwtOptions.SecurityKey, SecurityAlgorithms.HmacSha256)
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JsonResult(encodedJwt);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var hashProvider = new Md5Hasher();
            password = hashProvider.GetMd5Hash(password);

            var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user is null)
                return null;

            var claims = new List<Claim>
            {
                new Claim("name", username),
                new Claim("role", "admin")
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "token",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}