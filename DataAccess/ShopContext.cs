using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ShopContext : DbContext
    {
        public DbSet<Gun> Guns { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<AmmoType> AmmoTypes { get; set; }


        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        { }


    }
}
