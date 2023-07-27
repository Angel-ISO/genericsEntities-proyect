using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers;


public class DirectorController : BaseApiController
{

    private readonly MoviesContext _context;
    public DirectorController(MoviesContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Movie>>> Get()
    {
        var person = await _context.Directors.ToListAsync();
        return Ok(person);
    }
     [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byiduser = await _context.Directors.FindAsync(id);
        return Ok(byiduser);
    }

}