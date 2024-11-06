using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStoreService.Data;
using PetStoreService.Models;

namespace PetStoreService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PetStoreContext _context;

        public PetController(PetStoreContext context)
        {
            _context = context;
        }

        // GET: api/Pet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            return await _context.Pet.ToListAsync();
        }

        // GET: api/Pet/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(Guid id)
        {
            var pet = await _context.Pet.FindAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        // POST: api/Pet
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            if (pet.Id == null || pet.Id == Guid.Empty)
            {
                pet.Id = Guid.NewGuid(); // Generate a new GUID only if not provided
            }

            _context.Pet.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
        }

        // PUT: api/Pet/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(Guid id, Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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

        // DELETE: api/Pet/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(Guid id)
        {
            var pet = await _context.Pet.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            _context.Pet.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetExists(Guid id)
        {
            return _context.Pet.Any(e => e.Id == id);
        }
    }
}