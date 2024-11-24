using Plugin.Common;

namespace Plugin.Reverse;

public class ReverseStringPlugin : ITextPlugin
{
    public string ApplyOperation(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}