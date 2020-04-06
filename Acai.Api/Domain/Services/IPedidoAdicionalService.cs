using System.Collections.Generic;
using Acai.Api.Domain.Models;

namespace Acai.Api.Domain.Services
{
    public interface IPedidoAdicionalService
    {
        IEnumerable<PedidoAdicional> GetAllPedidoAdicional();
    }
}