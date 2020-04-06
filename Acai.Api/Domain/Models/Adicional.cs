using System.Collections.Generic;

namespace Acai.Api.Domain.Models
{
    public class Adicional
    {
        public int Id {get; set;}
        public int TempoMinutos {get; set;}
        public decimal Valor {get; set;}
        public string Descricao {get; set;}
        public IEnumerable<PedidoAdicional> pedidoAdicionals { get; set; }

    }
}