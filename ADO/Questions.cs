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
                "AND active = TRUE";
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
    }
}
