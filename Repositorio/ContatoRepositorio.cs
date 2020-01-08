using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;
namespace InternetBanking.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly ClienteDB _contexto;
        public ContatoRepositorio(ClienteDB ctx)
        {
            _contexto = ctx;
        }
        public void AddContato(Contato contato)
        {
            _contexto.Contato.Add(contato);
            _contexto.SaveChanges();
        }
        public Contato FindByContato(int contato)
        {
            return _contexto.Contato.FirstOrDefault(u => u.idCliente == contato);
        }
        public IEnumerable<Contato> GetAll()
        {
            return _contexto.Contato.ToList();
        }
        
        public int FindByIdCliente(string cpf)
        {
            Cliente cli = _contexto.Cliente.FirstOrDefault(cli => cli.cpf == cpf);
            return cli.idCliente;
        }

        public void Update(Contato contato)
        {
            _contexto.Contato.Update(contato);
            _contexto.SaveChanges();
        }

        public void Update(Contato contato, Contato _contato)
        {

        
        if(contato.telCel!= ""){_contato.telCel = contato.telCel;}
        if(contato.email!= ""){_contato.email = contato.email;}
        if(contato.telResid!= ""){_contato.telResid = contato.telResid;}

            _contexto.Contato.Update(_contato);
            _contexto.SaveChanges();
        }
    }
}