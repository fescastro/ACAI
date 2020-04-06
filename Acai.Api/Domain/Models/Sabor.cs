using System.Collections.Generic;

namespace Acai.Api.Domain.Models
{
    public class Sabor
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int TempoMinutos { get; set; }
        public IEnumerable<Pedido> Pedidos { get; set; }
    }
}