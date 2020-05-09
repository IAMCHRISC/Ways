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
            if(((Button)sender).Name == "btn_duo")
            {
                btn_carre.Visibility = Visibility.Hidden;
                btn_cash.Visibility = Visibility.Hidden;
                btn_reponse1.Visibility = Visibility.Visible;
                btn_reponse2.Visibility = Visibility.Visible;

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

                question_type = "Carre";
                display_possible_choices(4);
            }
            if (((Button)sender).Name == "btn_cash")
            {
                btn_duo.Visibility = Visibility.Hidden;
                btn_carre.Visibility = Visibility.Hidden;
                txt_cash.Visibility = Visibility.Visible;
                btn_valid_cash.Visibility = Visibility.Visible;

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

            while (dr.Read())
            {
                lbl_question.Content = dr.GetString(1);
                hidden_id_question.Content = dr.GetInt32(0);
            }

            DataBase.connection.Close();
        }

        private void display_possible_choices(int nb_choice)
        {
            if(nb_choice == 2)
            {

                SqlDataReader dr;
                string request = "SELECT solution, entitled FROM T_Answers WHERE id_question = @id_question";
                command = new SqlCommand(request, DataBase.connection);
                command.Parameters.Add(new SqlParameter("@id_question", hidden_id_question.Content));
                DataBase.connection.Open();
                dr = command.ExecuteReader();

                Random aleatoire = new Random();
                int id_lbl_reponse = aleatoire.Next(1, 2);
                bool good_answer_display = false;
                bool nb_answer_at_2 = false;

                while (dr.Read())
                {
                    if(id_lbl_reponse == 1)
                    {
                        btn_reponse1.Content = dr.GetString(1);
                        hidden_reponse1.Content = dr.GetBoolean(0);
                        
                        if(dr.GetBoolean(0) == true)
                        {
                            good_answer_display = true;
                        }
                    }

                    if(id_lbl_reponse == 2)
                    {
                        btn_reponse2.Content = dr.GetString(1);
                        hidden_reponse2.Content = dr.GetBoolean(0);
                        
                        if (dr.GetBoolean(0) == true)
                        {
                            good_answer_display = true;
                        }
                    }

                    if(id_lbl_reponse == 2)
                    {
                        id_lbl_reponse = 1;
                    }
                    else
                    {
                        id_lbl_reponse = 2;
                    }

                    if((string)btn_reponse1.Content != "" && (string)btn_reponse2.Content != "")
                    {
                        nb_answer_at_2 = true;
                    }

                    if ((good_answer_display == true) & (nb_answer_at_2 == true))
                    {
                        break;
                    }
                }

            }
            if(nb_choice == 4)
            {

            }
        }
    }
}
