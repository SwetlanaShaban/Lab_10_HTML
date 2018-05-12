using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDispenser.Model;

namespace TestDispenser.Controllers
{
    [Produces("application/json")]
    [Route("api/answers")]
    public class AnswersController : Controller
    {

        private readonly IHostingEnvironment _env;
        private QuestionParser _qParser;

        public AnswersController(IHostingEnvironment env)
        {
            _env = env;
            _qParser = new QuestionParser(System.IO.Path.Combine(_env.WebRootPath,"//Tests"));
        }

        // GET: api/answers
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/answers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
