using System.Collections.Generic;
using Acai.Api.Domain.Models;
using Acai.Api.Models.Input;

namespace Acai.Api.Domain.Repositories
{
    public interface IPedidoRepository
    {
         Pedido AddPedido (InputPedido pedido, decimal total);
         IEnumerable<Pedido> GetAllPedidos();
         Pedido GetByIdPedido(int id);
         void CancelPedido(int id);
         bool PedidoExists(int id);
         Pedido AlterPedido(InputPedido pedido, decimal total);

    }
}