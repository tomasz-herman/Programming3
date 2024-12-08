using System.Numerics;

namespace StreamAdapters;

class Program
{
    static void Main(string[] args)
    {
        StreamReaderTest();
        StreamWriterTest();
        BinaryWriterTest();
        BinaryReaderTest();
    }

    static void StreamReaderTest()
    {
        using FileStream fs = File.OpenRead("lorem.txt");
        using StreamReader sr = new StreamReader(fs);

        while (sr.ReadLine() is { } line)
        {
            Console.WriteLine(line);
        }
    }
    
    static void StreamWriterTest()
    {
        using FileStream fs = File.OpenWrite("fizzbuzz.txt");
        using StreamWriter sw = new StreamWriter(fs);

        for (int i = 1; i <= 100; i++)
        {
            sw.Write($"{i} : ");
            if (i % 3 == 0 && i % 5 == 0) 
                sw.WriteLine("FizzBuzz");
            else if (i % 3 == 0) 
                sw.WriteLine("Fizz");
            else if (i % 5 == 0)
                sw.WriteLine("Buzz");
            else
                sw.WriteLine(i);
        }
    }
    
    static void BinaryReaderTest()
    {
        using FileStream fs = File.OpenRead("player.bin");
        using BinaryReader br = new BinaryReader(fs);

        string name = br.ReadString();
        int health = br.ReadInt32();
        long experience = br.ReadInt64();
        long money = br.ReadInt64();
        float posX = br.ReadSingle();
        float posY = br.ReadSingle();
        
        Player player = new Player(name, health, experience, money, new Vector2(posX, posY));
        Console.WriteLine(player);
    }

    static void BinaryWriterTest()
    {
        using FileStream fs = File.OpenWrite("player.bin");
        using BinaryWriter bw = new BinaryWriter(fs);

        Player player = new Player(
            "Bob", 
            100, 
            2500, 
            10,
            new Vector2(48.5f, 32.5f));
        
        bw.Write(player.Name);
        bw.Write(player.Health);
        bw.Write(player.Experience);
        bw.Write(player.Money);
        bw.Write(player.Position.X);
        bw.Write(player.Position.Y);
    }
}