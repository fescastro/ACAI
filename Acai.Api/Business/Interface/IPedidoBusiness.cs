using Acai.Api.Domain.Models;
using Acai.Api.Models.Input;
using Acai.Api.Models.Output;

namespace Acai.Api.Business.Interface
{
    public interface IPedidoBusiness
    {
        Pedido AddPedido(InputPedido pedido);

        Pedido AlterPedido(InputPedido pedido);
        OutputPedido ResumoPedido(Pedido pedido);
    }
}