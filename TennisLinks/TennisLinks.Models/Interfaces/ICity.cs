using System.Collections.Generic;

namespace TennisLinks.Models.Interfaces
{
    public interface ICity
    {
        ICollection<Club> Clubs { get; set; }
        string Name { get; set; }
        ICollection<Details> UserDetails { get; set; }
    }
}