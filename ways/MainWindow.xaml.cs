using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ways
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

        public void NavigateToOrientation(object sender, RoutedEventArgs e)
        {
            //NameChoiceWindow nameChoiceWindow = new NameChoiceWindow();
            //nameChoiceWindow.Show();
            Main.Content = new NameChoiceWindow();
        }

        public void NavigateToAdmin(object sender, RoutedEventArgs e)
        {
            LoginAdministration loginAdministration = new LoginAdministration();
            loginAdministration.Show();
        }

        private void NavigateToGame(object sender, RoutedEventArgs e)
        {
            // Temporaire : doit router vers l'écran de choix de nom de joueur
            // et ensuite vers l'écran de jeu
            Main.Content = new Game();
        }

        private void NavigateToHome(object sender, RoutedEventArgs e)
        {
            // Navigate to home page.
        }
    }
}
