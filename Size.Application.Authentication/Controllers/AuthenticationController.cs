using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Size.Application.Authentication.Models;
using Size.Data.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Size.Application.Authentication.Controllers
{

    [Route("api/[controller]/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public AuthenticationController(SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("signIn")]
        public async Task<IActionResult> Login([FromBody] LoginModel Model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Model.Login, Model.Password, true, true);
                if (result.Succeeded)
                {
                    var Direitos = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, Model.Login),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var Chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("fedaf7d8863b48e197b9287d492b708e"));

                    var Credencias = new SigningCredentials(Chave, SecurityAlgorithms.HmacSha256);

                    var JwtToken = new JwtSecurityToken(
                        issuer: "Alura.WebApp",
                        audience: "Postman",
                        claims: Direitos,
                        signingCredentials: Credencias,
                        expires: DateTime.Now.AddMinutes(30)
                    );

                    return Ok(new JwtSecurityTokenHandler().WriteToken(JwtToken));
                }
                else
                    return Unauthorized();
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("signUp")]
        public async Task<IActionResult> Register([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario { UserName = model.Login };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    return StatusCode(201);
            }

            return BadRequest();
        }
    }
}
