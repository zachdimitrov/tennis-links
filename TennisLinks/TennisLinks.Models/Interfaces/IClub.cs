using System;
using System.Collections.Generic;
using TennisLinks.Models.Enumerations;

namespace TennisLinks.Models.Interfaces
{
    public interface IClub
    {
        City City { get; set; }
        Guid? City_Id { get; set; }
        string Name { get; set; }
        Surface SurfaceType { get; set; }
        ICollection<Details> UserDetails { get; set; }
    }
}