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

            var pistolAmmo = new AmmoType("9mm", "Ammo for pistols");
            var rifleAmmo = new AmmoType("7.62×39mm", "Ammo for rifles");
            var shotgunAmmo = new AmmoType(".410 bore", "Ammo for shotguns");
            db.AmmoTypes.AddRange(pistolAmmo, rifleAmmo, shotgunAmmo);
            db.SaveChanges();

            db.Guns.AddRange(new List<Gun>
            {
                new Gun
                {
                    Name = "Glock",
                    Model = "18",
                    AmmoTypeId = pistolAmmo.Id,
                    TypeId = pistolType.Id,
                    Description = "The Glock pistol is a series of polymer-framed, short recoil-operated, " +
                                  "locked-breech semi-automatic pistols designed and produced by Austrian" +
                                  " Glock Ges.m.b.H.. It entered Austrian military and police service by " +
                                  "1982 after it was the top performer in reliability and safety tests.",
                    Year = 1999,
                    Photo = "https://www.armurerie-steflo-lyon.com/2667-large_default/glock-43-9x19.jpg"
                },
                new Gun
                {
                    Name = "AK",
                    Model = "47",
                    AmmoTypeId = rifleAmmo.Id,
                    TypeId = rifleType.Id,
                    Description = "Design work on the AK-47 began in 1945. In 1946, the AK-47 was presented for " +
                                  "official military trials, and in 1948, the fixed-stock version was introduced " +
                                  "into active service with selected units of the Soviet Army. An early development " +
                                  "of the design was the AKS (S—Skladnoy or 'folding'), which was equipped with an " +
                                  "underfolding metal shoulder stock. In early 1949, the AK-47 was officially accepted " +
                                  "by the Soviet Armed Forces[8] and used by the majority of the member states of the Warsaw Pact.",
                    Year = 1949,
                    Photo = "https://ii.cheaperthandirt.com/fcgi-bin/iipsrv.fcgi?FIF=/images/cheaperthandirt/source/2-cari2399-n_1.tif&wid=575&cvt=jpeg"
                },
                new Gun
                {
                    Name = "Remington",
                    Model = "870",
                    AmmoTypeId = shotgunAmmo.Id,
                    TypeId = shotgunType.Id,
                    Description = "The Remington Model 870 is a pump-action shotgun manufactured by Remington Arms Company, " +
                                  "LLC. It is widely used by the public for sport shooting, hunting, and self-defense and " +
                                  "used by law enforcement and military organizations worldwide.",
                    Year = 1950,
                    Photo = "https://www.remington.com/sites/all/themes/remington2016/technology/img/product-tech-slider/shotgun/Model870-Wingmaster.jpg"
                }
            });

            db.SaveChanges();
        }
    }
}
