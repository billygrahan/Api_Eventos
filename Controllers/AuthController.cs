using Api_Eventos.Context;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api_Eventos.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/login")]
        public IActionResult Login(string username, string password)
        {
            if (IsValidUser(username, password))
            {
                var claimsPrincipal = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new[] { new Claim(ClaimTypes.Name, username) },
                    BearerTokenDefaults.AuthenticationScheme
                    )
                );
                return SignIn(claimsPrincipal);
            }
            return Unauthorized("Credenciais inválidas");
        }

        private bool IsValidUser(string email, string password)
        {
            var administrador = _context.Administradores.FirstOrDefault(a => a.EMail == email);
            if (administrador == null) return false;
            return email == administrador.EMail && password == administrador.Senha;
        }

        /*[HttpGet("/teste")]
        public string teste(string username)
        {
            var administrador = _context.Administradores.FirstOrDefault(a => a.Nome == username);
            if (administrador == null) return "adm não encontrado!";
            return administrador.EMail;
        }*/
    }
}
