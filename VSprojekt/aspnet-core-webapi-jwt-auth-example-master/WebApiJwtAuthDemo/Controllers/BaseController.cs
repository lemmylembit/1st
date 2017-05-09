using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazingPortal.Infrastructure.Options;

namespace AmazingPortal.Controllers
{
    public abstract class BaseController : Controller
    {
        #region Dependency injected options
        protected DatabaseOption DatabaseOption { get; set; }
        #endregion

        private NpgsqlConnection _connection;


        public BaseController(IOptions<DatabaseOption> databaseOption)
        {
            DatabaseOption = databaseOption.Value;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Return database connection to the connection pool
            if (_connection != null)
            {
                _connection.Dispose();
            }

            base.OnActionExecuted(context);
        }

        protected NpgsqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    NpgsqlConnection connection = new NpgsqlConnection(DatabaseOption.ConnectionString);
                    connection.Open();
                    _connection = connection;
                }
                return _connection;
            }
        }
    }
}
