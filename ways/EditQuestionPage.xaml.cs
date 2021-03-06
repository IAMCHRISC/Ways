﻿using ADO;
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
    /// Logique d'interaction pour EditQuestionPage.xaml
    /// </summary>
    public partial class EditQuestionPage : Page
    {
        private static Questions questionToEdit;
        private static List<Answers> answersToEdit;
        private static List<Jobs> jobsList;

        public static Questions QuestionToEdit { get => questionToEdit; set => questionToEdit = value; }
        public static List<Answers> AnswersToEdit { get => answersToEdit; set => answersToEdit = value; }
        public static List<Jobs> JobsList { get => jobsList; set => jobsList = value; }

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

            // Remplir l'intitulé de la question
            marketingQuestionTitleTextBox.Text = QuestionToEdit.Title;
        }

        private void DisplayGameForm()
        {
            orientationStackPanel.Visibility = Visibility.Collapsed;
            gameStackPanel.Visibility = Visibility.Visible;
            marketingStackPanel.Visibility = Visibility.Collapsed;

            // Récupérer les réponses associées à la question
            AnswersToEdit = Answers.GetAnswersByQuestionId(QuestionToEdit.Id);

            // Remplir les champs avec les données récupérées
            gameQuestionTitleTextBox.Text = QuestionToEdit.Title;
            gameQuestionOrderTextBox.Text = QuestionToEdit.Order.ToString();
            gameFirstAnswerTextBox.Text = AnswersToEdit[0].Title;
            gameSecondAnswerTextBox.Text = AnswersToEdit[1].Title;
            gameThirdAnswerTextBox.Text = AnswersToEdit[2].Title;
            gameFourthAnswerTextBox.Text = AnswersToEdit[3].Title;

            // Cocher la bonne réponse
            rb1.IsChecked = (AnswersToEdit[0].Solution == true) ? true : false;
            rb2.IsChecked = (AnswersToEdit[1].Solution == true) ? true : false;
            rb3.IsChecked = (AnswersToEdit[2].Solution == true) ? true : false;
            rb4.IsChecked = (AnswersToEdit[3].Solution == true) ? true : false;
        }

        private void DisplayOrientationForm()
        {
            orientationStackPanel.Visibility = Visibility.Visible;
            gameStackPanel.Visibility = Visibility.Collapsed;
            marketingStackPanel.Visibility = Visibility.Collapsed;

            // Récupérer les réponses associées à la question
            AnswersToEdit = Answers.GetAnswersByQuestionId(QuestionToEdit.Id);
            foreach(Answers answer in AnswersToEdit)
            {
                answer.LinkedJobs = Jobs.GetIdsByAnswerId(answer.Id);
            }

            // Remplir les champs avec les données récupérées
            orientationQuestionTitleTextBox.Text = QuestionToEdit.Title;
            orientationQuestionOrderTextBox.Text = QuestionToEdit.Order.ToString();
            firstOrientationAnswerTextBox.Text = AnswersToEdit[0].Title;
            secondOrientationAnswerTextBox.Text = AnswersToEdit[1].Title;
            thirdOrientationAnswerTextBox.Text = AnswersToEdit[2].Title;

            // Réinitialiser les listes métiers
            myFirstJobsPanel.Children.Clear();
            mySecondJobsPanel.Children.Clear();
            myThirdJobsPanel.Children.Clear();

            // Cocher les métiers liés
            JobsList = Jobs.GetJobs();
            foreach (Jobs job in JobsList)
            {
                CheckBox cb1 = new CheckBox();
                cb1.Content = job.Title;
                cb1.Tag = job.Id;
                if (AnswersToEdit[0].LinkedJobs.IndexOf(job.Id) != -1)
                {
                    cb1.IsChecked = true;
                }
                myFirstJobsPanel.Children.Add(cb1);

                CheckBox cb2 = new CheckBox();
                cb2.Content = job.Title;
                cb2.Tag = job.Id;
                if (AnswersToEdit[1].LinkedJobs.IndexOf(job.Id) != -1)
                {
                    cb2.IsChecked = true;
                }
                mySecondJobsPanel.Children.Add(cb2);

                CheckBox cb3 = new CheckBox();
                cb3.Content = job.Title;
                cb3.Tag = job.Id;
                if (AnswersToEdit[2].LinkedJobs.IndexOf(job.Id) != -1)
                {
                    cb3.IsChecked = true;
                }
                myThirdJobsPanel.Children.Add(cb3);
            }
        }

        private bool CheckTextBoxValidity(TextBox text)
        {
            bool isValid = false;
            if (text.Text.Length > 0)
            {
                isValid = true;
            }
            return isValid;
        }

        private bool CheckAnswersValidity(List<TextBox> textBoxList)
        {
            bool isValid = true;
            foreach (TextBox answer in textBoxList)
            {
                if (answer.Text.Length <= 0)
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }

        private bool HasGameQuestionChanged()
        {
            bool result = false;
            if (QuestionToEdit.Title != gameQuestionTitleTextBox.Text)
            {
                result = true;
            }
            else if (QuestionToEdit.Order.ToString() != gameQuestionOrderTextBox.Text)
            {
                result = true;
            }
            else if (AnswersToEdit[0].Title != gameFirstAnswerTextBox.Text || AnswersToEdit[0].Solution != rb1.IsChecked)
            {
                result = true;
            }
            else if (AnswersToEdit[1].Title != gameSecondAnswerTextBox.Text || AnswersToEdit[1].Solution != rb2.IsChecked)
            {
                result = true;
            }
            else if (AnswersToEdit[2].Title != gameThirdAnswerTextBox.Text || AnswersToEdit[2].Solution != rb3.IsChecked)
            {
                result = true;
            }
            else if (AnswersToEdit[3].Title != gameFourthAnswerTextBox.Text || AnswersToEdit[3].Solution != rb4.IsChecked)
            {
                result = true;
            }
            return result;
        }

        private bool HasOrientationQuestionChanged()
        {
            bool result = false;
            List<int> firstAnswerJobsIdList = GetCheckedJobsIdList(myFirstJobsPanel);
            List<int> secondAnswerJobsIdList = GetCheckedJobsIdList(mySecondJobsPanel);
            List<int> thirdAnswerJobsIdList = GetCheckedJobsIdList(myThirdJobsPanel);
            if (QuestionToEdit.Title != orientationQuestionTitleTextBox.Text)
            {
                result = true;
            }
            else if (QuestionToEdit.Order.ToString() != orientationQuestionOrderTextBox.Text)
            {
                result = true;
            }
            else if (AnswersToEdit[0].Title != firstOrientationAnswerTextBox.Text || AnswersToEdit[0].LinkedJobs != firstAnswerJobsIdList)
            {
                result = true;
            }
            else if (AnswersToEdit[1].Title != secondOrientationAnswerTextBox.Text || AnswersToEdit[1].LinkedJobs != secondAnswerJobsIdList)
            {
                result = true;
            }
            else if (AnswersToEdit[2].Title != thirdOrientationAnswerTextBox.Text || AnswersToEdit[2].LinkedJobs != thirdAnswerJobsIdList)
            {
                result = true;
            }
            return result;
        }

        private bool IsNumber(string text)
        {
            int result;
            return int.TryParse(text, out result);
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

        private void EditMarketingQuestion(object sender, RoutedEventArgs e)
        {
            // On vérifie s'il y a eu une modification
            if (QuestionToEdit.Title != marketingQuestionTitleTextBox.Text)
            {
                // On vérifie que l'intitulé de la question n'est pas vide
                if (CheckTextBoxValidity(marketingQuestionTitleTextBox))
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

        private void EditGameQuestion(object sender, RoutedEventArgs e)
        {
            // On vérifie qu'il y a eu une modification
            if (HasGameQuestionChanged())
            {
                List<TextBox> answersList = new List<TextBox>();
                answersList.Add(gameFirstAnswerTextBox);
                answersList.Add(gameSecondAnswerTextBox);
                answersList.Add(gameThirdAnswerTextBox);
                answersList.Add(gameFourthAnswerTextBox);
                // On vérifie que tous les champs sont remplis
                if (CheckTextBoxValidity(gameQuestionTitleTextBox) && CheckAnswersValidity(answersList))
                {
                    gameErrorMessage.Visibility = Visibility.Hidden;

                    #region question
                    // On édite l'intitulé de la question s'il a changé
                    if (QuestionToEdit.Title != gameQuestionTitleTextBox.Text)
                    {
                        QuestionToEdit.Title = gameQuestionTitleTextBox.Text;
                    }
                    // On édite l'ordre de la question s'il a changé et si c'est un nombre
                    if (QuestionToEdit.Order.ToString() != gameQuestionOrderTextBox.Text && IsNumber(gameQuestionOrderTextBox.Text))
                    {
                        QuestionToEdit.Order = int.Parse(gameQuestionOrderTextBox.Text);
                    }
                    // On enregistre la modification de la question
                    if (QuestionToEdit.EditQuestion())
                    {
                        // La question a bien été modifiée
                        MessageBox.Show("La question a bien été modifiée.", "Succès");
                    }
                    else
                    {
                        // La question n'a pas été modifiée
                        MessageBox.Show("La question n'a pas été modifiée.", "Erreur");
                    }
                    #endregion

                    #region answers
                    // On édite la réponse 1 si elle a changé
                    if (AnswersToEdit[0].Title != gameFirstAnswerTextBox.Text || AnswersToEdit[0].Solution != rb1.IsChecked)
                    {
                        AnswersToEdit[0].Title = gameFirstAnswerTextBox.Text;
                        AnswersToEdit[0].Solution = (bool)rb1.IsChecked;
                        // On enregistre la modification de la réponse
                        if (AnswersToEdit[0].EditAnswer())
                        {
                            // La réponse 1 a bien été modifiée
                            MessageBox.Show("La réponse 1 a bien été modifiée.", "Succès");
                        }
                        else
                        {
                            // La réponse 1 n'a pas été modifiée
                            MessageBox.Show("La réponse 1 n'a pas été modifiée.", "Erreur");
                        }
                    }

                    // On édite la réponse 2 si elle a changé
                    if (AnswersToEdit[1].Title != gameSecondAnswerTextBox.Text || AnswersToEdit[1].Solution != rb2.IsChecked)
                    {
                        AnswersToEdit[1].Title = gameSecondAnswerTextBox.Text;
                        AnswersToEdit[1].Solution = (bool)rb2.IsChecked;
                        // On enregistre la modification de la réponse
                        if (AnswersToEdit[1].EditAnswer())
                        {
                            // La réponse 2 a bien été modifiée
                            MessageBox.Show("La réponse 2 a bien été modifiée.", "Succès");
                        }
                        else
                        {
                            // La réponse 2 n'a pas été modifiée
                            MessageBox.Show("La réponse 2 n'a pas été modifiée.", "Erreur");
                        }
                    }

                    // On édite la réponse 3 si elle a changé
                    if (AnswersToEdit[2].Title != gameThirdAnswerTextBox.Text || AnswersToEdit[2].Solution != rb3.IsChecked)
                    {
                        AnswersToEdit[2].Title = gameThirdAnswerTextBox.Text;
                        AnswersToEdit[2].Solution = (bool)rb3.IsChecked;
                        // On enregistre la modification de la réponse
                        if (AnswersToEdit[2].EditAnswer())
                        {
                            // La réponse 3 a bien été modifiée
                            MessageBox.Show("La réponse 3 a bien été modifiée.", "Succès");
                        }
                        else
                        {
                            // La réponse 3 n'a pas été modifiée
                            MessageBox.Show("La réponse 3 n'a pas été modifiée.", "Erreur");
                        }
                    }

                    // On édite la réponse 4 si elle a changé
                    if (AnswersToEdit[3].Title != gameFourthAnswerTextBox.Text || AnswersToEdit[3].Solution != rb4.IsChecked)
                    {
                        AnswersToEdit[3].Title = gameFourthAnswerTextBox.Text;
                        AnswersToEdit[3].Solution = (bool)rb4.IsChecked;
                        // On enregistre la modification de la réponse
                        if (AnswersToEdit[3].EditAnswer())
                        {
                            // La réponse 4 a bien été modifiée
                            MessageBox.Show("La réponse 4 a bien été modifiée.", "Succès");
                        }
                        else
                        {
                            // La réponse 4 n'a pas été modifiée
                            MessageBox.Show("La réponse 4 n'a pas été modifiée.", "Erreur");
                        }
                    }
                    #endregion

                    NavigationService.Navigate(new EditQuestionPage());
                }
                else
                {
                    // Message erreur : l'un des champs est vide
                    gameErrorMessage.Text = "Tous les champs (question et réponses) doivent être remplis.";
                    gameErrorMessage.Visibility = Visibility.Visible;
                }
            }
            // Sinon on ne fait rien et on l'indique à l'utilisateur
            else
            {
                MessageBox.Show("Aucune modification à effectuer.");
            }
        }

        private void EditOrientationQuestion(object sender, RoutedEventArgs e)
        {
            // On vérifie qu'il y a eu une modification
            if (HasOrientationQuestionChanged())
            {
                List<TextBox> answersList = new List<TextBox>();
                answersList.Add(firstOrientationAnswerTextBox);
                answersList.Add(secondOrientationAnswerTextBox);
                answersList.Add(thirdOrientationAnswerTextBox);
                // On vérifie que tous les champs sont remplis
                if (CheckTextBoxValidity(orientationQuestionTitleTextBox) && CheckAnswersValidity(answersList))
                {
                    orientationErrorMessage.Visibility = Visibility.Hidden;

                    #region question
                    // On édite l'intitulé de la question s'il a changé
                    if (QuestionToEdit.Title != orientationQuestionTitleTextBox.Text)
                    {
                        QuestionToEdit.Title = orientationQuestionTitleTextBox.Text;
                    }
                    // On édite l'ordre de la question s'il a changé et si c'est un nombre
                    if (QuestionToEdit.Order.ToString() != orientationQuestionOrderTextBox.Text && IsNumber(orientationQuestionOrderTextBox.Text))
                    {
                        QuestionToEdit.Order = int.Parse(orientationQuestionOrderTextBox.Text);
                    }
                    // On enregistre la modification de la question
                    if (QuestionToEdit.EditQuestion())
                    {
                        // La question a bien été modifiée
                        MessageBox.Show("La question a bien été modifiée.", "Succès");
                    }
                    else
                    {
                        // La question n'a pas été modifiée
                        MessageBox.Show("La question n'a pas été modifiée.", "Erreur");
                    }
                    #endregion

                    #region answers
                    // On gère les réponses une à une
                    List<int> firstAnswerJobsIdList = GetCheckedJobsIdList(myFirstJobsPanel);
                    List<int> secondAnswerJobsIdList = GetCheckedJobsIdList(mySecondJobsPanel);
                    List<int> thirdAnswerJobsIdList = GetCheckedJobsIdList(myThirdJobsPanel);

                    // On vérifie que chaque réponse a bien un métier lié
                    if (firstAnswerJobsIdList.Count > 0 && secondAnswerJobsIdList.Count > 0 && thirdAnswerJobsIdList.Count > 0)
                    {
                        orientationErrorMessage.Visibility = Visibility.Hidden;

                        #region answer 1
                        // Réponse 1 : on vérifie que l'intitulé a changé
                        if (AnswersToEdit[0].Title != firstOrientationAnswerTextBox.Text)
                        {
                            AnswersToEdit[0].Title = firstOrientationAnswerTextBox.Text;
                            // On enregistre en base
                            if (AnswersToEdit[0].EditAnswer())
                            {
                                // La réponse 1 a bien été modifiée
                                MessageBox.Show("La réponse 1 a bien été modifiée.", "Succès");
                            }
                            else
                            {
                                // La réponse 1 n'a pas été modifiée
                                MessageBox.Show("La réponse 1 n'a pas été modifiée.", "Erreur");
                            }
                        }
                        //  Réponse 1 : on vérifie que ses métiers liés ont changé
                        if (AnswersToEdit[0].LinkedJobs != firstAnswerJobsIdList)
                        {
                            // On supprime les anciennes correspondances
                            if (AnswersToEdit[0].DeleteLinkedJobs())
                            {
                                AnswersToEdit[0].LinkedJobs = firstAnswerJobsIdList;
                                //  On ajoute les nouvelles correspondances
                                if (AnswersToEdit[0].AddLinkedJobs(firstAnswerJobsIdList))
                                {
                                    // Les métiers liés de la réponse 1 ont bien été modifiés
                                    MessageBox.Show("Les métiers liés de la réponse 1 ont bien été modifiés.", "Succès");
                                }
                                else
                                {
                                    // Les métiers liés de la réponse 1 n'ont pas été modifiés
                                    MessageBox.Show("Les métiers liés de la réponse 1 n'ont pas été modifiés.\n" +
                                        "Erreur lors de l'ajout des nouveaux métiers liés.", "Erreur");
                                }
                            }
                            else
                            {
                                // Les métiers liés de la réponse 1 n'ont pas été modifiés
                                MessageBox.Show("Les métiers liés de la réponse 1 n'ont pas été modifiés.\n" +
                                    "Erreur lors de la suppression des anciens métiers liés.", "Erreur");
                            }
                        }
                        #endregion

                        #region answer 2
                        // Réponse 2 : on vérifie que l'intitulé a changé
                        if (AnswersToEdit[1].Title != secondOrientationAnswerTextBox.Text)
                        {
                            AnswersToEdit[1].Title = secondOrientationAnswerTextBox.Text;
                            // On enregistre en base
                            if (AnswersToEdit[1].EditAnswer())
                            {
                                // La réponse 2 a bien été modifiée
                                MessageBox.Show("La réponse 2 a bien été modifiée.", "Succès");
                            }
                            else
                            {
                                // La réponse 2 n'a pas été modifiée
                                MessageBox.Show("La réponse 2 n'a pas été modifiée.", "Erreur");
                            }
                        }
                        //  Réponse 2 : on vérifie que ses métiers liés ont changé
                        if (AnswersToEdit[1].LinkedJobs != secondAnswerJobsIdList)
                        {
                            // On supprime les anciennes correspondances
                            if (AnswersToEdit[1].DeleteLinkedJobs())
                            {
                                AnswersToEdit[1].LinkedJobs = secondAnswerJobsIdList;
                                //  On ajoute les nouvelles correspondances
                                if (AnswersToEdit[1].AddLinkedJobs(secondAnswerJobsIdList))
                                {
                                    // Les métiers liés de la réponse 2 ont bien été modifiés
                                    MessageBox.Show("Les métiers liés de la réponse 2 ont bien été modifiés.", "Succès");
                                }
                                else
                                {
                                    // Les métiers liés de la réponse 2 n'ont pas été modifiés
                                    MessageBox.Show("Les métiers liés de la réponse 2 n'ont pas été modifiés.\n" +
                                        "Erreur lors de l'ajout des nouveaux métiers liés.", "Erreur");
                                }
                            }
                            else
                            {
                                // Les métiers liés de la réponse 2 n'ont pas été modifiés
                                MessageBox.Show("Les métiers liés de la réponse 2 n'ont pas été modifiés.\n" +
                                    "Erreur lors de la suppression des anciens métiers liés.", "Erreur");
                            }
                        }
                        #endregion

                        #region answer 3
                        // Réponse 3 : on vérifie que l'intitulé a changé
                        if (AnswersToEdit[2].Title != thirdOrientationAnswerTextBox.Text)
                        {
                            AnswersToEdit[2].Title = thirdOrientationAnswerTextBox.Text;
                            // On enregistre en base
                            if (AnswersToEdit[2].EditAnswer())
                            {
                                // La réponse 3 a bien été modifiée
                                MessageBox.Show("La réponse 3 a bien été modifiée.", "Succès");
                            }
                            else
                            {
                                // La réponse 3 n'a pas été modifiée
                                MessageBox.Show("La réponse 3 n'a pas été modifiée.", "Erreur");
                            }
                        }
                        //  Réponse 3 : on vérifie que ses métiers liés ont changé
                        if (AnswersToEdit[2].LinkedJobs != thirdAnswerJobsIdList)
                        {
                            // On supprime les anciennes correspondances
                            if (AnswersToEdit[2].DeleteLinkedJobs())
                            {
                                AnswersToEdit[2].LinkedJobs = thirdAnswerJobsIdList;
                                //  On ajoute les nouvelles correspondances
                                if (AnswersToEdit[2].AddLinkedJobs(thirdAnswerJobsIdList))
                                {
                                    // Les métiers liés de la réponse 3 ont bien été modifiés
                                    MessageBox.Show("Les métiers liés de la réponse 3 ont bien été modifiés.", "Succès");
                                }
                                else
                                {
                                    // Les métiers liés de la réponse 3 n'ont pas été modifiés
                                    MessageBox.Show("Les métiers liés de la réponse 3 n'ont pas été modifiés.\n" +
                                        "Erreur lors de l'ajout des nouveaux métiers liés.", "Erreur");
                                }
                            }
                            else
                            {
                                // Les métiers liés de la réponse 3 n'ont pas été modifiés
                                MessageBox.Show("Les métiers liés de la réponse 3 n'ont pas été modifiés.\n" +
                                    "Erreur lors de la suppression des anciens métiers liés.", "Erreur");
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        // Message erreur : au moins l'une des réponses n'a pas de métier lié
                        orientationErrorMessage.Text = "Toutes les réponses doivent avoir au moins un métier lié.";
                        orientationErrorMessage.Visibility = Visibility.Visible;
                    }
                    #endregion

                    NavigationService.Navigate(new EditQuestionPage());
                }
                else
                {
                    // Message erreur : l'un des champs est vide
                    orientationErrorMessage.Text = "Tous les champs (question et réponses) doivent être remplis.";
                    orientationErrorMessage.Visibility = Visibility.Visible;
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
