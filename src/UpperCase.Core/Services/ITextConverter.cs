namespace UpperCase.Core.Services;

public interface ITextConverter
{
    /// <summary>
    /// Converts only alphabetic letters to uppercase; all other characters are left unchanged.
    /// </summary>
    string ToUpperLettersOnly(string input);
}
