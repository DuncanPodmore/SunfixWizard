using Domain.Models;
using SunfixBackend.Repositories;

namespace  SunfixBackend.Controllers
{
    public class ClientController : BaseController<Client>
    {
        public ClientController(IRepository<Client> repository) : base(repository) { }
    }
}
