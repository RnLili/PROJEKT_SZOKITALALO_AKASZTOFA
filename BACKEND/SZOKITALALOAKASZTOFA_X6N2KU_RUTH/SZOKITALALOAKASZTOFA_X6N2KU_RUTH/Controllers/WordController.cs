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
        [HttpGet("Words")]
        public IEnumerable<string> GetWords()
        {
            return repo.Read();
        }
        [HttpGet("RandomWord")]
        public string GetRandomWord()
        {
            return repo.ReadRandom();
        }
    }
}
