using ADO;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private static List<int> resultsList;

        public List<Questions> QuestionsList { get => questionsList; set => questionsList = value; }
        public List<Answers> AnswersList { get => answersList; set => answersList = value; }
        public static int CurrentQuestionIndex { get => currentQuestionIndex; set => currentQuestionIndex = value; }
        public static List<int> ResultsList { get => resultsList; set => resultsList = value; }

        public OrientationQuestionWindow()
        {
            InitializeComponent();
            QuestionsList = Questions.GetQuestionsByType(1); // 1 = Orientation
            ResultsList = new List<int>();
            numberOfQuestionsLabel.Content = "Nombre de questions : " + QuestionsList.Count;
            CurrentQuestionIndex = 0;
            UpdateView();
        }

        private bool CheckClickedAnswer()
        {
            bool isAnswerClicked = false;
            foreach (RadioButton radioButton in answersStackPanel.Children)
            {
                if (radioButton.IsChecked == true)
                {
                    isAnswerClicked = true;
                    break;
                }
            }
            return isAnswerClicked;
        }

        private void UpdateView()
        {
            resultsListLabel.Content = "ResultsList = [" + string.Join(", ", ResultsList) + "]"; // Debug
            invalidAnswerLabel.Visibility = Visibility.Hidden;
            countLabel.Content = (CurrentQuestionIndex + 1) + "/" + QuestionsList.Count; // Utile pour l'UX
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

        private void AddResults()
        {
            // Récupérer l'id de la réponse donnée
            int i = 0;
            int answerId = 0;
            foreach(RadioButton radioButton in answersStackPanel.Children)
            {
                if(radioButton.IsChecked == true)
                {
                    answerId = AnswersList[i].Id;
                    break;
                }
                i++;
            }
            // Récupérer les id des métiers liés
            List<int> jobsId = Jobs.GetIdsByAnswerId(answerId);
            // Ajouter ces id à ResultsList
            foreach(int id in jobsId)
            {
                //MessageBox.Show("-- id = " + id, "Ajout des id à ResultsList debug");
                ResultsList.Add(id);
            }
        }

        private void ComputeResults(List<int> results)
        {
            //List<int> topThreeList = new List<int>();
            MessageBox.Show(string.Join(", ", results), "ResultsList brut");
            results.Sort();
            IEnumerable<int> distinctResults = results.Distinct();
            MessageBox.Show(string.Join(", ", results), "ResultsList trié");
            //MessageBox.Show(g.ToString(), "ResultsList trié");
            //return topThreeList;
        }

        private void ValidateAnswer(object sender, RoutedEventArgs e)
        {
            // Vérifier qu'un élément "radioButton" est sélectionné
            if (!CheckClickedAnswer())
            {
                invalidAnswerLabel.Visibility = Visibility.Visible;
            }
            else
            {
                // S'il reste des questions, on boucle sur la liste des questions
                if (CurrentQuestionIndex < QuestionsList.Count - 1)
                {
                    // Récupération du résultat
                    AddResults();
                    // Mise à jour de l'affichage
                    CurrentQuestionIndex++;
                    UpdateView();
                }
                // Sinon on affiche la page de résultats
                else
                {
                    // Calculer résultat final
                    ComputeResults(ResultsList);
                    // Navigation vers la page de résultats finaux
                    NavigationService.Navigate(new OrientationResultsPage());
                }
            }
        }
    }
}
