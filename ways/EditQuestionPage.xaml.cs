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
        public EditQuestionPage()
        {
            InitializeComponent();
            questionsComboBox.ItemsSource = Questions.GetActiveQuestions();
        }

        private void DisplayEditForm(object sender, RoutedEventArgs e)
        {
            Questions questionToEdit = questionsComboBox.SelectedItem as Questions;
            // Si une question n'est pas sélectionnée, on affiche le message d'erreur
            if (questionToEdit == null)
            {
                errorTextBlock.Visibility = Visibility.Visible;
            }
            // Sinon on affiche le formulaire correspondant au type de la question
            else
            {
                errorTextBlock.Visibility = Visibility.Hidden;
                switch (questionToEdit.Type)
                {
                    case 1:
                        DisplayOrientationForm();
                        break;
                    case 2:
                        DisplayGameForm();
                        break;
                    case 3:
                        DisplayMarketingForm(questionToEdit);
                        break;
                }
            }
        }

        private void DisplayMarketingForm(Questions questionToEdit)
        {
            orientationStackPanel.Visibility = Visibility.Collapsed;
            gameStackPanel.Visibility = Visibility.Collapsed;
            marketingStackPanel.Visibility = Visibility.Visible;

            marketingQuestionTitleTextBox.Text = questionToEdit.Title;
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
    }
}
