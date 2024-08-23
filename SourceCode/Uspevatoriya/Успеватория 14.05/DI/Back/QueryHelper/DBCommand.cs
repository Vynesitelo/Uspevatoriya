using System.Data;
using System.Data.SqlClient;

namespace Успеватория
{
    public class DBCommand
    {

        public static DataTable ExecuteCommand(string cmd)
        {
            using (SqlConnection conn = DBConnection.Connect())
            {
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd, conn);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                if (dataSet.Tables.Count > 0)
                {
                    return dataSet.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
