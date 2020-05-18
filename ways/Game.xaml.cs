using ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ways
{
    /// <summary>
    /// Logique d'interaction pour Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public SqlCommand command;
        public string question_type;
        public Game()
        {
            InitializeComponent();
            lauch_game();
        }

        private void btn_type_reponse_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Name == "btn_duo")
            {
                btn_carre.Visibility = Visibility.Hidden;
                btn_cash.Visibility = Visibility.Hidden;
                btn_reponse1.Visibility = Visibility.Visible;
                btn_reponse2.Visibility = Visibility.Visible;
                btn_duo.IsEnabled = false;

                question_type = "Duo";
                display_possible_choices(2);
            }
            if (((Button)sender).Name == "btn_carre")
            {
                btn_duo.Visibility = Visibility.Hidden;
                btn_cash.Visibility = Visibility.Hidden;
                btn_reponse1.Visibility = Visibility.Visible;
                btn_reponse2.Visibility = Visibility.Visible;
                btn_reponse3.Visibility = Visibility.Visible;
                btn_reponse4.Visibility = Visibility.Visible;
                btn_carre.IsEnabled = false;

                question_type = "Carre";
                display_possible_choices(4);
            }
            if (((Button)sender).Name == "btn_cash")
            {
                btn_duo.Visibility = Visibility.Hidden;
                btn_carre.Visibility = Visibility.Hidden;
                txt_cash.Visibility = Visibility.Visible;
                btn_valid_cash.Visibility = Visibility.Visible;
                btn_cash.IsEnabled = false;

                question_type = "Cash";
            }
        }

        private void lauch_game()
        {
            display_question();
        }

        private void display_question()
        {
            SqlDataReader dr;
            string request = "SELECT TOP 1 id_question, entitled FROM T_Questions WHERE id_question > @id_question AND id_question_type = 2";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@id_question", hidden_id_question.Content));
            DataBase.connection.Open();
            dr = command.ExecuteReader();

            lbl_question.Content = "";

            while (dr.Read())
            {
                lbl_question.Content = dr.GetString(1);
                hidden_id_question.Content = dr.GetInt32(0);
            }

            if (lbl_question.Content == "")
            {
                Jeu.score = (int)lbl_score.Content;
                EndGameWindow fenetre = new EndGameWindow();
                fenetre.Show();
                this.Close();
            }
            DataBase.connection.Close();
        }

        private void verif_choice(object sender, RoutedEventArgs e)
        {
            if (btn_reponse1.Background == Brushes.White && btn_reponse2.Background == Brushes.White && btn_reponse3.Background == Brushes.White && btn_reponse4.Background == Brushes.White)
            {
                switch (((Button)sender).Name)
                {
                    case "btn_reponse1":
                        if ((Boolean)hidden_reponse1.Content == true)
                        {
                            btn_reponse1.Background = Brushes.Green;
                            if (question_type == "Duo")
                            {
                                lbl_score.Content = int.Parse(lbl_score.Content.ToString()) + 1;
                            }
                            if (question_type == "Carre")
                            {
                                lbl_score.Content = int.Parse(lbl_score.Content.ToString()) + 3;
                            }
                        }
                        else
                        {
                            btn_reponse1.Background = Brushes.Red;
                            if ((Boolean)hidden_reponse2.Content == true)
                            {
                                btn_reponse2.Background = Brushes.Green;
                            }
                            if (question_type == "Carre")
                            {
                                if ((Boolean)hidden_reponse3.Content == true)
                                {
                                    btn_reponse3.Background = Brushes.Green;
                                }
                                if ((Boolean)hidden_reponse4.Content == true)
                                {
                                    btn_reponse4.Background = Brushes.Green;
                                }
                            }
                        }
                        break;
                    case "btn_reponse2":
                        if ((Boolean)hidden_reponse2.Content == true)
                        {
                            btn_reponse2.Background = Brushes.Green;

                            if (question_type == "Duo")
                            {
                                lbl_score.Content = int.Parse(lbl_score.Content.ToString()) + 1;
                            }
                            if (question_type == "Carre")
                            {
                                lbl_score.Content = int.Parse(lbl_score.Content.ToString()) + 3;
                            }
                        }
                        else
                        {
                            btn_reponse2.Background = Brushes.Red;
                            if ((Boolean)hidden_reponse1.Content == true)
                            {
                                btn_reponse1.Background = Brushes.Green;
                            }
                            if (question_type == "Carre")
                            {
                                if ((Boolean)hidden_reponse3.Content == true)
                                {
                                    btn_reponse3.Background = Brushes.Green;
                                }
                                if ((Boolean)hidden_reponse4.Content == true)
                                {
                                    btn_reponse4.Background = Brushes.Green;
                                }
                            }
                        }
                        break;
                    case "btn_reponse3":
                        if ((Boolean)hidden_reponse3.Content == true)
                        {
                            btn_reponse3.Background = Brushes.Green;

                            if (question_type == "Duo")
                            {
                                lbl_score.Content = int.Parse(lbl_score.Content.ToString()) + 1;
                            }
                            if (question_type == "Carre")
                            {
                                lbl_score.Content = int.Parse(lbl_score.Content.ToString()) + 3;
                            }
                        }
                        else
                        {
                            btn_reponse3.Background = Brushes.Red;
                            if ((Boolean)hidden_reponse1.Content == true)
                            {
                                btn_reponse1.Background = Brushes.Green;
                            }
                            if ((Boolean)hidden_reponse2.Content == true)
                            {
                                btn_reponse2.Background = Brushes.Green;
                            }
                            if ((Boolean)hidden_reponse4.Content == true)
                            {
                                btn_reponse4.Background = Brushes.Green;
                            }
                        }
                        break;
                    case "btn_reponse4":
                        if ((Boolean)hidden_reponse4.Content == true)
                        {
                            btn_reponse4.Background = Brushes.Green;

                            if (question_type == "Duo")
                            {
                                lbl_score.Content = int.Parse(lbl_score.Content.ToString()) + 1;
                            }
                            if (question_type == "Carre")
                            {
                                lbl_score.Content = int.Parse(lbl_score.Content.ToString()) + 3;
                            }
                        }
                        else
                        {
                            btn_reponse4.Background = Brushes.Red;
                            if ((Boolean)hidden_reponse2.Content == true)
                            {
                                btn_reponse1.Background = Brushes.Green;
                            }
                            if ((Boolean)hidden_reponse3.Content == true)
                            {
                                btn_reponse3.Background = Brushes.Green;
                            }
                            if ((Boolean)hidden_reponse1.Content == true)
                            {
                                btn_reponse1.Background = Brushes.Green;
                            }
                        }
                        break;
                    default:
                        break;
                }
                btn_question_suivante.Visibility = Visibility.Visible;
            }

        }

        private void display_possible_choices(int nb_choice)
        {
            SqlDataReader dr;
            string request = "SELECT solution, entitled FROM T_Answers WHERE id_question = @id_question";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@id_question", hidden_id_question.Content));
            DataBase.connection.Open();
            dr = command.ExecuteReader();

            if (nb_choice == 2)
            {
                Random aleatoire = new Random();
                int id_lbl_reponse = aleatoire.Next(1, 2);
                bool good_answer_display = false;
                bool nb_answer_at_2 = false;

                while (dr.Read())
                {
                    if (id_lbl_reponse == 1)
                    {
                        btn_reponse1.Content = dr.GetString(1);
                        hidden_reponse1.Content = dr.GetBoolean(0);

                        if (dr.GetBoolean(0) == true)
                        {
                            good_answer_display = true;
                        }
                    }

                    if (id_lbl_reponse == 2)
                    {
                        btn_reponse2.Content = dr.GetString(1);
                        hidden_reponse2.Content = dr.GetBoolean(0);

                        if (dr.GetBoolean(0) == true)
                        {
                            good_answer_display = true;
                        }
                    }

                    if (id_lbl_reponse == 2)
                    {
                        id_lbl_reponse = 1;
                    }
                    else
                    {
                        id_lbl_reponse = 2;
                    }

                    if ((string)btn_reponse1.Content != "" && (string)btn_reponse2.Content != "")
                    {
                        nb_answer_at_2 = true;
                    }

                    if ((good_answer_display == true) & (nb_answer_at_2 == true))
                    {
                        break;
                    }
                }

            }
            if (nb_choice == 4)
            {
                int btn_number = 1;

                while (dr.Read())
                {
                    switch (btn_number)
                    {
                        case 1:
                            btn_reponse1.Content = dr.GetString(1);
                            hidden_reponse1.Content = dr.GetBoolean(0);
                            btn_number++;
                            break;
                        case 2:
                            btn_reponse2.Content = dr.GetString(1);
                            hidden_reponse2.Content = dr.GetBoolean(0);
                            btn_number++;
                            break;
                        case 3:
                            btn_reponse3.Content = dr.GetString(1);
                            hidden_reponse3.Content = dr.GetBoolean(0);
                            btn_number++;
                            break;
                        case 4:
                            btn_reponse4.Content = dr.GetString(1);
                            hidden_reponse4.Content = dr.GetBoolean(0);
                            btn_number++;
                            break;
                        default:
                            break;
                    }
                }
            }

            DataBase.connection.Close();
        }

        private void btn_question_suivante_Click(object sender, RoutedEventArgs e)
        {
            btn_carre.IsEnabled = true;
            btn_duo.IsEnabled = true;
            btn_cash.IsEnabled = true;

            btn_duo.Visibility = Visibility.Visible;
            btn_carre.Visibility = Visibility.Visible;
            btn_cash.Visibility = Visibility.Visible;

            btn_reponse1.Background = Brushes.White;
            btn_reponse2.Background = Brushes.White;
            btn_reponse3.Background = Brushes.White;
            btn_reponse4.Background = Brushes.White;

            btn_reponse1.Visibility = Visibility.Hidden;
            btn_reponse2.Visibility = Visibility.Hidden;
            btn_reponse3.Visibility = Visibility.Hidden;
            btn_reponse4.Visibility = Visibility.Hidden;

            txt_cash.Visibility = Visibility.Hidden;
            txt_cash.Text = "";
            txt_cash.Background = Brushes.White;
            btn_valid_cash.Visibility = Visibility.Hidden;

            btn_question_suivante.Visibility = Visibility.Hidden;

            display_question();
        }

        private void btn_valid_cash_Click(object sender, RoutedEventArgs e)
        {
            bool verif;
            verif = Jeu.verif_cash((int)hidden_id_question.Content, (string)txt_cash.Text.ToString());
            if (verif == true)
            {
                txt_cash.Background = Brushes.Green;
                lbl_score.Content = int.Parse(lbl_score.Content.ToString()) + 5;
            }
            else
            {
                txt_cash.Text = Jeu.corrige_cash((int)hidden_id_question.Content);
                txt_cash.Background = Brushes.Red;
            }
            btn_question_suivante.Visibility = Visibility.Visible;
        }
    }
}