using System.Collections.Generic;
using Acai.Api.Domain.Models;
using Acai.Api.Domain.Repositories;
using Acai.Api.Domain.Services;
using Acai.Api.Models.Input;

namespace Acai.Api.Services
{
    public class TamanhoService : ITamanhoService
    {
        private readonly ITamanhoRepository _tamanhoRepository;

         public TamanhoService(ITamanhoRepository tamanhoRepository){
            _tamanhoRepository = tamanhoRepository;
        }

        public Tamanho AddTamanho(InputTamanho tamanho)
        {
            return _tamanhoRepository.AddTamanho(tamanho);
        }

        public void DeleteTamanho(int id)
        {
           _tamanhoRepository.DeleteTamanho(id);
        }

        public IEnumerable<Tamanho> GetAllTamanhos()
        {
            return _tamanhoRepository.GetAllTamanhos();
        }

        public Tamanho GetByIdTamanho(int id)
        {
           return _tamanhoRepository.GetByIdTamanho(id);
        }

        public bool TamanhoExists(int id)
        {
            return _tamanhoRepository.TamanhoExists(id);
        }

        public void UpdateTamanho(InputTamanho tamanho)
        {
            _tamanhoRepository.UpdateTamanho(tamanho);
        }
    }
}