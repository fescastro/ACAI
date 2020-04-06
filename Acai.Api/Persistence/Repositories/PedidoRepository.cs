using System.Collections.Generic;
using Acai.Api.Domain.Models;
using Acai.Api.Domain.Repositories;
using Acai.Api.Persistence.Contexts;
using Acai.Api.Models.Input;
using System.Linq;
using System;

namespace Acai.Api.Persistence.Repositories
{
    public class PedidoRepository : BaseRepository, IPedidoRepository
    {
        public PedidoRepository(AppDbContext context) : base(context){ }

        public Pedido AddPedido(InputPedido pedido, decimal total)
        {
            using(var transaction = _context.Database.BeginTransaction()){
                try{
                    Pedido entidadePedido = new Pedido();
                    entidadePedido.Cliente = pedido.Cliente;
                    entidadePedido.ValorTotalPedido = total;
                    entidadePedido.TamanhoId = pedido.Tamanho.Id;
                    entidadePedido.SaborId = pedido.Sabor.Id;            
                    var resultado =  _context.Pedidos.Add(entidadePedido);

                    foreach (var adicional in pedido.Adicionais)
                    {
                        var modelPedidoAdicional = new PedidoAdicional();
                        modelPedidoAdicional.AdicionalId = adicional.Id;
                        modelPedidoAdicional.PedidoId = resultado.Entity.Id;
                        _context.PedidosAdicionais.Add(modelPedidoAdicional);
                    }      

                    _context.SaveChanges();
                    transaction.Commit();
                    return resultado.Entity;
                }catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Error ao gravar pedido. Detalhe{ex.Message}");
                    return null;
                }
            }
            
        }

        public Pedido AlterPedido(InputPedido pedido, decimal total)
        {
            using(var transaction = _context.Database.BeginTransaction()){
                try{
                    var model = _context.Pedidos.Where(p => p.Id.Equals(pedido.Id)).FirstOrDefault();
                    model.Cliente = pedido.Cliente;
                    model.ValorTotalPedido = total;
                    model.TamanhoId = pedido.Tamanho.Id;
                    model.SaborId = pedido.Sabor.Id;

                     var adiconaisEscluir = _context.PedidosAdicionais.Where(p => p.PedidoId == model.Id);
                     _context.PedidosAdicionais.RemoveRange(adiconaisEscluir);

                    foreach (var adicional in pedido.Adicionais)
                    {
                        var modelPedidoAdicional = new PedidoAdicional();
                        modelPedidoAdicional.AdicionalId = adicional.Id;
                        modelPedidoAdicional.PedidoId = model.Id;
                        _context.PedidosAdicionais.Add(modelPedidoAdicional);
                    }      


                    _context.SaveChanges(); 
                    transaction.Commit();
                    return model;
                }catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Error ao alterar pedido. Detalhe{ex.Message}");
                    return null;
                }
            
            }  
        }

        public void CancelPedido(int id)
        {
            _context.Pedidos.Remove(GetByIdPedido(id));
            _context.SaveChanges();
        }

        public IEnumerable<Pedido> GetAllPedidos()
        {
             return _context.Pedidos.ToList();
        }

        public Pedido GetByIdPedido(int id)
        {
            return _context.Pedidos.Find(id);
        }

        public bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(p => p.Id == id);
        }
    }
}