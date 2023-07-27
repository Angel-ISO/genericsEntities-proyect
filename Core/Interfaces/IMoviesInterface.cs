using System.Linq.Expressions;
using Core.Entities;

namespace CoreInterfaces;
public interface IMoviesInterface
{
    Task<Movie> GetByIdAsync(int id);
    Task <IEnumerable<Movie>> GetAllAsync();
    IEnumerable<Movie>  Find(Expression<Func<Movie, bool>> expression);
    void AddRange (IEnumerable<Movie> Entities);
    void Remove (Movie entity);
    void RemoveRange(IEnumerable<Movie> Entities);
    void Update (Movie entity);
}

