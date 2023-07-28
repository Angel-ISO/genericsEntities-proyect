using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 public class GenreController : BaseApiController
{

     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public GenreController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Movie>>> Get()
    {
        var Gen = await  unitofwork.Genres.GetAllAsync();
        return Ok(Gen);
    }
     [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidGenre = await  unitofwork.Genres.GetByIdAsync(id);
        return Ok(byidGenre);
    }
 [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Genre>> Post(Genre genre){
        this.unitofwork.Genres.Add(genre);
        await unitofwork.SaveAsync();
        if(genre == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= genre.Id}, genre);
    }


}