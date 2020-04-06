using System.Collections.Generic;
using System.Linq;
using Acai.Api.Domain.Models;
using Acai.Api.Domain.Repositories;
using Acai.Api.Models.Input;
using Acai.Api.Persistence.Contexts;

namespace Acai.Api.Persistence.Repositories
{
    public class TamanhoRepository : BaseRepository, ITamanhoRepository
    {
        public TamanhoRepository(AppDbContext context) : base(context){ }
        public Tamanho AddTamanho(InputTamanho tamanho)
        {
            Tamanho entidadeTamanho = new Tamanho();
            entidadeTamanho.Descricao = tamanho.Descricao;
            entidadeTamanho.TempoMinutos = tamanho.TempoMinutos;
            entidadeTamanho.Ml = tamanho.Ml;
            entidadeTamanho.Valor = tamanho.Valor;
            var resultado =  _context.Tamanhos.Add(entidadeTamanho);
            _context.SaveChanges();
            return resultado.Entity;
        }

        public void DeleteTamanho(int id)
        {
             _context.Tamanhos.Remove(GetByIdTamanho(id));
            _context.SaveChanges();
        }

        public IEnumerable<Tamanho> GetAllTamanhos()
        {
             return _context.Tamanhos.ToList();
        }

        public Tamanho GetByIdTamanho(int id)
        {
            return _context.Tamanhos.Find(id);
        }

        public bool TamanhoExists(int id)
        {
            return _context.Tamanhos.Any(p => p.Id == id);
        }

        public void UpdateTamanho(InputTamanho tamanho)
        {
           var model = _context.Tamanhos.Where(p => p.Id.Equals(tamanho.Id)).FirstOrDefault();;

            model.Descricao = tamanho.Descricao;
            model.TempoMinutos = tamanho.TempoMinutos;  
            model.Ml = tamanho.Ml;
            model.Valor = tamanho.Valor;
            _context.SaveChanges(); 
        }
    }
}