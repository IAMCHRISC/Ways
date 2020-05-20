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
    /// Logique d'interaction pour AddQuestionPage.xaml
    /// </summary>
    public partial class AddQuestionPage : Page
    {
        private static int questionType;

        public static int QuestionType { get => questionType; set => questionType = value; }

        public AddQuestionPage()
        {
            InitializeComponent();
            // récupérer les types de question
            typesComboBox.ItemsSource = ADO.QuestionType.GetQuestionTypes();
            firstLinkedJobsComboBox.ItemsSource = Jobs.GetJobs();
            secondLinkedJobsComboBox.ItemsSource = Jobs.GetJobs();
            thirdLinkedJobsComboBox.ItemsSource = Jobs.GetJobs();
        }

        private void DisplayAnswersPanel(object sender, RoutedEventArgs e)
        {
            QuestionType selectedType = typesComboBox.SelectedItem as QuestionType;
            if(selectedType != null)
            {
                QuestionType = selectedType.Id;
                typeErrorMessage.Visibility = Visibility.Hidden;
                switch (selectedType.Type)
                {
                    case "Orientation":
                        marketingStackPanel.Visibility = Visibility.Collapsed;
                        gameStackPanel.Visibility = Visibility.Collapsed;
                        orientationStackPanel.Visibility = Visibility.Visible;
                        break;
                    case "Jeu":
                        marketingStackPanel.Visibility = Visibility.Collapsed;
                        orientationStackPanel.Visibility = Visibility.Collapsed;
                        gameStackPanel.Visibility = Visibility.Visible;
                        break;
                    case "Marketing":
                        gameStackPanel.Visibility = Visibility.Collapsed;
                        orientationStackPanel.Visibility = Visibility.Collapsed;
                        marketingStackPanel.Visibility = Visibility.Visible;
                        break;
                }
            }
            else
            {
                typeErrorMessage.Visibility = Visibility.Visible;
            }
        }
        private bool CheckQuestionValidity()
        {
            bool isValid = false;
            if (questionTitleTextBox.Text.Length > 0)
            {
                isValid = true;
            }
            return isValid;
        }

        private bool CheckAnswersValidity(List<TextBox> textBoxList)
        {
            bool isValid = true;
            foreach(TextBox answer in textBoxList)
            {
                if(answer.Text.Length <= 0)
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }

        private void AddGameQuestion(object sender, RoutedEventArgs e)
        {
            // Contrôle qu'un intitulé pour la question a été saisi
            if (CheckQuestionValidity())
            {
                Questions question = new Questions();
                question.Title = questionTitleTextBox.Text;
                question.Type = QuestionType;

                // Contrôle au niveaux des réponses
                List<TextBox> answersTextBox = new List<TextBox>();
                answersTextBox.Add(gameFirstAnswerTextBox);
                answersTextBox.Add(gameSecondAnswerTextBox);
                answersTextBox.Add(gameThirdAnswerTextBox);
                answersTextBox.Add(gameFourthAnswerTextBox);
                // - vérifier qu'elles sont toutes remplies
                if (CheckAnswersValidity(answersTextBox))
                {
                    // - vérifier qu'une bonne réponse est indiquée

                }
            }
            // Insertion en base
        }

        private void AddMarketingQuestion(object sender, RoutedEventArgs e)
        {
            if (CheckQuestionValidity())
            {
                errorMessageMarketing.Visibility = Visibility.Hidden;
                // On ajoute simplement la question en base
                Questions marketingQuestion = new Questions
                {
                    Title = questionTitleTextBox.Text,
                    Type = 3
                };
                if (marketingQuestion.AddQuestion())
                {
                    MessageBox.Show("Question marketing ajoutée !");
                    questionTitleTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Erreur serveur");
                }
            }
            else
            {
                errorMessageMarketing.Visibility = Visibility.Visible;
            }
        }
    }
}
