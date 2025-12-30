using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherService.services
{
    public class WeatherService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<JsonElement> GetWeatherAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City name is required");
            }

            var encodedCity = Uri.EscapeDataString(city.Trim());
            var url = $"https://wttr.in/{encodedCity}?format=j2";

            HttpResponseMessage response;

            try
            {
                response = await _httpClient.GetAsync(url);
            }
            catch
            {
                throw new Exception("Failed to connect to weather service");
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Weather service returned an error");
            }

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new Exception("Weather service returned empty response");
            }

            try
            {
                using var document = JsonDocument.Parse(content);
                return document.RootElement.Clone();
            }
            catch
            {
                throw new Exception("Invalid weather data received");
            }
        }
    }
}
