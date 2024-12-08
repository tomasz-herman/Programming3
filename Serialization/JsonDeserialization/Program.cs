using System.Text.Json;

namespace JsonDeserialization;

public class WeatherForecast
{
    public DateTime Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string? Summary { get; set; }
    public string? SummaryField;
    public IList<DateTime>? DatesAvailable { get; set; }
    public Dictionary<string, HighLowTemps>? TemperatureRanges { get; set; }
    public string[]? SummaryWords { get; set; }
}

public class HighLowTemps
{
    public int High { get; set; }
    public int Low { get; set; }
}

public class Program
{
    public static void Main()
    {
        string jsonString =
            """
            {
              "Date": 1564617600,
              "TemperatureCelsius": 25,
              "Summary": "Hot",
              "DatesAvailable": [
                1564617600,
                1564704000
              ],
              "TemperatureRanges": {
                "Cold": {
                  "High": 20,
                  "Low": -10
                },
                "Hot": {
                  "High": 60,
                  "Low": 20
                }
              },
              "SummaryWords": [
                "Cool",
                "Windy",
                "Humid"
              ]
            }
            """;

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.Converters.Add(new UnixTimestampConverter());
        WeatherForecast? weatherForecast = 
            JsonSerializer.Deserialize<WeatherForecast>(jsonString, options);

        Console.WriteLine($"Date: {weatherForecast?.Date}");
        Console.WriteLine($"TemperatureCelsius: {weatherForecast?.TemperatureCelsius}");
        Console.WriteLine($"Summary: {weatherForecast?.Summary}");
    }
}