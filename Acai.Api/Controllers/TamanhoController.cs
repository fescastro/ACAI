using Acai.Api.Domain.Services;
using Acai.Api.Models.Input;
using Microsoft.AspNetCore.Mvc;

namespace Acai.Api.Controllers
{
    [Route("/api/[controller]")]
    public class TamanhoController: Controller
    {
        private readonly ITamanhoService _tamanhoService;

        public TamanhoController(ITamanhoService tamanhoService){
            _tamanhoService = tamanhoService;
        }

        [HttpPost("AddTamanho")]
        public IActionResult AddTamanho([FromBody]InputTamanho tamanho){   

            if (tamanho == null)
                return BadRequest();

            var resultado = _tamanhoService.AddTamanho(tamanho);
            return Ok(resultado);
        }

        [HttpGet("GetAllTamanhos")]
        public IActionResult GetAllTamanhos(){
            return Ok(_tamanhoService.GetAllTamanhos());
        }

        [HttpDelete("DeleteTamanho")]
        public IActionResult DeleteTamanho(int id){

            if(!_tamanhoService.TamanhoExists(id))
                return NotFound();

            _tamanhoService.DeleteTamanho(id);
            return NoContent();
        }

        [HttpGet("GetByIdTamanho")]
        public  IActionResult GetByIdTamanho(int id){
            var resultado = _tamanhoService.GetByIdTamanho(id);

            if (resultado == null)
                return NotFound();

            return  Ok(resultado);
        }

        [HttpPut("UpdateTamanho")]
        public  IActionResult UpdateTamanho([FromBody]InputTamanho tamanho){

             if (tamanho == null)
                return BadRequest();
            
             if(!_tamanhoService.TamanhoExists(tamanho.Id))
                return NotFound();


             _tamanhoService.UpdateTamanho(tamanho);

            return NoContent();
        }
    }
}