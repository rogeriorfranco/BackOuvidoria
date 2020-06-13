using Microsoft.EntityFrameworkCore;
using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public class OuvidoriaDbContext : DbContext
    {
        public OuvidoriaDbContext()
        {
        }

        public OuvidoriaDbContext(DbContextOptions<OuvidoriaDbContext> options) : base(options)
        {
        }

        public DbSet<DadosCliente> Clientes { get; set; }
        public DbSet<PontosContrato> PontosContratos { get; set; }
        public DbSet<ProdutoPonto> ProdutoPontos { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<ResolucaoOcorrencia> ResolucaoOcorrencias { get; set; }
        public DbSet<HistoricoAtendimento> HistoricoAtendimentos { get; set; }
        public DbSet<HistoricoDadosAbertura> HistoricoDadosAberturas { get; set; }
        public DbSet<HistoricoContato> HistoricoContatos { get; set; }
        public DbSet<HistoricoDadosResolucao> HistoricoDadosResolucaos { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<ItemFatura> ItemFaturas { get; set; }
        public DbSet<StatusCliente> StatusClientes { get; set; }
        public DbSet<GrupoEncerramentoCaso> GrupoEncerramentoCasos { get; set; }
        public DbSet<CausaEncerramentoCaso> CausaEncerramentoCasos { get; set; }
        public DbSet<QuandoUsarEncerramentoCaso> QuandoUsarEncerramentoCasos { get; set; }
        public DbSet<TipoOfensor> TipoOfensors { get; set; }
        public DbSet<ResultadoContato> ResultadoContatos { get; set; }
        public DbSet<SolucaoEncerramentoCaso> SolucaoEncerramentoCasos { get; set; }
        public DbSet<PendenteFilaEncaminhamento> PendenteFilaEncaminhamentos { get; set; }
        public DbSet<ParametrosSistema> ParametrosSistemas { get; set; }
    }
}
