using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session2.DAL;
using Session2.Models;
using System.Data;
using System.Data.SqlClient;

namespace Session2.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly static SqlConnection _conn = Connection.GetConnection();


        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] UserLogin userLog)
        {
            string q = $"EXECUTE usp_Login '{userLog.Username}','{userLog.Password}'";
            DataTable dt = new DataTable();
            try
            {
                new SqlDataAdapter(q, _conn).Fill(dt);

                if (dt.Rows.Count < 1) return Unauthorized(new Response("Usuario o contraseña incorrectos", null));

                User user = new()
                {
                    ID = int.Parse(dt.Rows[0]["ID"].ToString() ?? "0"),
                    FamilyCount = int.Parse(dt.Rows[0]["FamilyCount"].ToString() ?? "0"),
                    Username = dt.Rows[0]["Username"].ToString() ?? "",
                    Fullname = dt.Rows[0]["FullName"].ToString() ?? "Unknown",
                    Gender = (bool)dt.Rows[0]["Gender"],
                    Password = dt.Rows[0]["Password"].ToString() ?? "Unknown",
                    Birthdate = dt.Rows[0]["Birthdate"].ToString() ?? "Unknown"
                };

                return Ok(new Response("Bienvenido", user));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response("Hubo un error en el servidor", ex.Message));
            }


        }




    }
}
