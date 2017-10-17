namespace TennisLinks.Models.Interfaces
{
    public interface IMessage
    {
        string Author { get; set; }
        string Content { get; set; }
        string Recipient { get; set; }
        string Title { get; set; }
    }
}