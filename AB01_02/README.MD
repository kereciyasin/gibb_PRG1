# 🌦️ **Weather App** (WPF - OpenWeatherMap API)

## 🚀 About the Project
This project uses the **OpenWeatherMap API** to provide weather data for a given location. Users can input **latitude** and **longitude** values, and the app will fetch the weather information for those coordinates. 

The app displays key weather details such as temperature, humidity, and wind speed in a user-friendly interface built using **WPF (Windows Presentation Foundation)**.

---

## 🛠️ Technologies Used
- **C#**: The primary programming language used for the app.
- **WPF (Windows Presentation Foundation)**: Used for designing the graphical user interface (GUI).
- **OpenWeatherMap API**: Provides the weather data based on latitude and longitude.
- **Newtonsoft.Json**: A popular library used to parse JSON data from the API response.

---

## 🌟 Features
- Users can directly input **latitude** and **longitude** to get weather data for that specific location.
- The app retrieves weather data from the **OpenWeatherMap API** and displays it, including information like temperature, humidity, and wind speed.
- The data is parsed from **JSON** format and shown in an easy-to-understand format.
- **Error handling**: In case of invalid coordinates or API connection errors, users are shown relevant error messages.

---

## 🏁 Getting Started

### 📦 Prerequisites
Before running the project, make sure you have the following:
- **Visual Studio** or any other C#-compatible IDE
- **.NET Framework 4.5 or later**
- **OpenWeatherMap API key**: You will need a valid API key from [OpenWeatherMap](https://openweathermap.org/api) to fetch weather data.

### 🔧 Installation Steps

1. **Clone the Project**:
   ```bash
   git clone <repo_url>

### 🔑 Add Your API Key

- To retrieve weather data, you need to add your OpenWeatherMap API key.

1. Go to OpenWeatherMap and sign up for a free API key.
2. Once you have your API key, open the MainWindow.xaml.cs file in your project.
3. Locate the following line in the code:
 ```bash
   private readonly string apiKey = "YOUR_API_KEY"; // Replace with your OpenWeatherMap API key.

