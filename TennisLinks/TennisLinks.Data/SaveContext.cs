using TennisLinks.Data.Interfaces;

namespace TennisLinks.Data
{
    public class SaveContext : ISaveContext
    {
        private readonly MsSqlDbContext context;

        public SaveContext(MsSqlDbContext context)
        {
            this.context = context;
        }

        public int Commit()
        {
            return this.context.SaveChanges();
        }
    }
}
