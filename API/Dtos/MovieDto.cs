using Core.Entities;

namespace API.Dtos;

public class MovieDto
{
    public int IdMovie { get; set; }
    public string Tittle { get; set; }
    public int Year { get; set; }
    public int Duration { get; set; }
    public int Id_Director { get; set;}
    public int Id_Genre { get; set; }
}
