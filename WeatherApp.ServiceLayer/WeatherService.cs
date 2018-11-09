using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WeatherApp.DataAccessLayer;
using WeatherApp.Dtos;
using WeatherApp.Models;

namespace WeatherApp.ServiceLayer
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherAppDbContext _dbContext;
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherService(WeatherAppDbContext dbContext, IHttpClientFactory httpClientFactory)
        {
            _dbContext = dbContext;
            _httpClientFactory = httpClientFactory;
        }

        public async Task UpdateWeatherAsync()
        {
            var woEidList = await _dbContext.Locations.Select(l => Tuple.Create(l.LocationId, l.WoeId)).ToListAsync();

            var client = _httpClientFactory.CreateClient();
            foreach (Tuple<long, long> tuple in woEidList)
            {
                var result = await client.GetStringAsync("https://www.metaweather.com/api/location/" + tuple.Item2);
                var weatherUpdateDto = JsonConvert.DeserializeObject<WeatherUpdateResultDto>(result);

                foreach (var consolidatedWeather in weatherUpdateDto.consolidated_weather)
                {
                    WeatherUpdate weatherUpdate = new WeatherUpdate()
                    {
                        LocationId = tuple.Item1,
                        ApplicableDate = consolidatedWeather.applicable_date,
                        WeatherStateName = consolidatedWeather.weather_state_name,
                        WeatherStateAbbr = consolidatedWeather.weather_state_abbr,
                        WindSpeed = consolidatedWeather.wind_speed,
                        WindDirection = consolidatedWeather.wind_direction,
                        WindDirectionCompass = consolidatedWeather.wind_direction_compass,
                        MinTemp = consolidatedWeather.min_temp,
                        MaxTemp = consolidatedWeather.max_temp,
                        CurrentTemp = consolidatedWeather.the_temp,
                        AirPressure = consolidatedWeather.air_pressure,
                        Humidity = consolidatedWeather.humidity,
                        Visibility = consolidatedWeather.visibility,
                        Predictability = consolidatedWeather.predictability
                    };

                    _dbContext.WeatherUpdates.Add(weatherUpdate);
                }

                LatestUpdate latestWeatherToBeUpdated = await _dbContext.LatestUpdates.FirstOrDefaultAsync(lu => lu.LocationId == tuple.Item1);
                consolidated_weather latestUpdate = weatherUpdateDto.consolidated_weather.OrderBy(cw => cw.applicable_date).FirstOrDefault();
                if (latestUpdate != null)
                {
                    if (latestWeatherToBeUpdated != null)
                    {
                        _dbContext.Entry(latestWeatherToBeUpdated).State = EntityState.Modified;
                    }
                    else
                    {
                        latestWeatherToBeUpdated = new LatestUpdate();
                        latestWeatherToBeUpdated.LocationId = tuple.Item1;
                        _dbContext.LatestUpdates.Add(latestWeatherToBeUpdated);
                    }

                    latestWeatherToBeUpdated.ApplicableDate = latestUpdate.applicable_date;
                    latestWeatherToBeUpdated.WeatherStateName = latestUpdate.weather_state_name;
                    latestWeatherToBeUpdated.WeatherStateAbbr = latestUpdate.weather_state_abbr;
                    latestWeatherToBeUpdated.WindSpeed = latestUpdate.wind_speed;
                    latestWeatherToBeUpdated.WindDirection = latestUpdate.wind_direction;
                    latestWeatherToBeUpdated.WindDirectionCompass = latestUpdate.wind_direction_compass;
                    latestWeatherToBeUpdated.MinTemp = latestUpdate.min_temp;
                    latestWeatherToBeUpdated.MaxTemp = latestUpdate.max_temp;
                    latestWeatherToBeUpdated.CurrentTemp = latestUpdate.the_temp;
                    latestWeatherToBeUpdated.AirPressure = latestUpdate.air_pressure;
                    latestWeatherToBeUpdated.Humidity = latestUpdate.humidity;
                    latestWeatherToBeUpdated.Visibility = latestUpdate.visibility;
                    latestWeatherToBeUpdated.Predictability = latestUpdate.predictability;
                }

            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
