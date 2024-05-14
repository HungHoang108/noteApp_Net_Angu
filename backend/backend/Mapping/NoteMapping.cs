using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Mapping
{
    public class NoteMapping : Profile
    {
        public NoteMapping()
        {
            CreateMap<NoteCreateDto, Note>();
            CreateMap<Note, NoteReadDto>();
            CreateMap<NoteUpdateDto, Note>();
        }
    }
}
