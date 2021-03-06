﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO
{
    public class Jeu
    {
        private static SqlCommand command;
        public static int score;
        public static bool verif_cash(int id_question, string reponse)
        {
            int count;
            if (reponse.Length > 0)
            {
                string request = "SELECT COUNT(id_answer) FROM T_Answers WHERE id_question = @id_question AND UPPER(entitled) = UPPER(@reponse) AND solution = 'true'";
                command = new SqlCommand(request, DataBase.connection);
                command.Parameters.Add(new SqlParameter("@id_question", id_question));
                command.Parameters.Add(new SqlParameter("@reponse", reponse));
                DataBase.connection.Open();
                count = (int)command.ExecuteScalar();
                DataBase.connection.Close();

                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string corrige_cash(int id_question)
        {
            string result;
            string request = "SELECT entitled FROM T_Answers WHERE id_question = @id_question AND solution = 'true'";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@id_question", id_question));
            DataBase.connection.Open();
            result = (string)command.ExecuteScalar();
            DataBase.connection.Close();
            return result;
        }

        public static bool save_score(string username, int score)
        {
            bool result = false;
            string request = "INSERT INTO T_Score VALUES (@username, @score, getdate()); SELECT @@identity";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@username", username));
            command.Parameters.Add(new SqlParameter("@score", score));
            DataBase.connection.Open();
            int a = command.ExecuteNonQuery();
            if (a == 1)
            {
                result = true;
            }
            DataBase.connection.Close();
            return result;
        }

        public static int average_scores()
        {
            int retval;
            string request = "SELECT AVG(score) FROM T_Score";
            command = new SqlCommand(request, DataBase.connection);
            DataBase.connection.Open();
            retval = (int)command.ExecuteScalar();
            DataBase.connection.Close();
            return retval;
        }

        public static int total_participation()
        {
            int retval;
            string request = "SELECT COUNT(id_score) FROM T_Score";
            command = new SqlCommand(request, DataBase.connection);
            DataBase.connection.Open();
            retval = (int)command.ExecuteScalar();
            DataBase.connection.Close();
            return retval;
        }
    }
}