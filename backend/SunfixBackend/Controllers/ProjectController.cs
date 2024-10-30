using Domain.Models;
using SunfixBackend.Repositories;

namespace  SunfixBackend.Controllers
{
    public class ProjectController : BaseController<Project>
    {
        public ProjectController(IRepository<Project> repository) : base(repository) { }
    }
}
