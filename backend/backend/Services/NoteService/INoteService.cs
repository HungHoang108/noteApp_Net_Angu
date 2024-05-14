using backend.DTOs;
using backend.Models;
using backend.Services.BaseService;

namespace backend.Services.NoteService
{
    public interface INoteService : IBaseService<Note, NoteCreateDto, NoteReadDto, NoteUpdateDto>
    {
    }
}
