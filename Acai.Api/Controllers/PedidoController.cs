
using Microsoft.AspNetCore.Mvc;
using Acai.Api.Domain.Services;
using Acai.Api.Models.Input;
using Acai.Api.Business.Interface;

namespace Acai.Api.Controllers
{
    [Route("/api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;
        private readonly ITamanhoService _tamanhoService;
        private readonly ISaborService _saborService;
        private readonly IPedidoBusiness _pedidoBusiness;

        public PedidoController(IPedidoService pedidoService, ITamanhoService tamanhoService, ISaborService saborService, IPedidoBusiness pedidoBusiness){
            _pedidoService = pedidoService;
            _tamanhoService = tamanhoService;
            _saborService = saborService;
            _pedidoBusiness = pedidoBusiness;
        }

        //Registra o pedido do cliente
        [HttpPost("AddPedido")]
        public IActionResult AddPedido([FromBody]InputPedido pedido){   

            if (pedido == null || pedido.Sabor == null || pedido.Tamanho == null)
                return BadRequest();
            
             if(!_tamanhoService.TamanhoExists(pedido.Tamanho.Id) || !_saborService.SaborExists(pedido.Sabor.Id))
                return NotFound();

            var resultadoPedido = _pedidoService.AddPedido(pedido);

            if(resultadoPedido == null)
                return Ok("Erro o gravar registro, Verique os parâmetros");

            var resultado = _pedidoBusiness.ResumoPedido(resultadoPedido);            
            return Ok(resultado);
        }

        [HttpGet("GetAllPedidos")]
        public IActionResult GetAllPedidos(){
            return Ok(_pedidoService.GetAllPedidos());
        }

        //Cancela o pedido caso o cliente necessite
        [HttpDelete("CancelPedido")]
        public IActionResult CancelPedido(int id){

            if(!_pedidoService.PedidoExists(id))
                return NotFound();

            _pedidoService.CancelPedido(id);
            return NoContent();
        }

        [HttpGet("GetByIdPedido")]
        public  IActionResult GetByIdPedido(int id){
            var resultado = _pedidoService.GetByIdPedido(id);

            if (resultado == null)
                return NotFound();

            return  Ok(resultado);
        }

        //Altera informações do pedido caso cliente necessite 
        [HttpPut("AlterPedido")]
        public  IActionResult AlterPedido([FromBody]InputPedido pedido){

             if (pedido == null || pedido.Sabor == null || pedido.Tamanho == null)
                return BadRequest();
            
             if(!_pedidoService.PedidoExists(pedido.Id) || !_tamanhoService.TamanhoExists(pedido.Tamanho.Id) || !_saborService.SaborExists(pedido.Sabor.Id))
                return NotFound();


            var resultadoPedido = _pedidoService.AlterPedido(pedido);

            if(resultadoPedido == null)
                return Ok("Erro o gravar registro, Verique os parâmetros");

            var resultado = _pedidoBusiness.ResumoPedido(resultadoPedido);            
            return Ok(resultado);
        }

        
    }
}