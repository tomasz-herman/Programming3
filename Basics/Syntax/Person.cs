// Namespaces follows PascalCase convention
namespace Syntax;

// Classes and Structs also follows PascalCase convention
public class Person
{
    // Private field follows '_camelCase' convention
    private string _firstName;
    private string _lastName;

    // Properties follow PascalCase
    public int Age { get; private set; }
    public string Name => $"{_firstName} {_lastName}";

    public Person(string firstName, string lastName, int age)
    {
        _firstName = firstName;
        _lastName = lastName;
        Age = age;
    }

    // All methods follow PascalCase convention
    public void DisplayPersonInfo()
    {
        // Private fields use '_camelCase', locals use 'camelCase'
        string fullName = Name;
        Console.WriteLine($"Full Name: {fullName}");
        Console.WriteLine($"Age: {Age}");
    }

    // Private method as well
    private bool IsAdult(int legalAge = 18)
    {
        return Age >= legalAge;
    }

    public void DisplayAdultStatus()
    {
        bool adultStatus = IsAdult();
        string adultMessage = adultStatus ? "an adult." : "not an adult.";
        Console.WriteLine($"{_firstName} {_lastName} is {adultMessage}");
    }
}