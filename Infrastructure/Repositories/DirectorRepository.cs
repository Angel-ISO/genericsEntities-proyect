using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using CoreInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class DirectorRepository : IDirectorInterface
{
    private readonly MoviesContext _context;
    public DirectorRepository(MoviesContext context)=>_context = context;

    public void Add(Director entity)=>_context.Set<Director>().Add(entity);

    public void AddRange(IEnumerable<Director> entities)=>_context.Set<Director>().AddRange(entities);

    public IEnumerable<Director> Find(Expression<Func<Director, bool>> expression)=>_context.Set<Director>().Where(expression);

    public async Task<IEnumerable<Director>> GetAllAsync()=>await _context.Set<Director>().ToListAsync();

    public async Task<Director> GetByIdAsync(int id)=>(await _context.Set<Director>().FindAsync(id))!;

    public void Remove(Director entity)=>_context.Set<Director>().Remove(entity);

    public void RemoveRange(IEnumerable<Director> entities)=>_context.Set<Director>().RemoveRange(entities);

    public void Update(Director entity)=>_context.Set<Director>().Update(entity);
}