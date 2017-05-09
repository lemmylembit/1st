using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VSprojekt.Infrastructure.Options;
using VSprojekt.Infrastructure.Repositories;

namespace VSprojekt.Controllers.WebAPI
{
    [Route ("api/[controller]")]
    public class User : BaseController
    {
        public User(IOptions<DatabaseOption> databaseOption) : base(databaseOption)
        {
        }

        [Route("[action]")]
        public Infrastructure.POCOS.User GetUser(string email)
        {
            UserRepository repository = new UserRepository(this.Connection);

            return repository.User(email);
        }

        /*[Route("[action]")]
        public bool CheckLogin(string email, string password)
        {
            UserRepository repository = new UserRepository(this.Connection);

            return repository.IsValidLogin(email, password);
        }*/
    }
}
