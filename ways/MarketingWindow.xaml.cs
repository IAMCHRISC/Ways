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
    /// Logique d'interaction pour MarketingWindow.xaml
    /// </summary>
    public partial class MarketingWindow : Window
    {
        public MarketingWindow()
        {
            InitializeComponent();
            display_info();
        }

        public void display_info()
        {
            DataTable dt = new DataTable();
            dt = Marketing.display_question();
            int i = 1;

            foreach (DataRow row in dt.Rows)
            {
                switch (i)
                {
                    case 1:
                        lbl_question1.Content = row[0];
                        break;
                    case 2:
                        lbl_question2.Content = row[0];
                        break;
                    case 3:
                        lbl_question3.Content = row[0];
                        break;
                    case 4:
                        lbl_question4.Content = row[0];
                        break;
                    case 5:
                        lbl_question5.Content = row[0];
                        break;
                    case 6:
                        lbl_question6.Content = row[0];
                        break;
                    case 7:
                        lbl_question7.Content = row[0];
                        break;
                    case 8:
                        lbl_question8.Content = row[0];
                        break;
                    case 9:
                        lbl_question9.Content = row[0];
                        break;
                    case 10:
                        lbl_question10.Content = row[0];
                        break;
                    default:
                        break;
                }
                i++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool retval;
            retval = Marketing.save(txt_question1.Text, txt_question2.Text, txt_question3.Text, txt_question4.Text, txt_question5.Text, txt_question6.Text, txt_question7.Text, txt_question8.Text, txt_question9.Text, txt_question10.Text);

            if (retval == true)
            {
                // Redirection vers le classement plutôt
                //MainWindow window = new MainWindow();
                //window.Show();
                this.Close();
            }
        }
    }
}