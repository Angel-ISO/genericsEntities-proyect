using Core.Entitities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class MovieController : BaseApiController
{

    private readonly MoviesContext _context;
    public MovieController(MoviesContext context)
    {
        _context = context;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Movie>>> Get()
    {
        var person = await _context.Movies.ToListAsync();
        return Ok(person);
    }
     [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byiduser = await _context.Usuarios.FindAsync(id);
        return Ok(byiduser);
    }
}

   