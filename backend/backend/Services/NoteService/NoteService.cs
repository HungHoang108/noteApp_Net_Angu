using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories.BaseRepo;
using backend.Services.BaseService;

namespace backend.Services.NoteService
{
    public class NoteService : BaseService<Note, NoteCreateDto, NoteReadDto, NoteUpdateDto>, INoteService
    {
        public NoteService(IMapper mapper, IBaseRepo<Note> repo, ILogger<BaseService<Note, NoteCreateDto, NoteReadDto, NoteUpdateDto>> logger) : base(mapper, repo, logger)
        {
        }
    }
}
