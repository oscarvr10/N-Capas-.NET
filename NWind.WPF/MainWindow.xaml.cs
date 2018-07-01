using System;
using System.Windows;
namespace NWind.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void btnCUD_Click(object sender, RoutedEventArgs e)
        {
            var crudView = new CUD();
            crudView.Show();
            this.Close();
        }
    }
}
