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

        [HttpGet("/login/adm")]
        public IActionResult LoginAdm(string email, string password)
        {
            if (IsValidUserAdm(email, password))
            {
                var claimsPrincipal = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new[] { 
                        new Claim(ClaimTypes.Email, email) ,
                        new Claim("Role", "Administrador") // Adicionando a claim de Role
                    },
                    BearerTokenDefaults.AuthenticationScheme
                    )
                );
                return SignIn(claimsPrincipal);
            }
            return Unauthorized("Credenciais inválidas");
        }

        private bool IsValidUserAdm(string email, string password)
        {
            var administrador = _context.Administradores.FirstOrDefault(a => a.EMail == email);
            if (administrador == null) return false;
            return email == administrador.EMail && password == administrador.Senha;
        }

        [HttpGet("/login/participante")]
        public IActionResult LoginPart(string email, string password)
        {
            if (IsValidUserPart(email, password))
            {
                var claimsPrincipal = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new[] 
                    { 
                        new Claim(ClaimTypes.Email, email),
                        new Claim("Role", "Participante") // Adicionando a claim de Role
                    },
                    BearerTokenDefaults.AuthenticationScheme
                    )
                );
                return SignIn(claimsPrincipal);
            }
            return Unauthorized("Credenciais inválidas");
        }

        private bool IsValidUserPart(string email, string password)
        {
            var participante = _context.Participantes.FirstOrDefault(a => a.EMail == email);
            if (participante == null) return false;
            return email == participante.EMail && password == participante.Senha;
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
