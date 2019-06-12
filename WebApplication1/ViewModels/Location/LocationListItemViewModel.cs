using STLSites.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSites.ViewModels.Location
{
    public class LocationListItemViewModel
    {
        public static List<LocationListItemViewModel> GetLocationList()
        {
            return RepositoryFactory.GetLocationRepository()
                .GetModels()
                .Cast<Models.Location>()
                .Select(location => GetLocationListItemFromLocation(location))
                .ToList();
        }

        private static LocationListItemViewModel GetLocationListItemFromLocation(Models.Location location)
        {
            return new LocationListItemViewModel
            {
                Id = location.Id,
                Name = location.Name,
                Description = location.Description,
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
