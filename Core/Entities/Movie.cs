using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class Movie : BaseEntityA
{
    public string? Tittle { get; set; }
    public int Year { get; set; }
    public int Duration { get; set; }
    public int Id_Director { get; set;}
    public Director ? Director { get; set; }
    public int Id_Genre { get; set; }
     public Genre ? Genre { get; set; }


}

