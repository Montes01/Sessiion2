using System.Data.SqlClient;

namespace Session2.DAL
{
    internal class Connection
    {
        private static readonly string ConnectionString = "server=DESKTOP-JIJLT7T;initial catalog=Ssession2;user=sqlmontes;password=123456;";

        private static readonly string SeccondConnectionString = "server=Fabrica1\\SQLEXPRESS;initial catalog=Sesion2;integrated security=true;";
        public static SqlConnection GetConnection() => new(SeccondConnectionString);

    }
}
