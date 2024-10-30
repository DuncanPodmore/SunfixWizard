using Domain.Models;
using SunfixBackend.Repositories;

namespace  SunfixBackend.Controllers
{
    public class RoofSheetController: BaseController<Part>
    {
        public RoofSheetController(IRepository<Part> repository) : base(repository) { }
    }
}
