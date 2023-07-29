namespace Core.Interfaces;
public interface IUnitOfWork
{
    IGenreInterface Genres {get;}     
    IDirectorInterface Directors {get;}        
    IMoviesInterface Movies {get;}        

   
    Task<int> SaveAsync();
}