using Plugin.Common;

namespace Plugin.Rot13;

public class Rot13Plugin : ITextPlugin
{
    public string ApplyOperation(string input)
    {
        char[] result = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            result[i] = c switch
            {
                >= 'a' and <= 'z' => (char)((c - 'a' + 13) % 26 + 'a'),
                >= 'A' and <= 'Z' => (char)((c - 'A' + 13) % 26 + 'A'),
                _ => c
            };
        }

        return new string(result);
    }
}