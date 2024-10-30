using Domain.Models;
using SunfixBackend.Repositories;

namespace  SunfixBackend.Controllers
{
    public class PartController : BaseController<Part>
    {
        public PartController(IRepository<Part> repository) : base(repository) { }
    }
}
