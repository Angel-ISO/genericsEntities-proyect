using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using CoreInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class GenreRepository : IGenreInterface
{
    private readonly MoviesContext _context;
    public GenreRepository(MoviesContext context)=>_context = context;

    public void Add(Genre entity)=>_context.Set<Genre>().Add(entity);

    public void AddRange(IEnumerable<Genre> entities)=>_context.Set<Genre>().AddRange(entities);

    public IEnumerable<Genre> Find(Expression<Func<Genre, bool>> expression)=>_context.Set<Genre>().Where(expression);

    public async Task<IEnumerable<Genre>> GetAllAsync()=>await _context.Set<Genre>().ToListAsync();

    public async Task<Genre> GetByIdAsync(int id)=>(await _context.Set<Genre>().FindAsync(id))!;

    public void Remove(Genre entity)=>_context.Set<Genre>().Remove(entity);

    public void RemoveRange(IEnumerable<Genre> entities)=>_context.Set<Genre>().RemoveRange(entities);

    public void Update(Genre entity)=>_context.Set<Genre>().Update(entity);
}