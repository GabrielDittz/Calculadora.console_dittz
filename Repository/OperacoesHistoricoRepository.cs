using Calculadora.Data;
using Domain.Models;

namespace Repository
{
    public class OperacoesHistoricoRepository : IOperacoesHistoricoRepository
    {
        private readonly AppDbContext _context;

        public OperacoesHistoricoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(OperacoesHistorico operacoesHistorico)
        {
            _context.Add(operacoesHistorico);
            _context.SaveChanges();
        }
    }
}
