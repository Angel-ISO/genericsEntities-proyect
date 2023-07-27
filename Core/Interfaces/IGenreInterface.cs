using System.Linq.Expressions;
using Core.Entities;


namespace Core.Interfaces;

public interface IGenreInterface
{
Task<Genre> GetByIdAsync(int id);
Task <IEnumerable<Genre>> GetAllAsync();
IEnumerable<Genre>  Find(Expression<Func<Genre, bool>> expression);

void Add (Genre entity);
void AddRange (IEnumerable<Genre> Entities);
void Remove (Genre entity);
void RemoveRange(IEnumerable<Genre> Entities);
void Update (Genre entity);
}
