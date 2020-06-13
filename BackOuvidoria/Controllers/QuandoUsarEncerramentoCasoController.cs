using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuandoUsarEncerramentoCasoController : Controller
    {
        private readonly IQuandoUsarEncerramentoCasoDal _QuandoUsarEncerramentoCaso;

        public QuandoUsarEncerramentoCasoController(IQuandoUsarEncerramentoCasoDal QuandoUsarEncerramentoCaso)
        {
            _QuandoUsarEncerramentoCaso = QuandoUsarEncerramentoCaso;

        }

        // GET quandoUsarEncerramentoCaso/listaQuandoUsar/1
        [HttpGet("listaQuandoUsar/{idCausaEncerramentoCaso}")]
        public async Task<IActionResult> Get(int idCausaEncerramentoCaso)
        {
            return Ok(await _QuandoUsarEncerramentoCaso.Read().Where(x => x.Status == true && x.idCausaEncerramentoCaso == idCausaEncerramentoCaso).ToListAsync());
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
