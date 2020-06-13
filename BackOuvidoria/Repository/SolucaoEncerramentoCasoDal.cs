using Ouvidoria.Models;

namespace Ouvidoria.Repository
{
    public class SolucaoEncerramentoCasoDal : GenericCrud<SolucaoEncerramentoCaso>, ISolucaoEncerramentoCasoDal
    {
        public SolucaoEncerramentoCasoDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
