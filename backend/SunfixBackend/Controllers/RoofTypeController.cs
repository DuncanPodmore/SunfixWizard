using Domain.Models;
using SunfixBackend.Repositories;

namespace  SunfixBackend.Controllers
{
    public class RoofTypeController: BaseController<Part>
    {
        public RoofTypeController(IRepository<Part> repository) : base(repository) { }
    }
}
