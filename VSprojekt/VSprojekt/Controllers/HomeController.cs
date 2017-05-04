using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using VSprojekt.Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using VSprojekt.Infrastructure.Options;
using Microsoft.AspNetCore.Mvc.Filters;
using VSprojekt.Models;

namespace VSprojekt.Controllers
{
    public class HomeController : BaseController
    {
        public DatabaseOption DatabaseOption { get; set; }
        private NpgsqlConnection _connection;
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

        //To not create too many connections.. resource handling
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Return database connection to the connection pool
            if (_connection != null)
            {
                _connection.Dispose();
            }

            base.OnActionExecuted(context);
        }

        public HomeController(IOptions<DatabaseOption> databaseOption) : base(databaseOption)
        {
            DatabaseOption = databaseOption.Value;
        }

        public IActionResult Index()
        {
            return View(IndexViewModel.Load(this.Connection));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}