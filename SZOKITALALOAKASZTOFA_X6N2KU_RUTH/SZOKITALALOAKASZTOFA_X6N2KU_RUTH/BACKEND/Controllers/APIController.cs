using Microsoft.AspNetCore.Mvc;
using SZOKITALALOAKASZTOFA_X6N2KU_RUTH.BACKEND.Data;

namespace SZOKITALALOAKASZTOFA_X6N2KU_RUTH.BACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIController : ControllerBase
    {
        IWordRepository repo;

        public APIController()
        {

        }
    }
}
