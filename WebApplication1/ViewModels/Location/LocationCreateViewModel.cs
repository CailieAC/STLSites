using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STLSites.Data;
using STLSites.Models;

namespace STLSites.ViewModels.Location
{
    public class LocationCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void Persist()
        {
            Models.Location location = new Models.Location
            {
                Name = this.Name,
                Description = this.Description,
            };
            RepositoryFactory.GetLocationRepository().Save(location);
        }
    }
}
