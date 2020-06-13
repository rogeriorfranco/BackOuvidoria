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
    public class ProdutoPontoController : Controller
    {
        private readonly IProdutoPontoDal _ProdutoPontoDal;

        public ProdutoPontoController(IProdutoPontoDal ProdutoPontoDal)
        {
            _ProdutoPontoDal = ProdutoPontoDal;

        }

        // GET cliente/IdCliente
        [HttpGet("produtosDetalhe/{IdCliente}")]
        public async Task<IActionResult> Get(int IdCliente)
        {
            return Ok(await _ProdutoPontoDal.Read().Where(x => x.IdCliente == IdCliente).ToListAsync());
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
