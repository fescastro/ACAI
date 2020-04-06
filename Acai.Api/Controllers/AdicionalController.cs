using Acai.Api.Domain.Services;
using Acai.Api.Models.Input;
using Microsoft.AspNetCore.Mvc;

namespace Acai.Api.Controllers
{
    [Route("/api/[controller]")]
    public class AdicionalController: Controller
    {
        private readonly IAdicionalService _adicionalService;

        public AdicionalController(IAdicionalService adicionalService){
            _adicionalService = adicionalService;
        }

        [HttpPost("AddAdicional")]
        public IActionResult AddAdicional([FromBody]InputAdicional adicional){   

            if (adicional == null)
                return BadRequest();

            var resultado = _adicionalService.AddAdicional(adicional);
            return Ok(resultado);
        }

        [HttpGet("GetAllAdicionais")]
        public IActionResult GetAllAdicionais(){
            return Ok(_adicionalService.GetAllAdicionais());
        }

        [HttpDelete("DeleteAdicional")]
        public IActionResult DeleteAdicional(int id){

            if(!_adicionalService.AdicionalExists(id))
                return NotFound();

            _adicionalService.DeleteAdicional(id);
            return NoContent();
        }

        [HttpGet("GetByIdAdicional")]
        public  IActionResult GetByIdAdicional(int id){
            var resultado = _adicionalService.GetByIdAdicional(id);

            if (resultado == null)
                return NotFound();

            return  Ok(resultado);
        }

        [HttpPut("UpdateAdicional")]
        public  IActionResult UpdateAdicional([FromBody]InputAdicional adicional){

             if (adicional == null)
                return BadRequest();
            
             if(!_adicionalService.AdicionalExists(adicional.Id))
                return NotFound();


             _adicionalService.UpdateAdicional(adicional);

            return NoContent();
        }
    }
}