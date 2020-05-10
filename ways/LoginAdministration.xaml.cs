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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ways
{
    /// <summary>
    /// Logique d'interaction pour LoginAdministration.xaml
    /// </summary>
    public partial class LoginAdministration : Window
    {
        public LoginAdministration()
        {
            InitializeComponent();
        }

        public void btn_connectionOnClick(object sender, RoutedEventArgs e)
        {
            bool testLogin = Administrator.LoginVerification(txt_username.Text, txt_password.Text);

            if (testLogin == true)
            {
                lbl_statut_connexion.Content = "";
                lbl_statut_connexion.Visibility = Visibility.Hidden;
            }
            else
            {
                lbl_statut_connexion.Content = "Username et/ou Password inccorect";
                lbl_statut_connexion.Visibility = Visibility.Visible;
            }
        }
    }
}
