using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApp.Models;

namespace WeatherApp.DataAccessLayer
{
    public class DatabaseInitializer
    {
        public static void Initialize(WeatherAppDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            if (!dbContext.Locations.Any())
            {
                List<Location> approvalFields = new List<Location>
                {
                    new Location {Title = "London", LocationType = "City",LatLong = "51.506321,-0.12714", WoeId = 44418},
                    new Location {Title = "San Francisco", LocationType = "City",LatLong = "37.777119, -122.41964", WoeId = 2487956},
                    new Location {Title = "San Diego", LocationType = "City",LatLong = "32.715691,-117.161720", WoeId = 2487889},

                };

                approvalFields.ForEach(approvalField => dbContext.Locations.Add(approvalField));
                dbContext.SaveChanges();
            }


        }
    }
}
