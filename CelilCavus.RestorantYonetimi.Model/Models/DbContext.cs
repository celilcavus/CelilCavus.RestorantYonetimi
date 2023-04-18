using System.Data.SqlClient;
using System.Text.Json;
namespace CelilCavus.RestorantYonetimi.Model.Models
{
    public class DbContext
    {
        const string ConnectionString = "Server=.;Database=RestoranYonetimi;Trusted_Connection=True;TrustServerCertificate=True;";
      
        private static SqlConnection connection = new SqlConnection(ConnectionString);
        public static SqlConnection Context { get; set; } = connection;
    }
}
