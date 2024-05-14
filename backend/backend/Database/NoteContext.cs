using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class NoteContext : DbContext
    {
        static NoteContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }


        public NoteContext(DbContextOptions<NoteContext> options) : base(options) { }
        public DbSet<Note> Notes { get; set; }
    }
}
