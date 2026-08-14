using ClinicManager.Data;
using ClinicManager.DTOs.AppointmentStatus;
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
		public async Task<ActionResult<IEnumerable<DocumentTypeDto>>> GetDocumentTypes()
		{
			return await _context.DocumentTypes
				.Select(x => new DocumentTypeDto
				{
					DocTypeId = x.DocTypeId,
					Name = x.Name
				})
				.ToListAsync();
		}

		// POST
		[HttpPost]
		public async Task<ActionResult> Create(CreateDocumentTypeDto dto)
		{
			var documentType = new DocumentType
			{
				Name = dto.Name
			};

			_context.DocumentTypes.Add(documentType);
			await _context.SaveChangesAsync();


			var result = new DocumentTypeDto
			{
				Name = documentType.Name
			};

			return CreatedAtAction(nameof(GetDocumentTypes),
				new { id = documentType.DocTypeId }, result);
			
		}

		// PUT
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UpdateDocumentTypeDto dto)
		{
			var documentType = await _context.DocumentTypes.FindAsync(id);

			if (documentType == null)
				return NotFound();

			documentType.Name = dto.Name;

			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var documentType = await _context.DocumentTypes.FindAsync(id);

			if (documentType == null)
				return NotFound();

			_context.DocumentTypes.Remove(documentType);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}