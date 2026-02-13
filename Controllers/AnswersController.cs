using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpitiPVC.Data;
using UpitiPVC.Models;

namespace UpitiPVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AnswersController(ApplicationDbContext _context)
        {
            context= _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnswers()
        {
            return Ok(await context.Answers.ToListAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAnswerById([FromRoute]int id)
        {
            var answer = await context.Answers.FirstOrDefaultAsync(x=>x.AnswerId== id);
            if (answer == null) return NotFound();
            return Ok(answer);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnswer(Answer answer)
        {
            if (ModelState.IsValid)
            {
                answer.CreatedTime = DateTime.Now;
                await context.Answers.AddAsync(answer);
                await context.SaveChangesAsync();
                return CreatedAtAction(nameof(AddAnswer), answer);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAnswer([FromRoute]int id, [FromBody]Answer answerUpdated)
        {
            var answer = await context.Answers.FirstOrDefaultAsync(x => x.AnswerId == id);
            if(answer==null) return NotFound();
            answer.AnswerText = answerUpdated.AnswerText;
            await context.SaveChangesAsync();
            return Ok(answer);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAnswer([FromRoute]int id)
        {
            var answer = await context.Answers.FirstOrDefaultAsync(x => x.AnswerId == id);
            if(answer==null) return NotFound();
            context.Remove(answer);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
