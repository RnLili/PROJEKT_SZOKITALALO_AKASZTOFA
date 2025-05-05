using Microsoft.AspNetCore.Mvc;
using SZOKITALALOAKASZTOFA_X6N2KU_RUTH.Data;

namespace SZOKITALALOAKASZTOFA_X6N2KU_RUTH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordController : ControllerBase
    {
        IWordRepository repo;

        public WordController(IWordRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IEnumerable<string> GetWords()
        {
            return repo.Read();
        }
        [HttpGet("GetRandomWord")]
        public IActionResult GetRandomWord()
        {
            return Ok(new { word = repo.ReadRandom() });
        }
    }
}
