using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using VSprojekt.Infrastructure.POCOS;

namespace VSprojekt.Infrastructure.Repositories
{
    public class UserRepository
    {
        private NpgsqlConnection Connection { get; set; }

        public UserRepository(NpgsqlConnection connection)
        {
            Connection = connection;
        }

        public IEnumerable<User> Users()
        {
            return Connection.Query<User>("select * from \"AmazingPortalenDB\".public.\"users\"");
        }

        public User User(string email)
        {
            string query = "select * from \"AmazingPortalenDB\".public.\"users\" where \"email\"= @email";

            return Connection.Query<User>(query, new { email = email }).First();
        }

        public bool IsValidLogin(string email, string password)
        {
            string query = "select * from \"AmazingPortalenDB\".public.\"users\" where \"email\" = @email and \"password\" = @password";
            int count= Connection.Query<User>(query, new { email = email, password = password }).Count();

            return count == 1;
        }
    }
}
