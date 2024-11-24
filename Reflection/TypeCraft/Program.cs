namespace TypeCraft;

class Program
{
    static void Main()
    {
        Person person = TypeCrafter.TypeCraft<Person>();
        Console.WriteLine(person);
        Car car = TypeCrafter.TypeCraft<Car>();
        Console.WriteLine(car);
    }
}