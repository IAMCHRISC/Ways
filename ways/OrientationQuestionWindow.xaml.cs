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
    /// Logique d'interaction pour OrientationQuestionWindow.xaml
    /// </summary>
    public partial class OrientationQuestionWindow : Page
    {
        private List<Questions> questionsList;
        private List<Answers> answersList;
        private static int currentQuestionIndex;

        public List<Questions> QuestionsList { get => questionsList; set => questionsList = value; }
        public List<Answers> AnswersList { get => answersList; set => answersList = value; }
        public static int CurrentQuestionIndex { get => currentQuestionIndex; set => currentQuestionIndex = value; }

        public OrientationQuestionWindow()
        {
            InitializeComponent();
            QuestionsList = Questions.GetQuestionsByType(1); // 1 = Orientation
            numberOfQuestionsLabel.Content = "Nombre de questions : " + QuestionsList.Count;
            CurrentQuestionIndex = 0;
            UpdateView();
        }

        private void UpdateView()
        {
            countLabel.Content = (CurrentQuestionIndex + 1) + "/" + QuestionsList.Count;
            questionTitleLabel.Content = QuestionsList[CurrentQuestionIndex].Title;
            AnswersList = Answers.GetAnswersByQuestionId(QuestionsList[CurrentQuestionIndex].Id);
            answersStackPanel.Children.Clear();
            foreach (Answers answer in AnswersList)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Content = answer.Title;
                answersStackPanel.Children.Add(radioButton);
            }
        }

        private void ValidateAnswer(object sender, RoutedEventArgs e)
        {
            // S'il reste des questions, on boucle sur la liste des questions
            if (CurrentQuestionIndex < QuestionsList.Count-1)
            {
                // Récupération du résultat
                // Mise à jour de l'affichage
                CurrentQuestionIndex++;
                UpdateView();
            }
            // Sinon on affiche la page de résultats
            else
            {
                NavigationService.Navigate(new OrientationResultsPage());
            }
        }
    }
}
