using System;
using System.Collections.Generic;

namespace WeatherApp.Dtos
{
    public class WeatherUpdateResultDto
    {
        public string title { get; set; }
        public string location_type { get; set; }
        public string latt_long { get; set; }
        public DateTime time { get; set; }
        public string timezone_name { get; set; }
        public DateTime sun_rise { get; set; }
        public DateTime sun_set { get; set; }

        public parent parent { get; set; }
        public List<consolidated_weather> consolidated_weather { get; set; }
        public List<source> sources { get; set; }
    }

    public class parent
    {
        public string title { get; set; }
        public string location_type { get; set; }
        public string latt_long { get; set; }
        public int woeid { get; set; }
    }

    public class consolidated_weather
    {
        public long id { get; set; }
        public DateTime applicable_date { get; set; }
        public string weather_state_name { get; set; }
        public string weather_state_abbr { get; set; }
        public float wind_speed { get; set; }
        public float wind_direction { get; set; }
        public string wind_direction_compass { get; set; }

        public float min_temp { get; set; }
        public float max_temp { get; set; }
        public float the_temp { get; set; }
        public float air_pressure { get; set; }
        public float humidity { get; set; }
        public float visibility { get; set; }
        public int predictability { get; set; }
    }

    public class source
    {
        public string title { get; set; }
        public string url { get; set; }
    }
}
