using ADO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ways
{
    /// <summary>
    /// Logique d'interaction pour EndGameWindow.xaml
    /// </summary>
    public partial class EndGameWindow : Window
    {
        private string player;
        public string Player { get => player; set => player = value; }
        public EndGameWindow(string player)
        {
            InitializeComponent();
            lbl_score.Content = Jeu.score.ToString();
            Player = player;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Redirection vers le formulaire marketing
            MarketingWindow marketingWindow = new MarketingWindow(Player);
            marketingWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Redirection vers le classement
            RankingWindow window = new RankingWindow();
            window.Show();
            this.Close();
        }
    }
}