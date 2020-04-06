using System.Collections.Generic;
using Acai.Api.Domain.Models;

namespace Acai.Api.Models.Input
{
    public class InputPedido
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public Tamanho Tamanho { get; set; }
        public Sabor Sabor { get; set; }
        public IEnumerable<Adicional> Adicionais { get; set; }
    }
}