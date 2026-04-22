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
            
            string query = "SELECT Username FROM Users WHERE ID = '" + id + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                
                var result = command.ExecuteScalar();
                return result?.ToString() ?? "No encontrado";
            }
        }
    }
}
