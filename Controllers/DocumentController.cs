using Microsoft.AspNetCore.Mvc;
using TramitesAPI.Data;
using TramitesAPI.Models;

namespace TramitesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : Controller
    {
        private readonly TramitesContext contexto;

        public DocumentController(TramitesContext context)
        {
            contexto = context;
        }

        [HttpGet]
        [Route("GetDocs")]
        public IEnumerable<Document> Get()
        {
            return contexto.Documents.OrderBy(d => d.Id);

        }
    }
}
