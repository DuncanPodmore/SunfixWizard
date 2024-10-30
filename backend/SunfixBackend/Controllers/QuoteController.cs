using Domain.Models;
using SunfixBackend.Repositories;

namespace  SunfixBackend.Controllers
{
    public class QuoteController : BaseController<Quote>
    {
        public QuoteController(IRepository<Quote> repository) : base(repository) { }
    }
}
