using Ouvidoria.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public interface IClienteDal : IGenericCrud<DadosCliente>
    {
        Task<List<DadosCliente>> listaCliente(string protocolo);
    }
}
