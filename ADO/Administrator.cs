using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO
{
    public class Administrator
    {
        private static string emailAddress = "test@viacesi.fr";
        private static string emailPassword = "TestViacesi123";
        private static string orientationObject = "Résultats du test d'orientation - Plateforme Ways - CESI Alternance";
        private static string orientationMessage = ", tu trouveras ci-dessous tes résultats au test d'orientation que tu viens d'effectuer sur la plateforme Ways.";
        private static string gameObject = " t'invite aux JPO du CESI Alternance, pourras-tu faire mieux que lui au test de connaissances ?";
        private static string gameMessage = " vient de participer à notre test de connaissances en informatique lors de sa venue à nos journées portes ouvertes, " +
                "pourras-tu faire mieux que lui ?\nViens découvrir l'école, les formations qui sont proposées et les débouchés lors de nos JPO, " +
                "les 5 et 6 décembre prochains !";

        private static SqlCommand command;

        public static string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public static string EmailPassword { get => emailPassword; set => emailPassword = value; }
        public static string OrientationObject { get => orientationObject; set => orientationObject = value; }
        public static string OrientationMessage { get => orientationMessage; set => orientationMessage = value; }
        public static string GameObject { get => gameObject; set => gameObject = value; }
        public static string GameMessage { get => gameMessage; set => gameMessage = value; }

        public Administrator()
        {
            EmailAddress = "test@viacesi.fr";
            EmailPassword = "TestViacesi123";
            OrientationObject = "Résultats du test d'orientation - Plateforme Ways - CESI Alternance";
            OrientationMessage = ", tu trouveras ci-dessous tes résultats au test d'orientation que tu viens d'effectuer sur la plateforme Ways.";
            GameObject = " t'invite aux JPO du CESI Alternance, pourras-tu faire mieux que lui au test de connaissances ?";
            GameMessage = " vient de participer à notre test de connaissances en informatique lors de sa venue à nos journées portes ouvertes, " +
                "pourras-tu faire mieux que lui ?\nViens découvrir l'école, les formations qui sont proposées et les débouchés lors de nos JPO, " +
                "les 5 et 6 décembre prochains !";
        }

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
