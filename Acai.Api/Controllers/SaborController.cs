using Acai.Api.Domain.Services;
using Acai.Api.Models.Input;
using Microsoft.AspNetCore.Mvc;

namespace Acai.Api.Controllers
{
    [Route("/api/[controller]")]
    public class SaborController: Controller
    {
        private readonly ISaborService _saborService;

        public SaborController(ISaborService saborService){
            _saborService = saborService;
        }

        [HttpPost("AddSabor")]
        public IActionResult AddSabor([FromBody]InputSabor sabor){   

            if (sabor == null)
                return BadRequest();

            var resultado = _saborService.AddSabor(sabor);
            return Ok(resultado);
        }

        [HttpGet("GetAllSabores")]
        public IActionResult GetAllSabores(){
            return Ok(_saborService.GetAllSabores());
        }

        [HttpDelete("DeleteSabor")]
        public IActionResult DeleteSabor(int id){

            if(!_saborService.SaborExists(id))
                return NotFound();

            _saborService.DeleteSabor(id);
            return NoContent();
        }

        [HttpGet("GetByIdSabor")]
        public  IActionResult GetByIdSabor(int id){
            var resultado = _saborService.GetByIdSabor(id);

            if (resultado == null)
                return NotFound();

            return  Ok(resultado);
        }

        [HttpPut("UpdateSabor")]
        public  IActionResult UpdateSabor([FromBody]InputSabor sabor){

             if (sabor == null)
                return BadRequest();
            
             if(!_saborService.SaborExists(sabor.Id))
                return NotFound();


             _saborService.UpdateSabor(sabor);

            return NoContent();
        }
    }
}