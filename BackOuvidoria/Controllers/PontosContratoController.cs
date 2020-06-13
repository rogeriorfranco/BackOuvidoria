using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ouvidoria.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Ouvidoria.Controllers
{
           [Route("api/[controller]")]
    [ApiController]
    public class PontosContratoController : Controller
    {
        private readonly IPontosContratoDal _pontosContratoDal;

        public PontosContratoController(IPontosContratoDal pontosContratoDal)
        {
            _pontosContratoDal = pontosContratoDal;
        }

        // GET cliente/idCliente
        [HttpGet("produtosCliente/{idCliente}")]
        public async Task<IActionResult> Get(int idCliente)
        {
            return Ok(await _pontosContratoDal.Read().Where(x=> x.IdCliente == idCliente).ToListAsync());
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
