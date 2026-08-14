using ClinicManager.Data;
using ClinicManager.DTOs.Positions;
using ClinicManager.DTOs.Specialties;
using ClinicManager.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PositionsController : ControllerBase
	{
		private readonly ClinicManagerDbContext _context;

		public PositionsController(ClinicManagerDbContext context)
		{
			_context = context;
		}

		// GET: api/Positions
		[HttpGet]
		public async Task<ActionResult<IEnumerable<PositionDTO>>> GetPostions()
		{
			var positions = await _context.Positions
			   .Select(p => new PositionDTO
			   {
				   PositionId = p.PositionId,
				   Name = p.Name
			   })
			   .ToListAsync();

			return positions;
		}

		[HttpGet("{id}")]

		public async Task<ActionResult<PositionDTO>> GetPosition(int id)
		{
			var position = await _context.Positions.FindAsync(id);

			if (position == null)
				return NotFound();

			return new PositionDTO
			{
				PositionId = position.PositionId,
				Name = position.Name
			};

		}

		// POST
		[HttpPost]
		public async Task<ActionResult<PositionDTO>> CreatePosition(CreatePositionDTO dto)
		{
			var position = new Position
			{
				Name = dto.Name,
			};

			_context.Positions.Add(position);
			await _context.SaveChangesAsync();

			var result = new PositionDTO
			{
				PositionId = position.PositionId,
				Name = position.Name
			};

			return CreatedAtAction(nameof(GetPosition), new { id = position.PositionId }, result);

		}


		//PUT
		[HttpPut]

		public async Task<IActionResult> UpdatePosition(int id, UpdatePositionDTO dto)
		{
			if (id != dto.PositionId)
				return BadRequest();

			var position = await _context.Positions.FindAsync(id);

			if (position == null)
				return BadRequest();

			position.Name = dto.Name;

			await _context.SaveChangesAsync();
			return NoContent();

		}

		//DELETE
		[HttpDelete("{id}")]

		public async Task<IActionResult> DeletePosition(int id)
		{
		  var position = await _context.Positions.FindAsync(id);
		
		  if (position == null)
		   return NotFound();

		   _context.Positions.Remove(position);

		   await _context.SaveChangesAsync();
			return NoContent();	

		  
		  }
		
		
	}
}
