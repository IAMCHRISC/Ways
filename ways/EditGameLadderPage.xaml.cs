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
    /// Logique d'interaction pour EditGameLadderPage.xaml
    /// </summary>
    public partial class EditGameLadderPage : Page
    {
        private static Scores scoreToEdit;

        public static Scores ScoreToEdit { get => scoreToEdit; set => scoreToEdit = value; }

        public EditGameLadderPage()
        {
            InitializeComponent();
            ladderListView.ItemsSource = Scores.GetLadder();
        }

        private void EditLine(object sender, RoutedEventArgs e)
        {
            ScoreToEdit = ladderListView.SelectedItem as Scores;
            if (ScoreToEdit != null)
            {
                errorMessage.Visibility = Visibility.Hidden;
                usernameBox.Text = ScoreToEdit.Username;
                scoreBox.Text = ScoreToEdit.Score.ToString();
                confirmButton.IsEnabled = true;
            }
            else
            {
                errorMessage.Text = "Merci de sélectionner une ligne à modifier.";
                errorMessage.Visibility = Visibility.Visible;
            }
        }

        private bool IsNumber(string text)
        {
            int result;
            return int.TryParse(text, out result);
        }

        private void ConfirmModif(object sender, RoutedEventArgs e)
        {
            // Vérifier qu'il y a eu une modification
            if (usernameBox.Text != ScoreToEdit.Username || scoreBox.Text != ScoreToEdit.Score.ToString())
            {
                // On vérifie que les champs sont remplis
                if (usernameBox.Text.Length > 0 && scoreBox.Text.Length > 0)
                {
                    errorMessage.Visibility = Visibility.Hidden;
                    // On vérifie que le score est valide (un nombre)
                    if (scoreBox.Text == ScoreToEdit.Score.ToString() || (scoreBox.Text != ScoreToEdit.Score.ToString() && IsNumber(scoreBox.Text)))
                    {
                        errorMessage.Visibility = Visibility.Hidden;
                        ScoreToEdit.Username = usernameBox.Text;
                        ScoreToEdit.Score = int.Parse(scoreBox.Text);
                        if (ScoreToEdit.EditScore())
                        {
                            MessageBox.Show("Le score a bien été modifié.", "Succès");
                            ScoreToEdit = null;
                            usernameBox.Text = "";
                            scoreBox.Text = "";
                            confirmButton.IsEnabled = false;
                            ladderListView.ItemsSource = Scores.GetLadder();
                        }
                        else
                        {
                            MessageBox.Show("Le score n'a pas été modifié.", "Erreur");
                        }
                    }
                    else
                    {
                        errorMessage.Text = "Le score doit être un nombre.";
                        errorMessage.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    errorMessage.Text = "Les champs ne peuvent pas être vides.";
                    errorMessage.Visibility = Visibility.Visible;
                }
            }
            // Sinon on ne fait rien et on l'indique à l'utilisateur
            else
            {
                MessageBox.Show("Aucune modification à effectuer.");
            }
        }
    }
}
