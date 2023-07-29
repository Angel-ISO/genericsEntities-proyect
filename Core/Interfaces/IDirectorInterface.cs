using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IDirectorInterface
{
    
Task<Director> GetByIdAsync(int id);
Task <IEnumerable<Director>> GetAllAsync();
IEnumerable<Director>  Find(Expression<Func<Director, bool>> expression);
void Add (Director entity);
void AddRange (IEnumerable<Director> Entities);
void Remove (Director entity);
void RemoveRange(IEnumerable<Director> Entities);
void Update (Director entity);
}



