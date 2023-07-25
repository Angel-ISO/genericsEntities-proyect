namespace Core.Entities;
public class Genre : BaseEntityA
{
    public ICollection<Movie> ?Movies { get; set; }
    public string ? Name { get; set; }
}

