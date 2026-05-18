using ClinicManager.Data;
using ClinicManager.DTOs.Specialties;
using ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//using System.Data;







namespace ClinicManager.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class SpecialtiesController : ControllerBase
	{
		private readonly ClinicManagerDbContext _context;

		public SpecialtiesController(ClinicManagerDbContext context)
		{
			_context = context;
		}

		// GET: api/specialies
		[HttpGet]
		public async Task<ActionResult<IEnumerable<SpecialtyDTO>>> GetSpecialties()
		{
			var specialties = await _context.Specialties
				.Select(s => new SpecialtyDTO
				{
					SpecialtyId = s.SpecialtyId,
					Name = s.Name,
				})
				.ToListAsync();

			return specialties;

		}

		[HttpGet("{id}")]
		public async Task<ActionResult<SpecialtyDTO>> GetSpecialty(int id)
		{
			var specialty = await _context.Specialties.FindAsync(id);

			if (specialty == null)
				return NotFound();

			return new SpecialtyDTO
			{
				SpecialtyId = specialty.SpecialtyId,
				Name = specialty.Name
			};
		}

		// POST
		[HttpPost]
		public async Task<ActionResult<SpecialtyDTO>> CreateSpecialty(CreateSpecialtyDTO dto)
		{
			var specialty = new Specialty
			{
				Name = dto.Name,
			};
			_context.Specialties.Add(specialty);
			await _context.SaveChangesAsync();

			var result = new SpecialtyDTO
			{
				SpecialtyId = specialty.SpecialtyId,
				Name = specialty.Name
			};

			return CreatedAtAction(nameof(GetSpecialty), new { id = specialty.SpecialtyId }, result);
		}

		//PUT
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSpecialty(int id, UpdateSpecialtyDTO dto)
		{ 
		  if (id != dto.SpecialtyId)
				return BadRequest();

			var specialty = await _context.Specialties.FindAsync(id);

			if (specialty == null)
				return BadRequest();

			specialty.Name = dto.Name;

			await _context.SaveChangesAsync();
			return NoContent();
		}

		//DELETE
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSpecialty(int id)
		{
			var speciality = await _context.Specialties.FindAsync(id);

				if (speciality == null)
				  return NotFound();

			_context.Specialties.Remove(speciality);
			
			await _context.SaveChangesAsync();
			return NoContent() ;

		}

    }

}