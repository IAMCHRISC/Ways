using ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Logique d'interaction pour RankingWindow.xaml
    /// </summary>
    public partial class RankingWindow : Window
    {
        public static SqlCommand command;
        public RankingWindow()
        {
            InitializeComponent();
            display_info();
        }

        public void display_info()
        {
            lbl_score.Content = Jeu.score;
            lbl_moyenne.Content = Jeu.average_scores();
            lbl_particiation.Content = Jeu.total_participation();
            display_ranking();
        }

        public void display_ranking()
        {
            SqlDataAdapter da;
            DataSet ds;
            DataTable dt;
            string request = "SELECT row_number() OVER(ORDER BY score desc) as rank, username, score, CONVERT(varchar, date, 103) as date FROM T_Score";
            command = new SqlCommand(request, DataBase.connection);
            DataBase.connection.Open();
            da = new SqlDataAdapter(command);
            ds = new DataSet();
            da.Fill(ds, "Query Rank");
            DataBase.connection.Close();
            dt = ds.Tables["Query Rank"];

            ListeRank.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}