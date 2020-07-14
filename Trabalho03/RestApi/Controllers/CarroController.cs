using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestApi.Domain.Models;
using RestApi.Domain.Services;
namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICarroService service;
        public CarroController(ICarroService service)
        {
            this.service = service;
        }

        // GET: api/Carro
        [HttpGet]
        public List<Carro> Get()
        {
            var carros = service.ListAll();
            return carros;
        }

        // GET: api/Carro/5
        [HttpGet("{id}")]
        public ActionResult<Carro> Get(int id)
        {
            var carro = service.GetById(id);
            if (carro != null)
                return carro;
            return NotFound();
        }

        // POST: api/Carro
        [HttpPost]
        public Carro Post([FromBody] Carro carro)
        {
            service.Add(carro);
            return carro;
        }

        // PUT: api/Carro/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Carro carro)
        {
            var carroFinded = service.GetById(id);
            if (carroFinded == null)
                return NotFound();
            carro.Id = id;
            service.Update(carro);
            return Ok(carro);
        }

        // DELETE: api/Carro/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var carroFinded = service.GetById(id);
            if (carroFinded == null)
                return NotFound();
            service.DeleteById(id);
            return Ok();
        }        
    }
}