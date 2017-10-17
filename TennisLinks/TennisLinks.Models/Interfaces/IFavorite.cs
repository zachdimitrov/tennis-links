using System;

namespace TennisLinks.Models.Interfaces
{
    public interface IFavorite
    {
        Details Details { get; set; }
        Guid? Details_Id { get; set; }
        string UserName { get; set; }
    }
}