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
    }
}
