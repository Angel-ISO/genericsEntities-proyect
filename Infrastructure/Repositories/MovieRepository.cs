using System.Linq.Expressions;
using Core.Entities;
using CoreInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class MovieRepository : IMoviesInterface
{
    private readonly MoviesContext _context;
    public MovieRepository(MoviesContext context)=>_context = context;

    public void Add(Movie entity)=>_context.Set<Movie>().Add(entity);

    public void AddRange(IEnumerable<Movie> entities)=>_context.Set<Movie>().AddRange(entities);

    public IEnumerable<Movie> Find(Expression<Func<Movie, bool>> expression)=>_context.Set<Movie>().Where(expression);

    public async Task<IEnumerable<Movie>> GetAllAsync()=>await _context.Set<Movie>().ToListAsync();

    public async Task<Movie> GetByIdAsync(int id)=>(await _context.Set<Movie>().FindAsync(id))!;

    public void Remove(Movie entity)=>_context.Set<Movie>().Remove(entity);

    public void RemoveRange(IEnumerable<Movie> entities)=>_context.Set<Movie>().RemoveRange(entities);

    public void Update(Movie entity)=>_context.Set<Movie>().Update(entity);
}