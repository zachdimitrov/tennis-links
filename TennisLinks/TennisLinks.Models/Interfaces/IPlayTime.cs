using System.Collections.Generic;
using TennisLinks.Models.Enumerations;

namespace TennisLinks.Models.Interfaces
{
    public interface IPlayTime
    {
        TimeOfDay Time { get; set; }
        ICollection<Details> UserDetails { get; set; }
    }
}