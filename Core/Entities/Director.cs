namespace Core.Entities;

public class Director
{
    public ICollection<Movie> ?Movies { get; set; }

    public string ? Name { get; set; }
    public DateTime Bornage { get; set; }
    public string ? Nationality { get; set; }

}
