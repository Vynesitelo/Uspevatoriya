using System.Data.SqlClient;

namespace Успеватория
{
    public class DBConnection
    {
        public static SqlConnection Connect()
        {
            return new SqlConnection("Trusted_Connection=True;Initial Catalog=sqlUspevatoriya;Server=localhost");
        }
    }
}
