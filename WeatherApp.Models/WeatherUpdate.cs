using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Models
{
    public class WeatherUpdate
    {
        public long WeatherUpdateId { get; set; }

        [ForeignKey("Location")]
        public long LocationId { get; set; }
        public DateTime ApplicableDate { get; set; }
        public string WeatherStateName { get; set; }
        public string WeatherStateAbbr { get; set; }
        public float WindSpeed { get; set; }
        public float WindDirection { get; set; }
        public string WindDirectionCompass { get; set; }
        public float MinTemp { get; set; }
        public float MaxTemp { get; set; }
        public float CurrentTemp { get; set; }
        public float AirPressure { get; set; }
        public float Humidity { get; set; }
        public float Visibility { get; set; }
        public float Predictability { get; set; }

        public Location Location { get; set; }
    }
}
