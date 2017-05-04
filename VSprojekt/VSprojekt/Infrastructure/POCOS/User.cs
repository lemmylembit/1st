using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSprojekt.Infrastructure.POCOS
{
    public class User
    {
        public int ID { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }
}
