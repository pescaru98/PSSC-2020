using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Primitives.IO;
using StackOverflow.Domain.Core.Contexts.Questions;
using StackOverflow.Domain.Schema.Questions.CreateReplyOp;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {


        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;

        public QuestionController(IInterpreterAsync interpreter, StackUnderflowContext dbContext)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
        }

/*        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }*/
        [HttpPost("createReply")]
        public async Task<IActionResult> CreateReply([FromBody] CreateReplyCmd createReplyCmd)
        {
            var expr = from createReplyResult in QuestionDomain.CreateReply(createReplyCmd.QuestionId, createReplyCmd.Body)
                       let reply = createReplyResult.SafeCast<ReplyCreated>().Select(r => r)
                       from checkLanguageResult in QuestionDomain.CheckLanguage(createReplyCmd.Body)
                       from questionOwnerAckResult in QuestionDomain.AckQuestionOwner(createReplyCmd.QuestionId, "Some message") //de aici se poate extrage questionOwnerId
                       from replyAuthorAckResult in QuestionDomain.AckReplyAuthor(createReplyCmd.replyId, "some notify message") //de aici se poate extrage replyAuthodId
                       select new { createReplyResult, questionOwnerAckResult, replyAuthorAckResult }; //evenimentele returnate de workflow
            var ctx = new QuestionReadContext(new List<Post>());
            var r = await _interpreter.Interpret(expr, ctx);

            await _dbContext.SaveChangesAsync();

            return r.createReplyResult.Match(
                Created => (IActionResult)OK(new Object()),
                NotCreated => BadRequest(new Object())
                );

                       
        }
    }
}
