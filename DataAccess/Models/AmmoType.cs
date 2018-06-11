using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class AmmoType
    {
        #region Constructors

        public AmmoType() { }

        public AmmoType(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public AmmoType(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        #endregion

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
