namespace Core.Entities;
public class Genre
{
    public ICollection<Movie> ?Movies { get; set; }
    public string ? Name { get; set; }
}

