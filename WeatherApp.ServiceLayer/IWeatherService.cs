using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.ServiceLayer
{
    public interface IWeatherService
    {
        Task UpdateWeatherAsync();
    }
}
