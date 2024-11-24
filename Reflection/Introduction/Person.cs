namespace Introduction;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public int Age { get; set; }

    public Person(string firstName, string lastName, int age = 0)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public bool IsAdult()
    {
        return Age >= 18;
    }
}