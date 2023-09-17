using full_stack.Models;
using Microsoft.AspNetCore.Mvc;
using full_stack.Logic;
using full_stack.Util.Interfaces;
using full_stack.Util.Classes;

namespace full_stack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidatorController : ControllerBase
    {
        private readonly ICSVService _csvService;

        public ValidatorController(ICSVService csvService)
        {
            _csvService = csvService;
        }

        [Route("Validate")]
        [HttpPost]
        public async Task<IActionResult> Validate(IFormCollection data, IFormFile csvFile, IFormFile stateFile)
        {
            ValidateCSV validateCSV = new ValidateCSV(_csvService);
            List<Employee> Returnedemployees = new List<Employee>();

            Returnedemployees = validateCSV.Validate(csvFile, stateFile);
            return Ok(Returnedemployees);

            
        }

        [Route("GetPagedData")]
        [HttpPost]
        public IActionResult GetPagedData([FromBody] PagedRequest pagedRequest)
        {
            /*
             * To Do
             */
            return Ok();
        }
    }
}