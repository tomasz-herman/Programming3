namespace Set;

class Program
{
    static void Main(string[] args)
    {
        var letters = new HashSet<char>("the quick brown fox");
        Console.WriteLine(letters.Contains('t')); // true
        Console.WriteLine(letters.Contains('j')); // false

        foreach (char c in letters) Console.Write(c); // the quickbrownfx
        
        letters.ExceptWith("aeiou");
        foreach (char c in letters) Console.Write(c); // th qckbrwnfx
    }
}