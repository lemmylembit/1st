using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSprojekt.Infrastructure.POCOS;
using VSprojekt.Infrastructure.Repositories;

namespace VSprojekt.Models
{
    public class IndexViewModel
    {
        public List<User> Users { get; set; }
        public List<string> Countries { get; set; }

        private IndexViewModel() { }  //Disablar default konstruktorn 

        public static IndexViewModel Load(NpgsqlConnection connection) //Metoden för att skapa en Model instans
        {
            IndexViewModel model = new IndexViewModel();  //Vi kan skapa en instans av Modellen innefrån

            //Logik för att populera modellen
            UserRepository repo = new UserRepository(connection);
            model.Users = repo.Users().ToList();
            model.Countries = new List<string>() { "Sverige", "Norge", "Finland" };   //Mockdata / demodata, skall bytas ut mot databasanropp 

            return model;
        }

    }
}
