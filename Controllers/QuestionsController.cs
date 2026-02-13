using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpitiPVC.Data;
using UpitiPVC.Models;

namespace UpitiPVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public QuestionsController(ApplicationDbContext context)
        {
            this.context=context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questionsList = await context.Questions.ToListAsync();
            return Ok(questionsList);
        }
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetQuestionById")]
        public async Task<IActionResult> GetQuestionById([FromRoute]int id)
        {
            var question=await context.Questions.FirstOrDefaultAsync(x=>x.QuestionId==id);
            if(question==null) 
                return NotFound();
            return Ok(question);
        }
        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody]Question question)
        {
            if (ModelState.IsValid)
            {
                question.CreatedTime = DateTime.Now;
                await context.Questions.AddAsync(question);
                await context.SaveChangesAsync();
                return CreatedAtAction(nameof(AddQuestion),new {id=question.QuestionId}, question);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> AnswerOnQuestion([FromRoute] int id, [FromBody] Answer answer)
        {
            if (ModelState.IsValid)
            {
                var question = await context.Questions.FindAsync(id);
                if (question == null) return BadRequest();
                question.AnsweredTime = answer.CreatedTime = DateTime.Now;
                question.IsAnswered = true;
                answer.Question = null;
                answer.QuestionId = id;
                await context.Answers.AddAsync(answer);
                await context.SaveChangesAsync();
                return CreatedAtAction("AddAnswer", "Answers", new { id = answer.AnswerId }, answer);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute]int id)
        {
            var question = await context.Questions.FirstOrDefaultAsync(x => x.QuestionId == id);
            if (question == null) return NotFound();
            context.Questions.Remove(question);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
