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
    /// Logique d'interaction pour EditQuestionPage.xaml
    /// </summary>
    public partial class EditQuestionPage : Page
    {
        private static Questions questionToEdit;

        public static Questions QuestionToEdit { get => questionToEdit; set => questionToEdit = value; }

        public EditQuestionPage()
        {
            InitializeComponent();
            questionsComboBox.ItemsSource = Questions.GetActiveQuestions();
        }

        private void DisplayEditForm(object sender, RoutedEventArgs e)
        {
            QuestionToEdit = questionsComboBox.SelectedItem as Questions;
            // Si une question n'est pas sélectionnée, on affiche le message d'erreur
            if (QuestionToEdit == null)
            {
                errorTextBlock.Visibility = Visibility.Visible;
            }
            // Sinon on affiche le formulaire correspondant au type de la question
            else
            {
                errorTextBlock.Visibility = Visibility.Hidden;
                switch (QuestionToEdit.Type)
                {
                    case 1:
                        DisplayOrientationForm();
                        break;
                    case 2:
                        DisplayGameForm();
                        break;
                    case 3:
                        DisplayMarketingForm();
                        break;
                }
            }
        }

        private void DisplayMarketingForm()
        {
            orientationStackPanel.Visibility = Visibility.Collapsed;
            gameStackPanel.Visibility = Visibility.Collapsed;
            marketingStackPanel.Visibility = Visibility.Visible;

            marketingQuestionTitleTextBox.Text = QuestionToEdit.Title;
        }

        private void DisplayGameForm()
        {
            orientationStackPanel.Visibility = Visibility.Collapsed;
            gameStackPanel.Visibility = Visibility.Visible;
            marketingStackPanel.Visibility = Visibility.Collapsed;
        }

        private void DisplayOrientationForm()
        {
            orientationStackPanel.Visibility = Visibility.Visible;
            gameStackPanel.Visibility = Visibility.Collapsed;
            marketingStackPanel.Visibility = Visibility.Collapsed;
        }

        private bool CheckQuestionTitleValidity(TextBox questionTitle)
        {
            bool isValid = false;
            if (questionTitle.Text.Length > 0)
            {
                isValid = true;
            }
            return isValid;
        }

        private void EditMarketingQuestion(object sender, RoutedEventArgs e)
        {
            // On vérifie s'il y a eu une modification
            if (QuestionToEdit.Title != marketingQuestionTitleTextBox.Text)
            {
                // On vérifie que l'intitulé de la question n'est pas vide
                if (CheckQuestionTitleValidity(marketingQuestionTitleTextBox))
                {
                    marketingErrorMessage.Visibility = Visibility.Hidden;

                    // On édite la question
                    QuestionToEdit.Title = marketingQuestionTitleTextBox.Text;
                    // On enregistre la modification
                    if (QuestionToEdit.EditQuestion())
                    {
                        // La question a bien été modifiée
                        MessageBox.Show("La question a bien été modifiée", "Succès");
                        NavigationService.Navigate(new EditQuestionPage());
                    }
                    else
                    {
                        // La question n'a pas été modifiée
                        MessageBox.Show("La question n'a pas été modifiée.", "Erreur");
                    }
                }
                else
                {
                    // Message erreur : l'intitulé de la question ne peut pas être vide
                    marketingErrorMessage.Text = "L'intitulé de la question ne peut pas être vide.";
                    marketingErrorMessage.Visibility = Visibility.Visible;
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
