using Microsoft.AspNetCore.Mvc;
using Size.Business;
using Size.Core.Entidade;
using System;
using System.Collections.Generic;

namespace Size.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        [HttpPost]
        [Route("/fazerDeposito")]
        public IActionResult FazerDesposito(Cliente Cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lDeposito = new DepositoBLL(Cliente.Conta, Cliente.Conta.Valor);
                    lDeposito.Executar();
                }
            }
            catch (Exception ex)
            {

            }

            return Ok(Cliente);
        }

        [HttpGet]
        [Route("/extratoBancario")]
        public IActionResult ExtratoBancario()
        {
            return Ok(new List<string>());
        }
    }
}
