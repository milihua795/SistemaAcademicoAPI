using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademicoAPI.Data;
using SistemaAcademicoAPI.Models;

namespace SistemaAcademicoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MatriculasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matricula>>> GetMatriculas()
        {
            return await _context.Matriculas
                .Include(m => m.Estudiante)
                .Include(m => m.Curso)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Matricula>> GetMatricula(int id)
        {
            var matricula = await _context.Matriculas
                .Include(m => m.Estudiante)
                .Include(m => m.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (matricula == null)
                return NotFound();

            return matricula;
        }

        [HttpPost]
        public async Task<ActionResult<Matricula>> PostMatricula(Matricula matricula)
        {
            matricula.FechaMatricula = DateTime.Now;

            _context.Matriculas.Add(matricula);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMatricula),
                new { id = matricula.Id }, matricula);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatricula(int id, Matricula matricula)
        {
            if (id != matricula.Id)
                return BadRequest();

            _context.Entry(matricula).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatricula(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);

            if (matricula == null)
                return NotFound();

            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}