using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO
{
    public class Administrator
    {
        private static SqlCommand command;
        public static bool LoginVerification(string username, string password)
        {
            string request = "SELECT COUNT(id_login) FROM T_Login WHERE username = @username AND password = @password";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@username", username));
            command.Parameters.Add(new SqlParameter("@password", password));
            DataBase.connection.Open();
            if ((int)command.ExecuteScalar() > 0)
            {
                DataBase.connection.Close();
                return true;
            }
            else
            {
                DataBase.connection.Close();
                return false;
            };
        }
    }
}
