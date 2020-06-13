using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public class ItemFaturaDal : GenericCrud<ItemFatura>, IItemFaturaDal
    {
        public ItemFaturaDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
