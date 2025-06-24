using System.Text;

namespace task01;

public static class StringExtensions
{
    public static bool IsPalindrome(this string input)
    {
        if (string.IsNullOrEmpty(input)) return false;
        
        string lower = input.ToLower();
        StringBuilder sb = new StringBuilder();

        foreach (var chr in lower)
        {
            if (!char.IsWhiteSpace(chr) && !char.IsPunctuation(chr))
            {
                sb.Append(chr);
            }
        }
        
        string final = sb.ToString();
        string reverse = new string(final.Reverse().ToArray());

        return reverse == final;
    }
}
