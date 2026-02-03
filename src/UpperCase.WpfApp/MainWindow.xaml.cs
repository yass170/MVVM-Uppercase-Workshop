using System.Windows;
using UpperCase.Core.Services;
using UpperCase.WpfApp.ViewModels;

namespace UpperCase.WpfApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Composition root for the WPF app.
        ITextConverter converter = new TextConverter();
        DataContext = new MainWindowViewModel(converter);
    }
}
