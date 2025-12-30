using System;
using System.Threading.Tasks;
using WeatherService.schema.Messages;
using WeatherService.services;

namespace WeatherService.controllers
{
    public class WeatherController
    {
        private readonly WeatherService.services.WeatherService _weatherService;

        public WeatherController(WeatherService.services.WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // Convention-based handler
        public async Task<object> WeatherRequest(WeatherRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrWhiteSpace(request.City))
                {
                    return new ErrorResponse
                    {
                        Error = "City name is required"
                    };
                }

                var weatherData = await _weatherService.GetWeatherAsync(request.City);

                return new WeatherResponse
                {
                    Weather = weatherData
                };
            }
            catch (Exception ex)
            {
                return new ErrorResponse
                {
                    Error = ex.Message
                };
            }
        }
    }
}
