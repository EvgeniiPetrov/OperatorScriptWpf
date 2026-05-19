using System.Windows;
using System.Windows.Controls;

namespace OperatorScriptWpf;

public partial class StartupDialog : Window
{
    public StartupDialog()
    {
        InitializeComponent();
    }

    public string OperatorName { get; private set; } = "";

    public string ClientName { get; private set; } = "";

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        OperatorName = OperatorNameTextBox.Text;
        ClientName = ClientNameTextBox.Text;

        DialogResult = true;
        Close();
    }
}