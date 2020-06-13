using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolucaoEncerramentoCasoController : Controller
    {
        private readonly ISolucaoEncerramentoCasoDal _SolucaoEncerramentoCaso;

        public SolucaoEncerramentoCasoController(ISolucaoEncerramentoCasoDal SolucaoEncerramentoCaso)
        {
            _SolucaoEncerramentoCaso = SolucaoEncerramentoCaso;

        }

        // GET solucaoEncerramentoCaso/listaCausa
        [HttpGet("listaSolucao/{idCausaEncerramentoCaso}")]
        public async Task<IActionResult> Get(int idCausaEncerramentoCaso)
        {
            return Ok(await _SolucaoEncerramentoCaso.Read().Where(x => x.Status == true && x.IdCausaEncerramentoCaso == idCausaEncerramentoCaso).ToListAsync());
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
