using Ouvidoria.Models;

namespace Ouvidoria.Repository
{
    public class ResultadoContatoDal : GenericCrud<ResultadoContato>, IResultadoContatoDal
    {
        public ResultadoContatoDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
