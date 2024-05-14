using backend.Repositories.BaseRepo;
using backend.Services.BaseService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class BaseController<T, TCreateDto, TReadDto, TUpdateDto> : ControllerBase
    {
        protected readonly IBaseService<T, TCreateDto, TReadDto, TUpdateDto> _service;

        public BaseController(IBaseService<T, TCreateDto, TReadDto, TUpdateDto> service)
        {
            _service = service;

        }

        [HttpPost]
        public async Task<ActionResult<TReadDto?>> Create(TCreateDto create)
        {
            var result = await _service.CreateAsync(create);
            return result;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TReadDto?>> Get([FromRoute] int id)
        {
            return Ok(await _service.GetAsync(id));
        }

        [HttpGet]
        public virtual async Task<ActionResult<ICollection<TReadDto>>> GetAll([FromQuery] QueryOptions options)
        {
            return Ok(await _service.GetAllAsync(options));
        }

        [HttpPatch("{id:int}")]
        public virtual async Task<ActionResult<TReadDto?>> Update(int id, TUpdateDto update)
        {
            var item = await _service.UpdateAsync(id, update);
            return Ok(item);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _service.DeleteAsync(id))
            {
                return Ok(new { Message = "Item is deleted " });
            }
            return NotFound("Item is not found");
        }
    }
}
