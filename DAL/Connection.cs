using System.Data.SqlClient;

namespace Session2.DAL
{
    internal class Connection
    {
        private static readonly string ConnectionString = "server=DESKTOP-JIJLT7T;initial catalog=Ssession2;user=sqlmontes;password=123456;";

        public static SqlConnection GetConnection() => new(ConnectionString);

    }
}
