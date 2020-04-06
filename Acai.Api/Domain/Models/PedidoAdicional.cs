namespace Acai.Api.Domain.Models
{
    public class PedidoAdicional
    {
        public int PedidoId {get; set;}
        public int AdicionalId {get; set;}
        public Pedido Pedido {get; set;}
        public Adicional Adicional  {get; set;}
    }
}