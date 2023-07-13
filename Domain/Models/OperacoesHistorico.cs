using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OperacoesHistorico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public float Resultado { get; set; }
        public DateTime Data { get; set; }
    }
}
