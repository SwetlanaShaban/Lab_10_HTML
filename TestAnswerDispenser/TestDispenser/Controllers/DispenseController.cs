using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDispenser.Model;

namespace TestDispenser.Controllers
{
    [Produces("application/json")]
    [Route("api/Dispense")]
    public class DispenseController : Controller
    {
        private QuestionParser _qParser;
        public DispenseController(IHostingEnvironment env)
        {
            _qParser = new QuestionParser(env.ContentRootPath + "//Tests//");
        }

        // GET: api/Dispense
        [HttpGet]
        public JsonResult Get()
        {
            return Json("");
        }

        // GET: api/Dispense/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            ICollection<Question> collection = null;
            try
            {
                collection = _qParser.readQuestion(id);
            }
            catch (ArgumentException e)
            {
                return NotFound($"Test with id {id} not found");
            }

            return Json(collection);
        }

    }
}
