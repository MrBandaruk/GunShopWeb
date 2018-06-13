using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GunShopWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/guns")]
    public class GunsController
    {
        private readonly ShopContext _db;

        public GunsController(ShopContext db)
        {
            _db = db;
        }

        
    }
}
