using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO
{
    public class Jeu
    {
        private static SqlCommand command;
        public static bool verif_cash(int id_question, string reponse)
        {
            int count;
            string request = "SELECT COUNT(id_answer) FROM T_Answers WHERE id_question = @id_question AND entitled LIKE @reponse AND solution = 'true'";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@id_question", id_question));
            command.Parameters.Add(new SqlParameter("@reponse", '%' + reponse + '%'));
            DataBase.connection.Open();
            count = (int)command.ExecuteScalar();
            DataBase.connection.Close();

            if(count == 1)
            {
                return true;
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

            return result;
        }
    }
}
