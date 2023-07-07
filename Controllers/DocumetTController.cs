using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Route("GetDocT")]
        public IEnumerable<Documettipe> Get()
        {
            return contexto.Documettipes.OrderBy(d => d.Nombre);

        }


        // POST:
        [HttpPost]
        public async Task<ActionResult<Documettipe>> PostDocumento(Documettipe documento)
        {
            if (contexto.Documettipes == null)
            {
                return Problem("Entity set 'GestionDocumentosContext.Documentos'  is null.");
            }
            contexto.Documettipes.Add(documento);
            await contexto.SaveChangesAsync();

            return Ok();
        }

        // DELETE:
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumento(int id)
        {
            if (contexto.Documettipes == null)
            {
                return NotFound();
            }
            var documento = await contexto.Documettipes.FindAsync(id);
            if (documento == null)
            {
                return NotFound();
            }

            contexto.Documettipes.Remove(documento);
            await contexto.SaveChangesAsync();

            return NoContent();
        }
    }
}
