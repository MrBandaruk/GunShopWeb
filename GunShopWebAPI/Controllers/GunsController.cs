using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GunShopWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/guns")]
    public class GunsController : Controller
    {
        private readonly ShopContext db;

        public GunsController(ShopContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = db.Guns.ToList();
            return new JsonResult(items);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = db.Guns.FirstOrDefault(x => x.Id == id);
            if (item is null) return new StatusCodeResult(404);

            return new JsonResult(item);
        }


        [HttpPost]
        public IActionResult Create([FromBody]Gun item)
        {
            if (!ModelState.IsValid) return new BadRequestResult();

            db.Guns.Add(item);
            db.SaveChanges();

            return new JsonResult(item);
        }

        [HttpPut]
        public IActionResult Edit([FromBody]Gun editedItem)
        {
            if (!ModelState.IsValid) return new BadRequestResult();

            var item = db.Guns.FirstOrDefault(x => x.Id == editedItem.Id);
            if (item is null) return new NotFoundResult();

            // editing item 
            item.Name = editedItem.Name;
            item.Description = editedItem.Description;

            db.SaveChanges();
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = db.Guns.FirstOrDefault(x => x.Id == id);
            if (item is null) return new NotFoundResult();

            db.Guns.Remove(item);
            db.SaveChanges();
            return new OkResult();
        }


    }
}
