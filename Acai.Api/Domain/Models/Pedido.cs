using System.Collections.Generic;

namespace Acai.Api.Domain.Models
{
     public class Pedido
    {    
        public int Id { get; set; }
        public string Cliente { get; set; }
        public Tamanho Tamanho { get; set; }
        public Sabor Sabor { get; set; }
        public int TamanhoId { get; set; }
        public int SaborId { get; set; }
        public decimal ValorTotalPedido {get; set;}
        public IEnumerable<PedidoAdicional> pedidoAdicionals { get; set; }
    }
}