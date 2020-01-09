using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InternetBanking.Repositorio;
using System;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class ClientesController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClientesController(IClienteRepositorio clienteRepo)
        {
            _clienteRepositorio = clienteRepo;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetAll()
        {
            return _clienteRepositorio.GetAll();
        }

        [HttpGet("{cpf}", Name = "GetClientes")]
        public IActionResult GetByCPF(string cpf)
        {
            var cliente = _clienteRepositorio.FindByCpf(cpf);

            if (cliente == null) return NotFound();
            return new ObjectResult(cliente);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest();

            var clientes = _clienteRepositorio.FindByCpf(cliente.cpf);

            if (clientes == null)
            {
                _clienteRepositorio.AddCliente(cliente);
                return new ObjectResult(new ClienteLogin());
            }
            return BadRequest();
        }

        [HttpPut("{cpf}")]
        public IActionResult Update([FromBody] Cliente cliente, string cpf)
        {
            if (cliente == null) return NotFound();

            var _cliente = _clienteRepositorio.FindByCpf(cpf);           

            _clienteRepositorio.Update(cliente,_cliente);

            return new NoContentResult();
        }
    }
}