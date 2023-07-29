using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class MovieController : BaseApiController
{
     private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;     

    public MovieController(IUnitOfWork unitOfWork,  IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;        
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Movie>>> Get()
    {
        var Mivie = await unitofwork.Movies.GetAllAsync();
        return Ok(Mivie);
    }
     [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidmovie = await unitofwork.Movies.GetByIdAsync(id);
        return Ok(byidmovie);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Movie>> Post(Movie movie){
        this.unitofwork.Movies.Add(movie);
        await unitofwork.SaveAsync();
        if(movie == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= movie.Id}, movie);
    }
     [HttpPut("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Movie>> Put(int id, [FromBody]Movie movie){
        if(movie == null)
            return NotFound();
        unitofwork.Movies.Update(movie);
        await unitofwork.SaveAsync();
        return movie;
    }
    [HttpDelete("id")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var film = await unitofwork.Movies.GetByIdAsync(id);
        if(film == null){
            return NotFound();
        }
        unitofwork.Movies.Remove(film);
        await unitofwork.SaveAsync();
        return NoContent();
    }

}