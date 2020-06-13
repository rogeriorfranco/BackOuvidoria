using Ouvidoria.Models;

namespace Ouvidoria.Repository
{
    public class QuandoUsarEncerramentoCasoDal : GenericCrud<QuandoUsarEncerramentoCaso>, IQuandoUsarEncerramentoCasoDal
    {
        public QuandoUsarEncerramentoCasoDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
