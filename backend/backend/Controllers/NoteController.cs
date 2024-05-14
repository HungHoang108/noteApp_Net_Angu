using backend.DTOs;
using backend.Models;
using backend.Services.BaseService;

namespace backend.Controllers
{
    public class NoteController : BaseController<Note, NoteCreateDto, NoteReadDto, NoteUpdateDto>
    {
        public NoteController(IBaseService<Note, NoteCreateDto, NoteReadDto, NoteUpdateDto> service) : base(service)
        {
        }
    }
}
