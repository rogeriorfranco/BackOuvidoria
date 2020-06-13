using Ouvidoria.Models;

namespace Ouvidoria.Repository
{
    public class GrupoEncerramentoCasoDal : GenericCrud<GrupoEncerramentoCaso>, IGrupoEncerramentoCasoDal
    {
        public GrupoEncerramentoCasoDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
