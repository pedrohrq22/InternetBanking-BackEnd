using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;
namespace InternetBanking.Repositorio
{
    public class ClienteLoginRepositorio : IClienteLoginRepositorio
    {
        private readonly ClienteDB _contexto;
        public ClienteLoginRepositorio(ClienteDB ctx)
        {
            _contexto = ctx;
        }

        public void AddClienteLogin(ClienteLogin clienteLogin)
        {
            _contexto.ClienteLogin.Add(clienteLogin);
            _contexto.SaveChanges();
        }

        public ClienteLogin FindByCpf(string cpf)
        {
            return _contexto.ClienteLogin.FirstOrDefault(c => c.cpf == cpf);
        }
        
        public IEnumerable<ClienteLogin> GetAll()
        {
            return _contexto.ClienteLogin.ToList();
        }
        
        public int FindByIdCliente(string cpf)
        {
            Cliente cli = _contexto.Cliente.FirstOrDefault(cli => cli.cpf == cpf);
            return cli.idCliente;
        }

        public void Update(ClienteLogin clienteLogin)
        {
            _contexto.ClienteLogin.Update(clienteLogin);
            _contexto.SaveChanges();
        }
    }
}