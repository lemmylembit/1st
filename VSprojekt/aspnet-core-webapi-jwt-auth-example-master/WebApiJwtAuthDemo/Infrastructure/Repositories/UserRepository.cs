using Dapper;
using Npgsql;
using System.Collections.Generic;
using AmazingPortal.Infrastructure.POCOS;

namespace AmazingPortal.Infrastructure.Repositories
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
            return Connection.Query<User>("select *, \"email\" from \"AmazingPortalenDB\".public.\"users\"");
        }
    }
}
