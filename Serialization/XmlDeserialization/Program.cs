using System.Xml.Serialization;

namespace XmlDeserialization;

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

class Program
{
    static void Main(string[] args)
    {
        string xml = """
                     <?xml version="1.0" encoding="utf-16"?>
                     <WeatherForecast xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
                       <SummaryField>Hot</SummaryField>
                       <Date>2019-08-01T00:00:00</Date>
                       <TemperatureCelsius>25</TemperatureCelsius>
                       <Summary>Hot</Summary>
                       <DatesAvailable>
                         <dateTime>2019-08-01T00:00:00</dateTime>
                         <dateTime>2019-08-02T00:00:00</dateTime>
                       </DatesAvailable>
                       <TemperatureRanges>
                         <item>
                           <key>
                             <string>Cold</string>
                           </key>
                           <value>
                             <HighLowTemps>
                               <High>20</High>
                               <Low>-10</Low>
                             </HighLowTemps>
                           </value>
                         </item>
                         <item>
                           <key>
                             <string>Hot</string>
                           </key>
                           <value>
                             <HighLowTemps>
                               <High>60</High>
                               <Low>20</Low>
                             </HighLowTemps>
                           </value>
                         </item>
                       </TemperatureRanges>
                       <SummaryWords>
                         <string>Cool</string>
                         <string>Windy</string>
                         <string>Humid</string>
                       </SummaryWords>
                     </WeatherForecast>
                     
                     """;
        
        var stringReader = new StringReader(xml);
        var xmlSerializer = new XmlSerializer(typeof(WeatherForecast));
        WeatherForecast? wf = (WeatherForecast?)xmlSerializer.Deserialize(stringReader);

        Console.WriteLine($"Date: {wf?.Date}");
        Console.WriteLine($"TemperatureCelsius: {wf?.TemperatureCelsius}");
        Console.WriteLine($"Summary: {wf?.Summary}");
    }
}