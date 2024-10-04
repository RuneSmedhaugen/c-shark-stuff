using System.Data.SqlClient;
using Crowdfunding_app.Models;

namespace Crowdfunding_app.Services
{
    public class UserService
    {
        private readonly SqlConnection _connection;

        public UserService(SqlConnection connection)
        {
            _connection = connection;
        }
    }
}
