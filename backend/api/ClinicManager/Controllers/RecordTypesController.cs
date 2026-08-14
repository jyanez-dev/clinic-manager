using System.Xml.Linq;
using ClinicManager.Data;
using ClinicManager.DTOs.RecordTypes;
using ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
		public async Task<ActionResult<IEnumerable<RecordTypeDto>>> GetRecordTypes()
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
			var recordType = new RecordType
			{
				Name = dto.Name
            };

			_context.RecordTypes.Add(recordType);
			await _context.SaveChangesAsync();

			var result = new RecordTypeDto
			{
				Name = recordType.Name
			};

			return CreatedAtAction(nameof(GetRecordTypes), new {id = recordType.RecordTypeId },  result);
			
		}

		// PUT
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UpdateRecordTypeDto dto)
		{
			var recordType = await _context.RecordTypes.FindAsync(id);

			if (recordType == null)
				return NotFound();

			recordType.Name = dto.Name;

			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var recordType = await _context.RecordTypes.FindAsync(id);

			if (recordType == null)
				return NotFound();

			_context.RecordTypes.Remove(recordType);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
