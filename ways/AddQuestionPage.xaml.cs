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
    /// Logique d'interaction pour AddQuestionPage.xaml
    /// </summary>
    public partial class AddQuestionPage : Page
    {
        private static int questionType;
        private List<Jobs> jobsList;

        public static int QuestionType { get => questionType; set => questionType = value; }
        public List<Jobs> JobsList { get => jobsList; set => jobsList = value; }

        public AddQuestionPage()
        {
            InitializeComponent();
            // récupérer les types de question
            typesComboBox.ItemsSource = ADO.QuestionType.GetQuestionTypes();
            JobsList = Jobs.GetJobs();
            foreach (Jobs job in JobsList)
            {
                CheckBox cb1 = new CheckBox();
                cb1.Content = job.Title;
                cb1.Tag = job.Id;
                myFirstJobsPanel.Children.Add(cb1);

                CheckBox cb2 = new CheckBox();
                cb2.Content = job.Title;
                cb2.Tag = job.Id;
                mySecondJobsPanel.Children.Add(cb2);

                CheckBox cb3 = new CheckBox();
                cb3.Content = job.Title;
                cb3.Tag = job.Id;
                myThirdJobsPanel.Children.Add(cb3);
            }
        }

        private void DisplayAnswersPanel(object sender, RoutedEventArgs e)
        {
            QuestionType selectedType = typesComboBox.SelectedItem as QuestionType;
            JobsList = new List<Jobs>();
            if (selectedType != null)
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

        private bool CheckClickedGoodAnswer()
        {
            bool isGoodAnswerClicked = false;
            foreach (RadioButton radioButton in gameGoodAnswerStackPanel.Children)
            {
                if (radioButton.IsChecked == true)
                {
                    isGoodAnswerClicked = true;
                    break;
                }
            }
            return isGoodAnswerClicked;
        }

        private bool CheckLinkedJobs(StackPanel container)
        {
            var cbList = container.Children.OfType<CheckBox>().Where(x => x.IsChecked == true);
            return cbList.Count() > 0;
        }

        private void ReinitFields()
        {
            // Champ 'question'
            questionTitleTextBox.Text = "";
            // Champs réponses 'jeu'
            gameFirstAnswerTextBox.Text = "";
            gameSecondAnswerTextBox.Text = "";
            gameThirdAnswerTextBox.Text = "";
            gameFourthAnswerTextBox.Text = "";
            // Champs réponses 'orientation'
            firstOrientationAnswerTextBox.Text = "";
            secondOrientationAnswerTextBox.Text = "";
            thirdOrientationAnswerTextBox.Text = "";
        }

        private List<int> GetCheckedJobsIdList(StackPanel container)
        {
            var cbList = container.Children.OfType<CheckBox>().Where(x => x.IsChecked == true);
            List<int> idList = new List<int>();
            foreach (CheckBox cb in cbList)
            {
                idList.Add((int)cb.Tag);
            }
            return idList;
        }

        private void AddOrientationQuestion(object sender, RoutedEventArgs e)
        {
            // Contrôle qu'un intitulé pour la question a été saisi
            if (CheckQuestionValidity())
            {
                errorMessageOrientation.Visibility = Visibility.Hidden;
                Questions question = new Questions();
                question.Title = questionTitleTextBox.Text;
                question.Type = QuestionType;

                List<TextBox> answersTextBox = new List<TextBox>();
                answersTextBox.Add(firstOrientationAnswerTextBox);
                answersTextBox.Add(secondOrientationAnswerTextBox);
                answersTextBox.Add(thirdOrientationAnswerTextBox);

                // Vérification que toutes les réponses ont été saisies
                if (CheckAnswersValidity(answersTextBox))
                {
                    errorMessageOrientation.Visibility = Visibility.Hidden;
                    // Contrôle que chaque réponse a bien un métier lié
                    if (CheckLinkedJobs(myFirstJobsPanel) && CheckLinkedJobs(mySecondJobsPanel) && CheckLinkedJobs(myThirdJobsPanel))
                    {
                        errorMessageOrientation.Visibility = Visibility.Hidden;
                        // Insertion de la question
                        if (question.AddQuestion())
                        {                            
                            Answers answer1 = new Answers
                            {
                                Title = firstOrientationAnswerTextBox.Text,
                                Solution = true, // Pour les questions orientation, on considère que c'est toujours une bonne réponse
                                QuestionId = question.Id
                            };
                            Answers answer2 = new Answers
                            {
                                Title = secondOrientationAnswerTextBox.Text,
                                Solution = true, // Pour les questions orientation, on considère que c'est toujours une bonne réponse
                                QuestionId = question.Id
                            };
                            Answers answer3 = new Answers
                            {
                                Title = thirdOrientationAnswerTextBox.Text,
                                Solution = true, // Pour les questions orientation, on considère que c'est toujours une bonne réponse
                                QuestionId = question.Id
                            };

                            // Insertion des réponses
                            if (answer1.AddAnswer() && answer2.AddAnswer() && answer3.AddAnswer())
                            {                                
                                List<int> firstAnswerJobsIdList = GetCheckedJobsIdList(myFirstJobsPanel);
                                List<int> secondAnswerJobsIdList = GetCheckedJobsIdList(mySecondJobsPanel);
                                List<int> thirdAnswerJobsIdList = GetCheckedJobsIdList(myThirdJobsPanel);

                                // Insertion des correspondances métiers
                                if (answer1.AddLinkedJobs(firstAnswerJobsIdList)
                                    && answer2.AddLinkedJobs(secondAnswerJobsIdList)
                                    && answer3.AddLinkedJobs(thirdAnswerJobsIdList))
                                {
                                    // Les correspondances ont bien été ajoutées
                                    MessageBox.Show("La question a bien été ajoutée.\n" +
                                        "Les réponses ont bien été ajoutées.\n" +
                                        "Les correspondances métiers ont bien été ajoutées.", "Succès"); // DEBUG
                                    NavigationService.Navigate(new AddQuestionPage());
                                }
                                else
                                {
                                    // Les correspondances n'ont pas toutes été ajoutées
                                    MessageBox.Show("Les réponses n'ont pas toutes été ajoutées.", "Erreur");
                                }
                            }
                            else
                            {
                                // Les réponses n'ont pas été toutes ajoutées
                                MessageBox.Show("Les réponses n'ont pas toutes été ajoutées.", "Erreur");
                            }
                        }
                        else
                        {
                            // La question n'a pas été ajoutée
                            MessageBox.Show("La question n'a pas été ajoutée.", "Erreur");
                        }
                    }
                    else
                    {
                        // Message erreur : lier au moins un métier à chaque réponse (ça n'a pas de sens sinon)
                        errorMessageOrientation.Text = "Merci de lier au moins un métier à chaque réponse.";
                        errorMessageOrientation.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    // Message erreur : saisir toutes les réponses
                    errorMessageOrientation.Text = "Merci de saisir toutes les réponses.";
                    errorMessageOrientation.Visibility = Visibility.Visible;
                }
            }
            else
            {
                // Message erreur : saisir une question
                errorMessageOrientation.Text = "Merci de saisir une question.";
                errorMessageOrientation.Visibility = Visibility.Visible;
            }
        }

        private void AddGameQuestion(object sender, RoutedEventArgs e)
        {
            // Contrôle qu'un intitulé pour la question a été saisi
            if (CheckQuestionValidity())
            {
                errorMessageGame.Visibility = Visibility.Hidden;
                Questions question = new Questions();
                question.Title = questionTitleTextBox.Text;
                question.Type = QuestionType;

                List<TextBox> answersTextBox = new List<TextBox>();
                answersTextBox.Add(gameFirstAnswerTextBox);
                answersTextBox.Add(gameSecondAnswerTextBox);
                answersTextBox.Add(gameThirdAnswerTextBox);
                answersTextBox.Add(gameFourthAnswerTextBox);
                // Vérification que toutes les réponses ont été saisies
                if (CheckAnswersValidity(answersTextBox))
                {
                    errorMessageGame.Visibility = Visibility.Hidden;
                    // Contrôle qu'une bonne réponse est indiquée
                    if (CheckClickedGoodAnswer())
                    {
                        errorMessageGame.Visibility = Visibility.Hidden;
                        // Insertion de la question
                        if (question.AddQuestion())
                        {
                            errorMessageGame.Visibility = Visibility.Hidden;
                            // Insertion des réponses
                            Answers answer1 = new Answers
                            {
                                Title = gameFirstAnswerTextBox.Text,
                                Solution = ((bool)rb1.IsChecked) ? true : false,
                                QuestionId = question.Id
                            };
                            Answers answer2 = new Answers
                            {
                                Title = gameSecondAnswerTextBox.Text,
                                Solution = ((bool)rb2.IsChecked) ? true : false,
                                QuestionId = question.Id
                            };
                            Answers answer3 = new Answers
                            {
                                Title = gameThirdAnswerTextBox.Text,
                                Solution = ((bool)rb3.IsChecked) ? true : false,
                                QuestionId = question.Id
                            };
                            Answers answer4 = new Answers
                            {
                                Title = gameFourthAnswerTextBox.Text,
                                Solution = ((bool)rb4.IsChecked) ? true : false,
                                QuestionId = question.Id
                            };
                            if(answer1.AddAnswer() && answer2.AddAnswer() && answer3.AddAnswer() && answer4.AddAnswer())
                            {
                                errorMessageGame.Visibility = Visibility.Hidden;
                                // Les réponses ont été ajoutées
                                MessageBox.Show("La question a bien été ajoutée.\nLes réponses ont bien été ajoutées.", "Succès");
                                ReinitFields();
                            }
                            else
                            {
                                // Les réponses n'ont pas été toutes ajoutées
                                MessageBox.Show("Les réponses n'ont pas toutes été ajoutées.", "Erreur");
                            }
                        }
                        else
                        {
                            // La question n'a pas été ajoutée
                            MessageBox.Show("La question n'a pas été ajoutée.", "Erreur");
                        }
                    }
                    else
                    {
                        // Message erreur : indiquer une bonne réponse
                        errorMessageGame.Text = "Merci d'indiquer une bonne réponse.";
                        errorMessageGame.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    // Message erreur : saisir toutes les réponses
                    errorMessageGame.Text = "Merci de saisir toutes les réponses.";
                    errorMessageGame.Visibility = Visibility.Visible;
                }
            }
            else
            {
                // Message erreur : saisir une question
                errorMessageGame.Text = "Merci de saisir une question.";
                errorMessageGame.Visibility = Visibility.Visible;
            }
        }

        private void AddMarketingQuestion(object sender, RoutedEventArgs e)
        {
            // Contrôle qu'un intitulé pour la question a été saisi
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
                    // La question a bien été ajoutée
                    MessageBox.Show("Question marketing ajoutée.", "Succès");
                    ReinitFields();
                }
                else
                {
                    // La question n'a pas été ajoutée
                    MessageBox.Show("La question n'a pas été ajoutée.", "Erreur");
                }
            }
            else
            {
                // Message erreur : saisir une question
                errorMessageMarketing.Text = "Merci de saisir une question.";
                errorMessageMarketing.Visibility = Visibility.Visible;
            }
        }
    }
}
