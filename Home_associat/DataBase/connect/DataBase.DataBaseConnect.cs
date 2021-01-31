using System.Data.SqlClient;

namespace Home_assoc
{
    static partial class DataBase
    {
        static internal class DataBaseConnect
        {
            static internal SqlConnection Connect()
            {
                try
                {
                    return new SqlConnection(DataBaseConstants.connectionString);
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
