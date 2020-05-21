using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO
{
    public class Questions
    {
        private int id;
        private string title;
        private int order;
        private int type;

        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public int Order { get => order; set => order = value; }
        public int Type { get => type; set => type = value; }

        public static List<Questions> GetQuestionsByType(int type)
        {
            List<Questions> questionsList = new List<Questions>();
            string request = "SELECT id_question, entitled, [order], id_question_type FROM T_Questions " +
                "WHERE id_question_type = @question_type " +
                "AND active = 'True'";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@question_type", type));
            DataBase.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Questions question = new Questions
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Order = reader.GetInt32(2),
                    Type = reader.GetInt32(3)
                };
                questionsList.Add(question);
            }
            reader.Close();
            command.Dispose();
            DataBase.connection.Close();
            return questionsList;
        }

        public static List<Questions> GetActiveQuestions()
        {
            List<Questions> questionsList = new List<Questions>();
            string request = "SELECT id_question, entitled, id_question_type FROM T_Questions WHERE active = 'True'";
            command = new SqlCommand(request, DataBase.connection);
            DataBase.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Questions question = new Questions
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Type = reader.GetInt32(2)
                };
                questionsList.Add(question);
            }
            reader.Close();
            command.Dispose();
            DataBase.connection.Close();
            return questionsList;
        }

        public static bool DeleteById(int id)
        {
            bool result = false;
            string request = "UPDATE T_Questions SET active = 'False' WHERE id_question = @id";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            DataBase.connection.Open();
            result = command.ExecuteNonQuery() > 0;
            command.Dispose();
            DataBase.connection.Close();
            return result;
        }

        public bool AddQuestion()
        {
            string request = "INSERT INTO T_Questions (entitled, [order], active, id_question_type) " +
                "OUTPUT INSERTED.ID_QUESTION " +
                "VALUES (@title, @order, @active, @type)";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@title", Title));
            command.Parameters.Add(new SqlParameter("@order", 1)); // On ne gère pas encore l'ordre
            command.Parameters.Add(new SqlParameter("@active", true)); // Une question ajoutée est active par défaut
            command.Parameters.Add(new SqlParameter("@type", Type));
            DataBase.connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            DataBase.connection.Close();
            return Id > 0;
        }
    }
}
