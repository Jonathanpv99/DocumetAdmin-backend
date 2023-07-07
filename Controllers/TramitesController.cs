using Microsoft.AspNetCore.Mvc;
using TramitesAPI.Data;
using TramitesAPI.Models;

namespace TramitesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TramitesController : Controller
    {
        private readonly TramitesContext contexto;

        public TramitesController(TramitesContext context)
        {
            contexto = context;
        }

        [HttpGet]
        public IEnumerable<Tramite> Get()
        {
            return contexto.Tramites.OrderBy(d => d.Nombre);

        }
    }
}
