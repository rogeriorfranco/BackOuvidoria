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
    public class ClienteController : Controller
    {
        private readonly IClienteDal _clienteDal;

        public ClienteController(IClienteDal clienteRepository)
        {
            _clienteDal = clienteRepository;
        }


        // GET cliente/dadosCliente/123
        [HttpGet("dadosCliente/{protocolo}")]
        public async Task<IActionResult> Get(string protocolo)
        {
            return Ok(await _clienteDal.listaCliente(protocolo));
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
