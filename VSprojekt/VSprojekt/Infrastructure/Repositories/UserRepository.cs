using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return Connection.Query<User>("select *, \"e-mail\" as email from \"JesseLabb\".privat.\"User\"");
        }
    }
}
