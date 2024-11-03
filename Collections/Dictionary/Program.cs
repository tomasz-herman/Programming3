namespace Dictionary;

class Program
{
    private const string LoremIpsum =
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque et libero tempus, iaculis elit vitae, viverra arcu. Curabitur id viverra magna. Sed viverra pulvinar nisi, vestibulum volutpat massa accumsan ut. Sed lorem nisl, laoreet vel elit et, vestibulum gravida mi. Phasellus pretium ut sem et condimentum. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Integer nec pellentesque odio. Ut lobortis lobortis ligula, commodo dignissim est aliquet vestibulum. Aliquam finibus, elit scelerisque finibus lobortis, magna orci volutpat ipsum, sed dapibus odio nibh sed mi. Nullam nec lectus imperdiet erat maximus tempus id quis tellus. Nulla tincidunt ut justo sit amet dapibus. Nam sollicitudin accumsan urna, quis mattis nisl commodo in. Pellentesque volutpat ipsum dolor, at feugiat dolor ullamcorper sit amet.\n\nNulla faucibus in nunc eu interdum. Vestibulum vitae mi eu felis ornare efficitur. Nunc id nisl malesuada, consequat quam ut, consequat nisi. Cras elit tellus, posuere nec scelerisque id, euismod nec lacus. Donec ac elit in dolor tempor suscipit. Donec ornare aliquam justo non tincidunt. Morbi maximus lacus id elit laoreet tincidunt. Proin lacinia, velit eget pharetra commodo, tortor elit condimentum mauris, vitae maximus dui diam eu velit.\n\nVestibulum suscipit iaculis nisi, a eleifend sem blandit et. Donec imperdiet augue non dui ultrices suscipit. Nam id facilisis ipsum. Integer sit amet mauris lorem. Integer porta elit sed tellus laoreet, ut tempor ex commodo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed pharetra ornare nibh et laoreet. Curabitur sit amet massa sed diam ullamcorper sollicitudin.\n\nSed nec ante ac nunc suscipit viverra quis ut est. Pellentesque tortor ipsum, tempus quis orci at, tincidunt ornare dolor. Fusce sollicitudin dui quis arcu consectetur, ut luctus tellus condimentum. Mauris at egestas ante, a pharetra felis. Sed ut faucibus libero. Etiam egestas dolor nec massa porta, eu sagittis odio iaculis. Donec non elit nec lectus sodales finibus. Suspendisse laoreet aliquet congue. Mauris eget nisl sit amet urna molestie scelerisque. Ut mattis mi augue, sit amet condimentum felis bibendum vestibulum. Nulla tristique risus eu dui pellentesque maximus. Suspendisse pellentesque velit quis aliquet rhoncus.\n\nMauris iaculis sapien eget ultricies vulputate. Vivamus cursus turpis et volutpat fringilla. Mauris ac ante enim. Ut sodales lacus dictum arcu consectetur sodales. Integer fermentum vehicula nisl, euismod ullamcorper arcu ultrices vel. Donec efficitur justo eget mauris sagittis, porta imperdiet risus tincidunt. Suspendisse potenti. Praesent pulvinar mi ut metus rutrum, in fringilla leo convallis. Nunc sit amet porttitor purus, in maximus velit. Vivamus viverra, purus sit amet tincidunt pellentesque, mauris velit tristique lorem, et euismod nibh leo non erat. Nullam vel lorem sed ante scelerisque venenatis finibus at leo. Cras id sapien lectus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Pellentesque vitae rhoncus lectus. Donec molestie mi in libero fringilla aliquam. ";
    
    static void Main(string[] args)
    {
        var d = new Dictionary<string, int>();
        d.Add("One", 1);
        d["Two"] = 2; // adds to dictionary because "two" isn't already present
        d["Two"] = 22; // updates dictionary because "two" is now present
        d["Three"] = 3;
        
        // Using object initializer:
        d = new Dictionary<string, int>
        {
            ["One"] = 1,
            ["Two"] = 2,
            ["Three"] = 3
        };

        Console.WriteLine(d["Two"]);             // Prints "22"
        Console.WriteLine(d.ContainsKey ("One"));// true (fast operation)
        Console.WriteLine(d.ContainsValue (3));  // true (slow operation)
        if (!d.TryGetValue("Four", out int val)) // "No val"
            Console.WriteLine ("No val");

// Three different ways to enumerate the dictionary:
        foreach (KeyValuePair<string, int> kv in d)
            Console.WriteLine (kv.Key + "; " + kv.Value);
        // One; 1
        // Two; 22
        // Three; 3
        
        foreach (string s in d.Keys) Console.Write (s); // OneTwoThree
        Console.WriteLine();
        foreach (int i in d.Values) Console.Write(i);         // 1223

        
        Dictionary<string, int> wordCounts = CountWordOccurrences(ToWords(LoremIpsum));
        foreach (var wordCount in wordCounts)
        {
            Console.WriteLine($"{wordCount.Key}: {wordCount.Value}");
        }
    }

    public static IEnumerable<string> ToWords(string sentence)
    {
        var chars = sentence
            .Where(c => char.IsLetterOrDigit(c) || c == ' ')
            .Select(char.ToUpper);
        
        return string.Concat(chars)
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }
    
    static Dictionary<string, int> CountWordOccurrences(IEnumerable<string> words)
    {
        var wordCount = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (!wordCount.TryAdd(word, 1))
            {
                wordCount[word]++;
            }
        }

        return wordCount;
    }
}