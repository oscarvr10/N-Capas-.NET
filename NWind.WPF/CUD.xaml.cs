using System.Windows;

namespace NWind.WPF
{
    /// <summary>
    /// Interaction logic for CUD.xaml
    /// </summary>
    public partial class CUD : Window
    {
        public CUD()
        {
            InitializeComponent();
        }

        private void btnMainWindow_Click(object sender, RoutedEventArgs e)
        {
            var crudView = new MainWindow();
            crudView.Show();
            this.Close();
        }
    }
}
