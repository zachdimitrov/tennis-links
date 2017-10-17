using System;
using System.ComponentModel.DataAnnotations.Schema;
using TennisLinks.Models.Abstracts;
using TennisLinks.Models.Interfaces;

namespace TennisLinks.Models
{
    public class Favorite : DataModel, IFavorite
    {
        public string UserName { get; set; }

        public Guid? Details_Id { get; set; }

        [ForeignKey("Details_Id")]
        public virtual Details Details { get; set; }
    }
}
