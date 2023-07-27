using Core.Entities;
using Core.Interfaces;
using CoreInterfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork,IDisposable
{    
    private readonly MoviesContext _context;
    private MovieRepository? _movie;
    private DirectorRepository? _director;
    private GenreRepository? _genre;


    
    public UnitOfWork(MoviesContext context)=>_context = context;


 public IMoviesInterface Movies{
        get{
            if(_movie is not null){
                return _movie;
            }
            return _movie = new(_context);
        }
    }

 public IDirectorInterface Directors{
        get{
            if(_director is not null){
                return _director;
            }
            return _director = new(_context);
        }
    }

 public IGenreInterface Genres{
        get{
            if(_genre is not null){
                return _genre;
            }
            return _genre = new(_context);
        }
    }


    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync(){
        return await _context.SaveChangesAsync();
    }
}