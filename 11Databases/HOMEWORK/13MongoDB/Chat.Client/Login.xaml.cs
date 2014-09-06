namespace Chat.Client
{
    using System;
    using System.Linq;
    using System.Windows;

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = this.username.Text;
            if (username.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters.");
            }
            else
            {
                MainWindow chat = new MainWindow(username);
                chat.Show();
            }
        }
    }
}
