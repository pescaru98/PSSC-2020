using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Domain.Schema.Questions.CreateReplyOp
{

    public class InvalidReplyBodyException : Exception
    {
        public InvalidReplyBodyException(string body):base($"Body {body} is invalid") { }
    }


    public class CreateReplyCmd
    {
        //should be privat ctor
        public CreateReplyCmd(global::System.Int32 questionId, global::System.Int32 body)
        {
            QuestionId = questionId;
            Body = body;
        }

        [Required]
        public int QuestionId { get; }
        [MaxLength(1000)]
        [Required]
        public string Body { get; }

        public static Result<CreateReplyCmd> Create(int questionId, string body)
        {
            if (body != "" && body.Length <= 1000)
                return new CreateReplyCmd(questionId, body);
            else
                return new Result<CreateReplyCmd>(new InvalidReplyBodyException(body));
        }
    }
}
