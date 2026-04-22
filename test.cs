using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("{id}")]
        public string GetUser(string id)
        {
            string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
            
            // FUENTE: 'id' viene directamente del usuario (URL)
            // VULNERABILIDAD: Inyección SQL por concatenación de strings
            string query = "SELECT Username FROM Users WHERE ID = '" + id + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                
                // SUMIDERO: Se ejecuta la consulta "contaminada"
                var result = command.ExecuteScalar();
                return result?.ToString() ?? "No encontrado";
            }
        }
    }
}
