using Microsoft.AspNetCore.Mvc;
using OrcamentoAPI.Data;
using OrcamentoAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrcamentoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceitaController : ControllerBase
    {
        private ReceitaContext _context;

        public ReceitaController(ReceitaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Receita> RecuperaReceitas()
        {
            return _context.Receitas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaReceitaPorID ( int id)
        {
            Receita receita = _context.Receitas.FirstOrDefault(receita => receita.Id == id);
            if (receita != null)
            {
                return Ok(receita);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AdicionaReceita([FromBody] Receita receita)
        {
            _context.Receitas.Add(receita);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaReceitaPorID), new { Id = receita.Id }, receita);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaReceita(int id, [FromBody] Receita novaReceita)
        {
            Receita receita = _context.Receitas.FirstOrDefault (receita => receita.Id == id);
            if (receita != null)
            {
                receita.Descricao = novaReceita.Descricao;
                receita.Valor = novaReceita.Valor;
                receita.Data = novaReceita.Data;
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaReceita(int id)
        {
            Receita receita = _context.Receitas.FirstOrDefault (receita => receita.Id == id);
            if (receita != null)
            {
                _context.Remove(receita);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}
