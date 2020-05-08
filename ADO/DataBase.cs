using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class DataBase
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\Ways;Initial Catalog=master;Integrated Security=True");
    }
}
