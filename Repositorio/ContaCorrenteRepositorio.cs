using System.Collections.Generic;
using InternetBanking.Models;
using System.Linq;

namespace InternetBanking.Repositorio
{
    public class ContaCorrenteRepositorio : IContaCorrenteRepositorio
    {
        private readonly ContaCorrenteDB _contexto;

        public ContaCorrenteRepositorio(ContaCorrenteDB ctx)
        {
            _contexto = ctx;
        }

        public void AddContaCorrente(ContaCorrente contaCorrente)
        {
            _contexto.ContaCorrente.Add(contaCorrente);
            _contexto.SaveChanges();
        }

        public ContaCorrente FindByContaCorrente(int id)
        {
            return _contexto.ContaCorrente.FirstOrDefault(c => c.idContaCorrente == id);
        }

        public IEnumerable<ContaCorrente> GetAll()
        {
            return _contexto.ContaCorrente.ToList();
        }

        public void Update(ContaCorrente contaCorrente)
        {
            _contexto.ContaCorrente.Update(contaCorrente);
            _contexto.SaveChanges();
        }

        public void Deposito(int idContaCorrente, int numeroConta, decimal valor)
        {
            var contaCorrente = FindByContaCorrente(idContaCorrente);

            if(valor <= 0)
            {
                throw new System.Exception();
            }
            else
            {
                contaCorrente.saldo += valor;
                _contexto.SaveChanges();
            }
        }

        public void Saque(int idContaCorrente, int numeroConta, decimal valor)
        {
            var contaCorrente = FindByContaCorrente(idContaCorrente);
            
            if(contaCorrente.saldo < valor || valor <= 0)
            {
                throw new System.Exception(); 
            }
            else
            {
                contaCorrente.saldo -= valor;
                _contexto.SaveChanges();
            }
        }

        public void Transferencia(int idContaCorrenteOrigem, int idContaCorrenteDestino, int numeroContaOrigem, int numeroContaDestino, decimal valor)
        {
            var contaCorrenteOrigem = FindByContaCorrente(idContaCorrenteOrigem);
            var contaCorrenteDestino = FindByContaCorrente(idContaCorrenteDestino);
            
            if(contaCorrenteOrigem.saldo < valor || valor <= 0)
            {
                throw new System.Exception(); 
            }
            else
            {
                contaCorrenteOrigem.saldo -= valor;
                contaCorrenteDestino.saldo += valor;
                _contexto.SaveChanges();
            }
        }
    }
}