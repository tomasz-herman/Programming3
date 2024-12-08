using System.Xml.Serialization;

namespace XmlSerialization;

public class WeatherForecast
{
    public DateTime Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string? Summary { get; set; }
    public string? SummaryField;
    public List<DateTime>? DatesAvailable { get; set; }
    public SerializableDictionary<string, HighLowTemps>? TemperatureRanges { get; set; }
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
        var weatherForecast = new WeatherForecast
        {
            Date = DateTime.Parse("2019-08-01"),
            TemperatureCelsius = 25,
            Summary = "Hot",
            SummaryField = "Hot",
            DatesAvailable = new List<DateTime>() 
                { DateTime.Parse("2019-08-01"), DateTime.Parse("2019-08-02") },
            TemperatureRanges = new SerializableDictionary<string, HighLowTemps>
            {
                ["Cold"] = new HighLowTemps { High = 20, Low = -10 },
                ["Hot"] = new HighLowTemps { High = 60 , Low = 20 }
            },
            SummaryWords = new[] { "Cool", "Windy", "Humid" }
        };

        var stringWriter = new StringWriter();
        var xmlSerializer = new XmlSerializer(typeof(WeatherForecast));
        xmlSerializer.Serialize(stringWriter, weatherForecast);

        Console.WriteLine(stringWriter.ToString());
    }
}