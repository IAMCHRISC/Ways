using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO
{
    public class Jobs
    {
        private int id;
        private string title;
        private string description;

        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }

        public static List<int> GetIdsByAnswerId(int answerId)
        {
            List<int> jobsIdList = new List<int>();
            string request = "SELECT id_job from T_Appartenir " +
                "WHERE id_answer = @answerId";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@answerId", answerId));
            DataBase.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                int jobId = reader.GetInt32(0);
                jobsIdList.Add(jobId);
            }
            reader.Close();
            command.Dispose();
            DataBase.connection.Close();
            return jobsIdList;
        }

        public static Jobs GetJobById(int id)
        {
            Jobs job = null;
            string request = "SELECT id_job, job_name, job_description FROM T_Job " +
                "WHERE id_job = @id";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            DataBase.connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                job = new Jobs
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Description = reader.GetString(2)
                };
            }
            reader.Close();
            command.Dispose();
            DataBase.connection.Close();
            return job;
        }
    }
}
