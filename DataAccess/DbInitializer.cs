using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;

namespace DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(ShopContext db)
        {
            db.Database.EnsureCreated();

            if(db.Guns.Any()) return;

            var pistolType = new Type("Pistol", "Simple pistol");
            var rifleType = new Type("Rifle", "Good rifle");
            var shotgunType = new Type("Shotgun", "Nice shotgun");
            db.Types.AddRange(pistolType, rifleType, shotgunType);
            db.SaveChanges();




            db.Guns.AddRange(new List<Gun>
            {
                new Gun
                {

                },
            });
        }
        // add some code here
    }
}
