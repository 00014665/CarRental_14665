using CarRental_14665.Data.Models;
using CarRental_14665.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarRental_14665.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RentalController : ControllerBase
    {





        private readonly IRepository<Rentals> _rentalsRepository;
        public RentalController(IRepository<Rentals> rentalsRepository)
        {
            _rentalsRepository = rentalsRepository;
        }










        [HttpGet]
        public async Task<IEnumerable<Rentals>> GetAll() => await _rentalsRepository.GetAllAsync();














        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Rentals), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var resultedToDo = await _rentalsRepository.GetByIDAsync(id);
            return resultedToDo == null ? NotFound() : Ok(resultedToDo);
        }
















        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Rentals items)
        {
            await _rentalsRepository.AddAsync(items);
            return Ok(items);

        }













        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Rentals items)
        {
 
            await _rentalsRepository.UpdateAsync(items);
            return NoContent();
        }












        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _rentalsRepository.DeleteAsync(id);
            return NoContent();


        }



    }
}
