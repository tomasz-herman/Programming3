using System.Globalization;
using System.Runtime.CompilerServices;

namespace Exceptions;

public class Program
{
    public static void Main()
    {
        CatchingExceptions();
        ThrowingExceptions();
        ExceptionFilters();
        FinallyBlock();
    }

    private static void CatchingExceptions()
    {
        PrintCurrentMethodName();
        string input = "2137";
        try
        {
            byte b = byte.Parse(input, CultureInfo.InvariantCulture);
            Console.WriteLine(b);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Input is null");
        }
        catch (FormatException e)
        {
            Console.WriteLine(e);
        }
        catch (OverflowException)
        {
            Console.WriteLine("More than a byte");
        }
    }
    
    public static void ThrowingExceptions()
    {
        PrintCurrentMethodName();
        try
        {
            ValidateInput("Hello, world", 16);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static void ValidateInput(string input, int maxLength)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(nameof(input), "Input cannot be null or empty.");
        }

        if (input.Length > maxLength)
        {
            throw new ArgumentOutOfRangeException(nameof(input), 
                $"Input exceeds the maximum length of {maxLength} characters.");
        }

        Console.WriteLine("Input is valid.");
    }

    private static void ExceptionFilters()
    {
        PrintCurrentMethodName();
        try
        {
            throw new HttpRequestException(
                "Resource not found", 
                null, 
                System.Net.HttpStatusCode.NotFound);
        }
        catch (HttpRequestException ex) when 
            (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Console.WriteLine("Resource not found.");
            Console.WriteLine(ex);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static void FinallyBlock()
    {
        PrintCurrentMethodName();
        string tempFilePath = Path.GetTempFileName();
        try
        {
            Console.WriteLine($"Temporary file created: {tempFilePath}");
            File.WriteAllText(tempFilePath, "Temporary content.");
        }
        finally
        {
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
                Console.WriteLine("Temporary file deleted.");
            }
        }
    }
    
    private static void PrintCurrentMethodName([CallerMemberName] string caller = "")
    {
        Console.WriteLine("***************************************");
        Console.WriteLine($"* Method: {caller,27} *");
        Console.WriteLine("***************************************");
    }
}