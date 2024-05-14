using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{

    public class NoteBaseDto
    {
        [StringLength(500, MinimumLength = 3)]
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }

    public class NoteCreateDto : NoteBaseDto
    {
    }

    public class NoteReadDto : NoteBaseDto
    {
        public int Id { get; set; }
    }

    public class NoteUpdateDto : NoteBaseDto
    {
    }

}
