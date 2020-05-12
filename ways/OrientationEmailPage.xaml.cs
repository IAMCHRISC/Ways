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
    /// Logique d'interaction pour OrientationEmailPage.xaml
    /// </summary>
    public partial class OrientationEmailPage : Page
    {
        private List<Jobs> results;

        public List<Jobs> Results { get => results; set => results = value; }

        public OrientationEmailPage(List<Jobs> jobsList)
        {
            InitializeComponent();
            Results = jobsList;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void SendResults(object sender, RoutedEventArgs e)
        {
            // Send results by email :
            // Récupérer l'adresse email renseignée
            // Vérifier que c'est bien une adresse email
            if (!IsValidEmail(emailField.Text))
            {
                // Afficher message d'erreur
                errorMessageLabel.Visibility = Visibility.Visible;
            }
            else
            {
                // Construction d'un email :
                // - l'adresse renseignée
                // - utiliser le nom de joueur renseigné pour l'objet
                // - utiliser les résultats précédents pour le corps du mai
                // Envoyer l'email
                MessageBox.Show("email envoyé.");
                // Navigate back to home
                
            }
        }
    }
}
