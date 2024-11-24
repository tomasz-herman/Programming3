namespace TypeCraft;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person() {}

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString() => $"Person: {Name}({Age})";
}

public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car() {}

    public Car(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public override string ToString() => $"Car: {Make} {Model} [{Year}]";
}