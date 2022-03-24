using Api.Controllers.Categories.Requests;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Categories
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepositoryBase<Category, Guid> _repository;

        public CategoriesController(IRepositoryBase<Category, Guid> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetAll()
        {
            var categories = await _repository.GetAllAsync();
            var response = categories.Select(category => new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name
            });

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] UpsertCategoryRequest request)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _repository.AddAsync(category);

            return Ok(category.Id);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpsertCategoryRequest request)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            category.Name = request.Name;

            await _repository.UpdateAsync(category);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await _repository.RemoveAsync(category);

            return Ok();
        }

    }
}
