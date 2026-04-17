using ClinicManager.Data;
using ClinicManager.DTOs.DocumentTypes;
using ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DocumentTypesController : ControllerBase
	{
		private readonly ClinicManagerDbContext _context;

		public DocumentTypesController(ClinicManagerDbContext context)
		{
			_context = context;
		}

		// GET: api/documentType
		[HttpGet]
		public async Task<ActionResult<IEnumerable<DocumentTypeDto>>> GetAll()
		{
			return await _context.DocumentTypes
				.Select(x => new DocumentTypeDto
				{
					DocTypeId = x.DocTypeId,
					Description = x.Description
				})
				.ToListAsync();
		}

		// POST
		[HttpPost]
		public async Task<ActionResult> Create(CreateDocumentTypeDto dto)
		{
			var entity = new DocumentType
			{
				Description = dto.Description
			};

			_context.DocumentTypes.Add(entity);
			await _context.SaveChangesAsync();

			return Ok();
		}

		// PUT
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UpdateDocumentTypeDto dto)
		{
			var entity = await _context.DocumentTypes.FindAsync(id);

			if (entity == null)
				return NotFound();

			entity.Description = dto.Description;

			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var entity = await _context.DocumentTypes.FindAsync(id);

			if (entity == null)
				return NotFound();

			_context.DocumentTypes.Remove(entity);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}