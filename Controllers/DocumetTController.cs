using Microsoft.AspNetCore.Mvc;
using TramitesAPI.Data;
using TramitesAPI.Models;

namespace TramitesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumetTController : Controller
    {
        private readonly TramitesContext contexto;

        public DocumetTController(TramitesContext context)
        {
            contexto = context;
        }

        [HttpGet]
        public IEnumerable<Documettipe> Get()
        {
            return contexto.Documettipes.OrderBy(d => d.Nombre);

        }
    }
}
