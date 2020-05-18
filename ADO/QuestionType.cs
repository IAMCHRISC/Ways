using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO
{
    public class QuestionType
    {
        private int id;
        private string type;

        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }

        public static List<QuestionType> GetQuestionTypes()
        {
            List<QuestionType> questionTypes = new List<QuestionType>();
            string request = "SELECT * FROM T_Question_Type";
            command = new SqlCommand(request, DataBase.connection);
            DataBase.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                QuestionType type = new QuestionType
                {
                    Id = reader.GetInt32(0),
                    Type = reader.GetString(1)
                };
                questionTypes.Add(type);
            }
            reader.Close();
            command.Dispose();
            DataBase.connection.Close();
            return questionTypes;
        }
    }
}
