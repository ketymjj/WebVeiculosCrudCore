using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebVeiculosCrud.Data;
using WebVeiculosCrud.Models;

namespace WebVeiculosCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VeiculosModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/VeiculosModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculosModel>>> Get()
        {
            return await _context.VeiculosModel.ToListAsync();
        }

        // GET: api/VeiculosModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var veiculosModel = await _context.VeiculosModel.FindAsync(id);

            if (veiculosModel == null)
            {
                return NotFound();
            }

            return Ok(veiculosModel);
        }

        // PUT: api/VeiculosModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] VeiculosModel veiculosModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != veiculosModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(veiculosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculosModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VeiculosModels
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VeiculosModel veiculosModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.VeiculosModel.Add(veiculosModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeiculosModel", new { id = veiculosModel.Id }, veiculosModel);
        }

        // DELETE: api/VeiculosModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var veiculosModel = await _context.VeiculosModel.FindAsync(id);
            if (veiculosModel == null)
            {
                return NotFound();
            }

            _context.VeiculosModel.Remove(veiculosModel);
            await _context.SaveChangesAsync();

            return Ok(veiculosModel);
        }

        private bool VeiculosModelExists(int id)
        {
            return _context.VeiculosModel.Any(e => e.Id == id);
        }
    }
}