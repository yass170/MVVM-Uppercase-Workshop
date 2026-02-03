using UpperCase.Core.Mvvm;
using UpperCase.Core.Services;

namespace UpperCase.Core.ViewModels;

/// <summary>
/// ViewModel shared by both the console and WPF versions.
/// It contains the application rules and depends only on the Model/Service layer.
/// </summary>
public class MainViewModel : ViewModelBase
{
    private readonly ITextConverter _converter;

    private string _inputText = string.Empty;
    private string _outputText = string.Empty;
    private string _validationMessage = string.Empty;

    public MainViewModel(ITextConverter converter)
    {
        _converter = converter;
        Validate();
    }

    /// <summary>
    /// User input (length must be between 1 and 8 characters).
    /// </summary>
    public string InputText
    {
        get => _inputText;
        set
        {
            value ??= string.Empty;
            if (_inputText == value) return;

            _inputText = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CanConvert));

            Validate();
        }
    }

    /// <summary>
    /// Converted output: same characters, but letters are uppercase.
    /// </summary>
    public string OutputText
    {
        get => _outputText;
        private set
        {
            if (_outputText == value) return;
            _outputText = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Validation feedback (empty if valid).
    /// </summary>
    public string ValidationMessage
    {
        get => _validationMessage;
        private set
        {
            if (_validationMessage == value) return;
            _validationMessage = value;
            OnPropertyChanged();
        }
    }

    public bool CanConvert => !string.IsNullOrEmpty(InputText) && InputText.Length <= 8;

    public void Convert()
    {
        Validate();
        if (!CanConvert)
            return;

        OutputText = _converter.ToUpperLettersOnly(InputText);
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(InputText))
        {
            ValidationMessage = "Saisissez entre 1 et 8 caractères.";
            OutputText = string.Empty;
            return;
        }

        if (InputText.Length > 8)
        {
            ValidationMessage = "La chaîne ne doit pas dépasser 8 caractères.";
            OutputText = string.Empty;
            return;
        }

        ValidationMessage = string.Empty;
    }
}
