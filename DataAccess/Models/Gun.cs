using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Gun
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }

        public int TypeId { get; set; }
        public Type Type { get; set; }

        public int AmmoTypeId { get; set; }
        public AmmoType AmmoType { get; set; }

        // TODO: Change in future
        public string Photo { get; set; }
    }
}
