using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace AB01_02
{
    public partial class MainWindow : Window
    {
        private readonly string apiKey = "6ce2532a24db7a048acdb4cc19854e25"; // İlk API anahtar

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void FetchWeatherByCoordinatesButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(LatitudeTextBox.Text, out double latitude) &&
                double.TryParse(LongitudeTextBox.Text, out double longitude))
            {
                await FetchWeatherDataByCoordinatesAsync(latitude, longitude);
            }
            else
            {
                WeatherTextBlock.Text = "Please enter valid latitude and longitude.";
            }
        }

        private async Task FetchWeatherDataByCoordinatesAsync(double latitude, double longitude)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        JObject weatherData = JObject.Parse(jsonResponse);

                        string cityName = weatherData["name"]?.ToString() ?? "Unknown location";
                        string description = weatherData["weather"]?[0]?["description"]?.ToString() ?? "No description available";
                        string temperature = weatherData["main"]?["temp"]?.ToString() ?? "N/A";
                        string feelsLike = weatherData["main"]?["feels_like"]?.ToString() ?? "N/A";
                        string humidity = weatherData["main"]?["humidity"]?.ToString() ?? "N/A";
                        string windSpeed = weatherData["wind"]?["speed"]?.ToString() ?? "N/A";

                        WeatherTextBlock.Text = $"Location: {cityName}\n" +
                                                $"Description: {description}\n" +
                                                $"Temperature: {temperature}°C\n" +
                                                $"Feels Like: {feelsLike}°C\n" +
                                                $"Humidity: {humidity}%\n" +
                                                $"Wind Speed: {windSpeed} m/s";
                    }
                    else
                    {
                        WeatherTextBlock.Text = $"Unable to fetch weather data. API Response: {response.StatusCode}";
                    }
                }
            }
            catch (Exception ex)
            {
                WeatherTextBlock.Text = $"Error occurred: {ex.Message}";
            }
        }
    }
}
