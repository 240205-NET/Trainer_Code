using Microsoft.AspNetCore.Mvc;
using TheGarden.BL;
using TheGarden.DL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheGarden.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly ILogger _logger;

        public PlantController(IRepository repo, ILogger<PlantController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // GET: api/<PlantController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plant>>> GetAllPlantsAsync()
        {
            IEnumerable<Plant> plants;
            try
            {
                plants = await _repo.GetAllPlantsAsync();
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return Ok(plants.ToList());
        }

        // GET api/<PlantController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plant>> GetPlantByIdAsync(int id)
        {
            Plant returnedPlant = new Plant();
            try
            {
                returnedPlant = await _repo.GetPlantByIdAsync(id);
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return StatusCode(200, returnedPlant);
        }

        // POST api/<PlantController>
        [HttpPost]
        public async Task<ActionResult> PostNewPlant([FromBody] Plant newPlant)
        {
            try
            {
                await _repo.EnterNewPlantAsync(newPlant);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return Ok();
        }

        // PUT api/<PlantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<PlantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
