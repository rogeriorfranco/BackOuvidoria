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
    public class StatusClienteController : Controller
    {
        private readonly IStatusClienteDal _clienteDal;

        public StatusClienteController(IStatusClienteDal clienteRepository)
        {
            _clienteDal = clienteRepository;
        }


        // GET statusCliente/dadosCliente/123
        [HttpGet("status/{idCliente}")]
        public async Task<IActionResult> Get(int idCliente)
        {
            return Ok(await _clienteDal.Read().Where(x => x.IdCliente == idCliente).ToListAsync());
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
