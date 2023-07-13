using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Calculadora.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<OperacoesHistorico> OperacoesHistorico { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=calculadora_frwk;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
