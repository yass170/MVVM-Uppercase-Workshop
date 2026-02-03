using System.ComponentModel;
using System.Windows.Input;
using UpperCase.Core.Services;
using UpperCase.Core.ViewModels;
using UpperCase.WpfApp.Mvvm;

namespace UpperCase.WpfApp.ViewModels;

/// <summary>
/// WPF-specific ViewModel: reuses the shared MainViewModel and only adds WPF command binding.
/// </summary>
public sealed class MainWindowViewModel : MainViewModel
{
    private readonly RelayCommand _convertCommand;

    public MainWindowViewModel(ITextConverter converter) : base(converter)
    {
        _convertCommand = new RelayCommand(_ => Convert(), _ => CanConvert);
        ConvertCommand = _convertCommand;

        PropertyChanged += OnAnyPropertyChanged;
    }

    public ICommand ConvertCommand { get; }

    private void OnAnyPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(CanConvert))
        {
            _convertCommand.RaiseCanExecuteChanged();
        }
    }
}
