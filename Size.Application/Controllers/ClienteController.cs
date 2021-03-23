using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Size.Business;
using Size.Core.Entidade;
using Size.Core.Interface;
using System;

namespace Size.Application.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]/")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IContaRepository _contaRepository;
        private readonly IHistoricoTransacaoRepository _historicoTransacaooRepository;

        public ClienteController(IClienteRepository clienteRepository,
            IContaRepository contaRepository,
            IHistoricoTransacaoRepository historicoTransacaoRepository)
        {
            _clienteRepository = clienteRepository;
            _contaRepository = contaRepository;
            _historicoTransacaooRepository = historicoTransacaoRepository;
        }


        [HttpPost]
        [Route("criarConta")]
        public IActionResult CriarConta(Cliente pCliente)
        {
            try
            {
                var lCliente = new ClienteBLL(_clienteRepository, _contaRepository, pCliente);
                lCliente.Executar();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("fazerDeposito/{NumeroConta}/{Valor}")]
        public IActionResult FazerDeposito(Conta pConta)
        {
            try
            {
                var lConta = new DepositoBLL(_contaRepository, _historicoTransacaooRepository, pConta);
                lConta.Executar();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
