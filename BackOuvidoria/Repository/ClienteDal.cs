using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public class ClienteDal : GenericCrud<DadosCliente>, IClienteDal
    {
        public ClienteDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DadosCliente>> listaCliente(string protocolo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select tc.IdCliente, tc.nome,tc.CpfCnpj,tc.statusNet,tc.Rg,tc.Telefone,tc.Celular,tc.NetFone,tc.Segmento,tc.IdAssinante,tc.TipoContrato ");
            sb.Append(",tc.TipoCliente,tc.CodigoNet,tc.StatusEmbratel,tc.CodigoEmbratel,tm.Email,tm.Cidade,tm.Endereco,tm.Numero,tm.cep,tc.Protocolo ");
            sb.Append("from TbDadosCliente tc ");
            sb.Append("inner join TbManifEnderecoDadosCliente tm ");
            sb.Append("on tc.Protocolo = tm.Protocolo ");
            sb.Append(string.Format("where tc.Protocolo='{0}'", protocolo));

            return await Read().FromSql(sb.ToString()).ToListAsync();
        }
    }
}
