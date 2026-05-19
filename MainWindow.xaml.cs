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
    private string _operatorName = "Оператор";
    private string _clientName = "Клиент";

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
            
            _operatorName = dialog.OperatorName;
            _clientName = dialog.ClientName;

            ScriptTextBlock.Text = $"Здравствуйте, меня зовут {_operatorName}. Я разговариваю с {_clientName}?";
        }

    }

    private void YesButtion_Click(object sender, RoutedEventArgs e)
    {
        ScriptTextBlock.Text = $"Очень приятно, {_clientName}. Готовы уделить 2-3 минуты?";
    }
    
    private void NoButtion_Click(object sender, RoutedEventArgs e)
    {
        ScriptTextBlock.Text = $"Извините, пожалуйста. Подскажите, когда можно перезвонить?";
    }

}