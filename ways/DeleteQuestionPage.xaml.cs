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
    /// Logique d'interaction pour DeleteQuestionPage.xaml
    /// </summary>
    public partial class DeleteQuestionPage : Page
    {
        public DeleteQuestionPage()
        {
            InitializeComponent();
            questionsComboBox.ItemsSource = Questions.GetActiveQuestions();
        }

        private void DeleteQuestion(object sender, RoutedEventArgs e)
        {
            Questions questionToDelete = questionsComboBox.SelectedItem as Questions;
            // Si une question n'est pas sélectionnée : on affiche le message d'erreur
            if (questionToDelete == null)
            {
                errorTextBlock.Visibility = Visibility.Visible;
            }
            // Sinon on rend la question et les réponses "inactives"
            else
            {
                errorTextBlock.Visibility = Visibility.Hidden;
                // On rend la question inactive
                if (Questions.DeleteById(questionToDelete.Id))
                {
                    // On rend les réponses inactives aussi
                    if (Answers.DeleteById(questionToDelete.Id))
                    {
                        MessageBox.Show("Question / Réponses supprimées !");
                        questionsComboBox.ItemsSource = Questions.GetActiveQuestions();
                    }
                    else
                    {
                        MessageBox.Show("Erreur : les réponses n'ont pas pu être supprimées.");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur : la question n'a pas pu être supprimée.");
                }
            }
        }
    }
}
