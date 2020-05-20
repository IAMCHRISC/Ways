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

        private void ReinitFields()
        {
            questionTitleTextBox.Text = "";
            gameFirstAnswerTextBox.Text = "";
            gameSecondAnswerTextBox.Text = "";
            gameThirdAnswerTextBox.Text = "";
            gameFourthAnswerTextBox.Text = "";
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
                    // Insertion de la question
                    if (question.AddQuestion())
                    {
                        // Insertion des réponses
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
                        if (answer1.AddAnswer() && answer2.AddAnswer() && answer3.AddAnswer())
                        {
                            // Insertion des correspondances métiers : TODO
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
