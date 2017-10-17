using System.Linq;
using TennisLinks.Models;

namespace TennisLinks.Services.Interfaces
{
    public interface IMessageService
    {
        int Add(Message message);
        int Delete(Message message);
        IQueryable<Message> GetAll();
        int Update(Message message);
    }
}