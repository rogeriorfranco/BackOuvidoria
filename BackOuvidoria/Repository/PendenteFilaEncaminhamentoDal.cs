using Ouvidoria.Models;

namespace Ouvidoria.Repository
{
    public class PendenteFilaEncaminhamentoDal : GenericCrud<PendenteFilaEncaminhamento>, IPendenteFilaEncaminhamentoDal
    {
        public PendenteFilaEncaminhamentoDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
