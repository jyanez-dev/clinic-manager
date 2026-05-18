using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicManager.Data;
using ClinicManager.Models;
using ClinicManager.DTOs.RecordTypes;

namespace ClinicManager.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RecordTypesController : ControllerBase
	{
		private readonly ClinicManagerDbContext _context;

		public RecordTypesController(ClinicManagerDbContext context)
		{
			_context = context;
		}

		// GET: api/RecordTypes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<RecordTypeDto>>> GetAll()
		{
			return await _context.RecordTypes
				.Select(x => new RecordTypeDto
				{
					RecordTypeId = x.RecordTypeId,
					Name = x.Name
				})
				.ToListAsync();
		}

		// POST
		[HttpPost]
		public async Task<ActionResult> Create(CreateRecordTypeDto dto)
		{
			var entity = new RecordType
			{
				Name = dto.Name
            };

			_context.RecordTypes.Add(entity);
			await _context.SaveChangesAsync();

			return Ok();
		}

		// PUT
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UpdateRecordTypeDto dto)
		{
			var entity = await _context.RecordTypes.FindAsync(id);

			if (entity == null)
				return NotFound();

			entity.Name = dto.Name;

			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var entity = await _context.RecordTypes.FindAsync(id);

			if (entity == null)
				return NotFound();

			_context.RecordTypes.Remove(entity);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
