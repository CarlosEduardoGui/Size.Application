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

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [Route("/criarConta")]
        [HttpPost]
        public IActionResult CriarConta(Cliente pCliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lCliente = new ClienteBLL(_clienteRepository, pCliente);
                    lCliente.Executar();
                    return Ok();
                }
                else
                {
                    return Problem("Modelo não é válida.");
                }

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
    }
}
