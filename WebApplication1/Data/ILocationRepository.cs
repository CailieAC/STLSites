using STLSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSites.Data
{
    public interface ILocationRepository
    {
        Location GetById(int id);
        List<Location> GetLocations();
        int Save(Location location);
    }
}
