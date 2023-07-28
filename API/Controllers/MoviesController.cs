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

    public MovieController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Movie>>> Get()
    {
        var Movie = await unitofwork.Movies.GetAllAsync();
        return Ok(Movie);
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

}