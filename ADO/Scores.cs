using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO
{
    public class Scores
    {
        private int rank;
        private int id;
        private string username;
        private int score;
        private DateTime date;

        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Rank { get => rank; set => rank = value; }
        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public int Score { get => score; set => score = value; }
        public DateTime Date { get => date; set => date = value; }

        public static List<Scores> GetLadder()
        {
            List<Scores> scoresList = new List<Scores>();
            string request = "SELECT RANK() OVER (ORDER BY score DESC) AS rank, id_score, username, score, date FROM T_Score";
            command = new SqlCommand(request, DataBase.connection);
            DataBase.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Scores score = new Scores
                {
                    Rank = (int)reader.GetInt64(0),
                    Id = reader.GetInt32(1),
                    Username = reader.GetString(2),
                    Score = reader.GetInt32(3),
                    Date = reader.GetDateTime(4)
                };
                scoresList.Add(score);
            }
            reader.Close();
            command.Dispose();
            DataBase.connection.Close();
            return scoresList;
        }

        public bool EditScore()
        {
            bool result = false;
            string request = "UPDATE T_Score " +
                "SET username = @username, score = @score " +
                "WHERE id_score = @id";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@username", Username));
            command.Parameters.Add(new SqlParameter("@score", Score));
            command.Parameters.Add(new SqlParameter("@id", Id));
            DataBase.connection.Open();
            result = command.ExecuteNonQuery() > 0;
            command.Dispose();
            DataBase.connection.Close();
            return result;
        }
    }
}
