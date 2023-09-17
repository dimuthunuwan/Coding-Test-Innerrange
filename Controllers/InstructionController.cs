using Microsoft.AspNetCore.Mvc;

namespace full_stack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstructionController : ControllerBase
    {
        [Route("GetInstruction")]
        [HttpGet]
        public IActionResult GetInstruction()
        {
            string instrction = System.IO.File.ReadAllText("Instruction.md");
            return Ok(instrction);
            
        }

        
    }
}