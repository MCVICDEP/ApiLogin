using apilogin.data.Repo;
using apilogin.modelo;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apitienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioControlador : ControllerBase
    {
        private readonly ILoginRepo _loginrepo;

        public UsuarioControlador(ILoginRepo loginrepo)
        {
            _loginrepo = loginrepo;
        }

        [HttpGet]

        public async Task<IActionResult> GetUsuarios()
        {
            return Ok(await _loginrepo.GetUsuarios());
        }

        [HttpGet("{idusuario}")]

        public async Task<IActionResult> GetDetalles(int id)
        {
            return Ok(await _loginrepo.GetDetalles(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertarUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _loginrepo.InsertarUsuario(usuario);
            return Created("Insertado", creado);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _loginrepo.UpdateUsuario(usuario);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            await _loginrepo.EliminarUsuario(new Usuario { idusuario = id });

            return NoContent();
        }

        [HttpGet]
        [Route("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion(string correo, string password)
        {
            Response<Usuario> _response = new Response<Usuario>();
            try
            {
                Usuario _usuario = await _usuarioRepositorio.Obtener(u => u.Correo == correo && u.Clave == password);

                if (_usuario != null)
                    _response = new Response<Usuario>() { status = true, msg = "ok", value = _usuario };
                else
                    _response = new Response<Usuario>() { status = false, msg = "no encontrado", value = null };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<Usuario>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
