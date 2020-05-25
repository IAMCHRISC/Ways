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
    /// Logique d'interaction pour EmailParamPage.xaml
    /// </summary>
    public partial class EmailParamPage : Page
    {
        public EmailParamPage()
        {
            InitializeComponent();
            emailAddressBox.Text = Administrator.EmailAddress;
            emailPasswordBox.Password = Administrator.EmailPassword;
            orientationObjectBox.Text = Administrator.OrientationObject;
            orientationMessageBox.Text = Administrator.OrientationMessage;
            gameObjectBox.Text = Administrator.GameObject;
            gameMessageBox.Text = Administrator.GameMessage;
        }

        private bool CheckValidity()
        {
            bool result = true;
            if (emailAddressBox.Text.Length <= 0)
            {
                result = false;
            }
            else if (emailPasswordBox.Password.Length <= 0)
            {
                result = false;
            }
            else if (orientationObjectBox.Text.Length <= 0)
            {
                result = false;
            }
            else if (orientationMessageBox.Text.Length <= 0)
            {
                result = false;
            }
            else if (gameObjectBox.Text.Length <= 0)
            {
                result = false;
            }
            else if (gameMessageBox.Text.Length <= 0)
            {
                result = false;
            }
            return result;
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

        private void CancelModification(object sender, RoutedEventArgs e)
        {
            emailAddressBox.Text = Administrator.EmailAddress;
            emailPasswordBox.Password = Administrator.EmailPassword;
            orientationObjectBox.Text = Administrator.OrientationObject;
            orientationMessageBox.Text = Administrator.OrientationMessage;
            gameObjectBox.Text = Administrator.GameObject;
            gameMessageBox.Text = Administrator.GameMessage;
        }

        private void ConfirmModification(object sender, RoutedEventArgs e)
        {
            // Vérifier qu'un champ n'est pas vide
            if (CheckValidity())
            {
                errorMessage.Visibility = Visibility.Hidden;
                // Vérifier que l'adresse email a changé et qu'elle est valide
                if (emailAddressBox.Text != Administrator.EmailAddress && IsValidEmail(emailAddressBox.Text))
                {
                    errorMessage.Visibility = Visibility.Hidden;
                    Administrator.EmailAddress = emailAddressBox.Text;
                }
                else
                {
                    errorMessage.Text = "Merci de renseigner une adresse email valide.";
                    errorMessage.Visibility = Visibility.Visible;
                }
                
                Administrator.EmailPassword = emailPasswordBox.Password;
                Administrator.OrientationObject = orientationObjectBox.Text;
                Administrator.OrientationMessage = orientationMessageBox.Text;
                Administrator.GameObject = gameObjectBox.Text;
                Administrator.GameMessage = gameMessageBox.Text;

                MessageBox.Show("Les informations ont bien été mises à jour.");
            }
            else
            {
                errorMessage.Text = "Tous les champs doivent être remplis.";
                errorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}
