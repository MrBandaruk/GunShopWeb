using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace GunShopWebAPI.Models
{
    public class JwtOptions
    {
        public const string ISSUER = "GunShop";
        public const string AUDIENCE = "http://localhost:4200/";
        const string KEY = "secretkey1233!qlwkdjfsklgjlk10927836r42089jhkdjkflwejdbncqwukjdghu21pduihashgJHJHKGJKHGWJHr;ui23yfudkejhgpiu";
        public const int LIFETIME = 60;
        public static SymmetricSecurityKey SecurityKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}
