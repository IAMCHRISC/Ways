using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO
{
    public class Answers
    {
        private int id;
        private string title;
        private bool solution;
        private int questionId;

        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public bool Solution { get => solution; set => solution = value; }
        public int QuestionId { get => questionId; set => questionId = value; }

        public static List<Answers> GetAnswersByQuestionId(int questionId)
        {
            List<Answers> answersList = new List<Answers>();
            string request = "SELECT id_answer, entitled, solution, id_question FROM T_Answers " +
                "WHERE id_question = @questionId " +
                "AND active = 'True'";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@questionId", questionId));
            DataBase.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Answers answer = new Answers
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Solution = reader.GetBoolean(2),
                    QuestionId = reader.GetInt32(3)
                };
                answersList.Add(answer);
            }
            reader.Close();
            command.Dispose();
            DataBase.connection.Close();
            return answersList;
        }

        public static bool DeleteById(int questionId)
        {
            bool result = false;
            string request = "UPDATE T_Answers SET active = 'False' WHERE id_question = @id";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@id", questionId));
            DataBase.connection.Open();
            result = command.ExecuteNonQuery() > 0;
            command.Dispose();
            DataBase.connection.Close();
            return result;
        }

        public bool AddAnswer()
        {
            string request = "INSERT INTO T_Answers (entitled, solution, active, id_question) " +
                "OUTPUT INSERTED.ID_ANSWER " +
                "VALUES (@title, @solution, @active, @questionId)";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@title", Title));
            command.Parameters.Add(new SqlParameter("@solution", Solution));
            command.Parameters.Add(new SqlParameter("@active", true)); // Une réponse ajoutée est active par défaut
            command.Parameters.Add(new SqlParameter("@questionId", QuestionId));
            DataBase.connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            DataBase.connection.Close();
            return Id > 0;
        }
    }
}
