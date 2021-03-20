using Microsoft.AspNetCore.Mvc;
using Size.Business;
using Size.Core.Entidade;
using Size.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Size.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IContaRepository _contaRepository;

        public ClienteController(IClienteRepository clienteRepository, IContaRepository contaRepository)
        {
            _clienteRepository = clienteRepository;
            _contaRepository = contaRepository;
        }

        [Route("/criarConta")]
        [HttpPost]
        public IActionResult CriarConta(Cliente pCliente)
        {
            try
            {
                var lCliente = new ClienteBLL(_clienteRepository, pCliente);
                lCliente.Executar();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("/fazerDeposito/{NumeroConta}/{Valor}")]
        public IActionResult FazerDeposito(Conta pConta)
        {
            try
            {
                var lConta = new DepositoBLL(_contaRepository, pConta);

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
