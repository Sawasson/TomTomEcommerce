using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TomTomEcommerce.Core;

namespace TomTomEcommerce.EFCore
{
    public class TTLocationService
    {
        private TTContext dbContext { get; set; }

        public TTLocationService(TTContext tTContext)
        {
            this.dbContext = tTContext;
        }

        public List<City> GetCities()
        {
            return dbContext.Cities.ToList();
        }

        public List<District> GetDistrictsByCityId(int cityId)
        {

            return dbContext.Districts.Where(d => d.CityId == cityId).ToList();
        }
    }
}
