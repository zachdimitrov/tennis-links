using System;
using System.Collections.Generic;
using TennisLinks.Models.Enumerations;

namespace TennisLinks.Models.Interfaces
{
    public interface IDetails
    {
        int? Age { get; set; }
        City City { get; set; }
        Guid? City_Id { get; set; }
        Club Club { get; set; }
        Guid? Club_Id { get; set; }
        IEnumerable<Favorite> Favorites { get; set; }
        Gender? Gender { get; set; }
        string Info { get; set; }
        PlayTime PlayTime { get; set; }
        Guid? PlayTime_Id { get; set; }
        double Skill { get; set; }
    }
}