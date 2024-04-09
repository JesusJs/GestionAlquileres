using AppGestorPropiedades.Dominio.Modelos;
using AppGestorPropiedades.Infraestructura.Datos.DTO;
using AppGrestorPropiedades.Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppGestorPropiedades.Infraestructura.API.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class ClientesController : Controller
    {
        
        public IConfiguration _configuracion;
        private readonly IMapper mapper;
        private IClientesUseCase cliente;
        public ClientesController(IConfiguration configuracion, IMapper _mapper, IClientesUseCase _client) 
        {
            _configuracion = configuracion;
            mapper = _mapper;
            cliente = _client;
        }

        [HttpPost]
        [Route("login")]
        public dynamic IniciarSesion(ClientesDTO data)
        {
            var clientes = mapper.Map<ClientesModelos>(data);
            var usaurio =   cliente.ObtenerSesion(clientes);

            if (usaurio == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = ""
                };
            }

            var jwt = _configuracion.GetSection("Jwt").Get<JwtDTO>();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim("id", usaurio.usuarioId),
                new Claim("usuario", usaurio.usuario)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var sigIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: sigIn
                );

            return new
            {
                success = true,
                message = "exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
