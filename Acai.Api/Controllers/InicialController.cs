using Acai.Api.Domain.Services;
using Acai.Api.Models.Input;
using Microsoft.AspNetCore.Mvc;

namespace Acai.Api.Controllers
{
    //Essa classe é reponsável por inserir no banco regstro inicias(tamnho, sabor e adicionais(personalizações)), 
    [Route("/api/[controller]")]
    public class InicialController: Controller
    {
        private readonly ITamanhoService _tamanhoService;
        private readonly ISaborService _saborService;
        private readonly IAdicionalService _adicionalService;
         public InicialController(ITamanhoService tamanhoService, ISaborService saborService, IAdicionalService adicionalService){
            _tamanhoService = tamanhoService;
            _saborService = saborService;
            _adicionalService = adicionalService;
        }

        [HttpPost("AddItensInicias")]
        public IActionResult AddItensInicias(){   
            
            _tamanhoService.AddTamanho(new InputTamanho { Id=0, Descricao="Pequeno", Ml="300", TempoMinutos=5, Valor= 10.00m }) ;
            _tamanhoService.AddTamanho(new InputTamanho { Id=0, Descricao="Médio", Ml="500", TempoMinutos=7, Valor= 13.00m }) ;
            _tamanhoService.AddTamanho(new InputTamanho { Id=0, Descricao="Grande", Ml="700", TempoMinutos=10, Valor= 15.00m }) ;

            _saborService.AddSabor(new InputSabor {Id=0, Descricao="Morango", TempoMinutos=0});
            _saborService.AddSabor(new InputSabor {Id=0, Descricao="Banana", TempoMinutos=0});
            _saborService.AddSabor(new InputSabor {Id=0, Descricao="Kiwi", TempoMinutos=5});

            _adicionalService.AddAdicional(new InputAdicional { Id=0, Descricao="Leite Ninho", TempoMinutos=0, Valor= 3.00m });
            _adicionalService.AddAdicional(new InputAdicional { Id=0, Descricao="Granola", TempoMinutos=0, Valor= 0.00m });
            _adicionalService.AddAdicional(new InputAdicional { Id=0, Descricao="Paçoca", TempoMinutos=3, Valor= 3.00m });
            
            return Ok();
        }
    }
}