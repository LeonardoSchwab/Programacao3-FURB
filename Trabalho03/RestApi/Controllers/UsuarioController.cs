using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestApi.Domain.Models;
using RestApi.Domain.Services;
namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService service;
        public UsuarioController(IUsuarioService service)
        {
            this.service = service;
        }

        // GET: api/Usuario
        [HttpGet]
        public List<Usuario> Get()
        {
            var usuarios = service.ListAll();
            return usuarios;
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = service.GetById(id);
            if (usuario != null)
                return Ok(usuario);
            return NotFound();
        }

        // POST: api/Usuario
        [HttpPost]
        public Usuario Post([FromBody] Usuario usuario)
        {
            service.Add(usuario);
            return usuario;
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Usuario usuario)
        {
            var usuarioFinded = service.GetById(id);
            if (usuarioFinded == null)
                return NotFound();
            usuario.Id = id;
            service.Update(usuario);
            return Ok(usuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var usuarioFinded = service.GetById(id);
            if (usuarioFinded == null)
                return NotFound();
            service.DeleteById(id);
            return Ok();
        }        
    }
}