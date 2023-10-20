using Session2.DAL;
using System.Data;
using System.Data.SqlClient;

namespace Session2.Models
{
    public class User : UserLogin
    {
        private readonly SqlConnection _conn = Connection.GetConnection();


        private int _id;

        private string userType;

        public string UserType { get => userType; }

        public int ID { get => _id; set => SetUnknownItems(value); }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public bool Gender { get; set; }
        public string Birthdate { get; set; }
        public int FamilyCount { get; set; }


        private void SetUnknownItems(int ID)
        {
            _id = ID;
            string q = "EXECUTE usp_GetUserTypeName " + ID;
            DataTable dt = new();
            try
            {
                new SqlDataAdapter(q, _conn).Fill(dt);
                userType = dt.Rows[0]["Name"].ToString() ?? "Unknown";
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }



    }
}
