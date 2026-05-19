using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OperatorScriptWpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private bool _startupDialogWasShown;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        if (_startupDialogWasShown) return;

        _startupDialogWasShown = true;

        var dialog = new StartupDialog()
        {
            Owner =  this
        };
        bool? result = dialog.ShowDialog();
        
        if (result == true)
        {
            Title = $"Интерактивный скрипт оператора — {dialog.OperatorName} / {dialog.ClientName}";
        }

    }

}