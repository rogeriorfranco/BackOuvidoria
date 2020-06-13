using Ouvidoria.Models;

namespace Ouvidoria.Repository
{
    public class TipoOfensorDal : GenericCrud<TipoOfensor>, ITipoOfensorDal
    {
        public TipoOfensorDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
