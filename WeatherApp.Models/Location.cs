using System;

namespace WeatherApp.Models
{
    public class Location
    {
        public long LocationId { get; set; }
        public string Title { get; set; }
        public string LocationType { get; set; }
        public string LatLong { get; set; }
        public long WoeId { get; set; }
    }
}
