using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADO
{
    public class Marketing
    {
        public static SqlCommand command;
        public static DataTable display_question()
        {
            DataTable dt = new DataTable();
            string request = "SELECT entitled FROM T_Questions WHERE id_question_type = 3";
            command = new SqlCommand(request, DataBase.connection);
            DataBase.connection.Open();
            dt.Load(command.ExecuteReader());
            DataBase.connection.Close();

            return dt;
        }

        public static bool save(string rep1, string rep2, string rep3, string rep4, string rep5, string rep6, string rep7, string rep8, string rep9, string rep10)
        {
            string request = "INSERT INTO T_Additional_Info VALUES (@rep1, @rep2, @rep3, @rep4, @rep5, @rep6, @rep7, @rep8, @rep9, @rep10)";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@rep1", rep1));
            command.Parameters.Add(new SqlParameter("@rep2", rep2));
            command.Parameters.Add(new SqlParameter("@rep3", rep3));
            command.Parameters.Add(new SqlParameter("@rep4", rep4));
            command.Parameters.Add(new SqlParameter("@rep5", rep5));
            command.Parameters.Add(new SqlParameter("@rep6", rep6));
            command.Parameters.Add(new SqlParameter("@rep7", rep7));
            command.Parameters.Add(new SqlParameter("@rep8", rep8));
            command.Parameters.Add(new SqlParameter("@rep9", rep9));
            command.Parameters.Add(new SqlParameter("@rep10", rep10));
            DataBase.connection.Open();
            int a = command.ExecuteNonQuery();
            DataBase.connection.Close();
            if (a == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}