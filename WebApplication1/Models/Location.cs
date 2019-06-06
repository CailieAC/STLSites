using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSites.Models
{
    public class Location
    {
        //could make a base class to inherit from with the Id instead
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
