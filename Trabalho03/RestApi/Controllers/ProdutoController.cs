using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestApi.Domain.Models;
using RestApi.Domain.Services;
namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService service;
        public ProdutoController(IProdutoService service)
        {
            this.service = service;
        }

        // GET: api/Produto
        [HttpGet]
        public List<Produto> Get()
        {
            var produtos = service.ListAll();
            return produtos;
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = service.GetById(id);
            if (produto != null)
                return produto;
            return NotFound();
        }

        // POST: api/Produto
        [HttpPost]
        public Produto Post([FromBody] Produto produto)
        {
            service.Add(produto);
            return produto;
        }

        // PUT: api/Produto/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
            var produtoFinded = service.GetById(id);
            if (produtoFinded == null)
                return NotFound();
            produto.Id = id;
            service.Update(produto);
            return Ok(produto);
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var produtoFinded = service.GetById(id);
            if (produtoFinded == null)
                return NotFound();
            service.DeleteById(id);
            return Ok();
        }        
    }
}