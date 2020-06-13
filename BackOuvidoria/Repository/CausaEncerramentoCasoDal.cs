using Ouvidoria.Models;

namespace Ouvidoria.Repository
{
    public class CausaEncerramentoCasoDal : GenericCrud<CausaEncerramentoCaso>, ICausaEncerramentoCasoDal
    {
        public CausaEncerramentoCasoDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
