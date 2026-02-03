using System.Text;

namespace UpperCase.Core.Services;

public sealed class TextConverter : ITextConverter
{
    public string ToUpperLettersOnly(string input)
    {
        if (input is null)
            return string.Empty;

        var sb = new StringBuilder(input.Length);

        foreach (var ch in input)
        {
            if (char.IsLetter(ch))
            {
                // Culture-invariant uppercase conversion for predictable behavior.
                sb.Append(char.ToUpperInvariant(ch));
            }
            else
            {
                sb.Append(ch);
            }
        }

        return sb.ToString();
    }
}
