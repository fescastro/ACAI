using System.Collections.Generic;
using Acai.Api.Domain.Models;
using Acai.Api.Models.Input;

namespace Acai.Api.Domain.Services
{
    public interface IPedidoService
    {
         Pedido AddPedido (InputPedido pedido);
         IEnumerable<Pedido> GetAllPedidos();
         Pedido GetByIdPedido(int id);
         void CancelPedido(int id);
         bool PedidoExists(int id);
         Pedido AlterPedido(InputPedido pedido);
    }
}