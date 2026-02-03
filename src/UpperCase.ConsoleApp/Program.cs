using UpperCase.Core.Services;
using UpperCase.Core.ViewModels;

namespace UpperCase.ConsoleApp;

internal static class Program
{
    private static void Main()
    {
        // Composition root (simple manual dependency injection).
        ITextConverter converter = new TextConverter();
        var vm = new MainViewModel(converter);

        Console.WriteLine("=== Convertisseur minuscules -> majuscules (MVVM - Console) ===");
        Console.WriteLine("Règle: saisir une chaîne de 1 à 8 caractères.");
        Console.WriteLine();

        vm.InputText = ReadValidInput();
        vm.Convert();

        Console.WriteLine();
        Console.WriteLine($"Chaîne convertie : {vm.OutputText}");
        Console.WriteLine();
        Console.WriteLine("Appuyez sur une touche pour fermer...");
        Console.ReadKey(intercept: true);
    }

    private static string ReadValidInput()
    {
        while (true)
        {
            Console.Write("Saisissez une chaîne (1..8) : ");
            var input = Console.ReadLine() ?? string.Empty;

            if (input.Length is >= 1 and <= 8)
                return input;

            Console.WriteLine("Entrée invalide. La chaîne doit contenir entre 1 et 8 caractères.");
        }
    }
}
