using Microsoft.AspNetCore.Mvc;
using SZOKITALALOAKASZTOFA_X6N2KU_RUTH.Data;
using SZOKITALALOAKASZTOFA_X6N2KU_RUTH.Model;

namespace SZOKITALALOAKASZTOFA_X6N2KU_RUTH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordController : ControllerBase
    {
        IWordRepository repo;
        private static string RandomWord;
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
            RandomWord = repo.ReadRandom();
            return Ok(new { word = RandomWord });
        }

        [HttpPost("Check")]
        public IActionResult Check([FromBody] WordRequest request)
        {
            if (string.IsNullOrEmpty(request.Word))
            {
                return BadRequest(new { message = "Invalid input!" });
            }

            string inputWord = request.Word.ToLower();
            string refWord = RandomWord.ToLower();

            if (inputWord.Length != refWord.Length)
            {
                return BadRequest(new { message = "Words must be the same length!" });
            }

            List<int> differences = new List<int>();

            for (int i = 0; i < inputWord.Length; i++)
            {
                if (inputWord[i] != refWord[i])
                {
                    int distance = Math.Abs(inputWord[i] - refWord[i]); 
                    differences.Add(distance);
                }
                else
                {
                    differences.Add(0);
                }
            }

            return Ok(new
            {
                refWord,
                differences,
                inputWord
            });
        }
    }
   
}
