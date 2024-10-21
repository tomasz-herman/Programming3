namespace Classes;

class Program
{
    static void Main(string[] args)
    {
        Person alice = new Person("Alice", "Smith", 25);
        Person bob = new Person("Bob", "Johnson", 16);
        Person charlie = new Person("Charlie", "Brown");
        
        alice.Introduce();
        bob.Introduce();
        charlie.Introduce();

        Console.WriteLine($"{alice.FullName} is of legal age: {alice.IsLegalAge()}");
        Console.WriteLine($"{bob.FullName} is of legal age: {bob.IsLegalAge()}");
        Console.WriteLine($"{charlie.FullName} is of legal age: {charlie.IsLegalAge()}");

        alice.Friends.Add(charlie);
        bob.Friends.Add(alice);

        Console.WriteLine($"Friends of {alice.FullName}:");
        foreach (var friend in alice.Friends)
        {
            Console.WriteLine(friend.FullName);
        }
        
        Console.WriteLine($"Friends of {bob.FullName}:");
        foreach (var friend in bob.Friends)
        {
            Console.WriteLine(friend.FullName);
        }

        (var aliceFullName, var aliceAge) = alice;
        var (bobFullName, bobAge) = bob;
        charlie.Deconstruct(out var charlieFullName, out var charlieAge);

        Hamster hamster = new Hamster { Name = "Boo", Level = 20 };
        hamster.Bar();
    }
}