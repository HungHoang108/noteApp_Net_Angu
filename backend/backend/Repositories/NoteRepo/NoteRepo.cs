using backend.Database;
using backend.Models;
using backend.Repositories.BaseRepo;

namespace backend.Repositories.NoteRepo
{
    public class NoteRepo : BaseRepo<Note>, INoteRepo
    {
        public NoteRepo(NoteContext context, ILogger<BaseRepo<Note>> logger) : base(context, logger)
        {
        }
    }
}
