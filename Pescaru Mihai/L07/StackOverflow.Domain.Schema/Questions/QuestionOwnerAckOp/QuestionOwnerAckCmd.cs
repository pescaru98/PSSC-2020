using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Domain.Schema.Questions.QuestionOwnerAckOp
{
    public class QuestionOwnerAckCmd
    {
        //should be privat ctor
        public QuestionOwnerAckCmd(global::System.Int32 questionId, global::System.String message)
        {
            QuestionId = questionId;
            Message = message;
        }

        //Considering question ID, we can get the USER_ID of the question owner
        [Required]
        public int QuestionId { get; }
        [Required]
        [MaxLength(100)]
        public string Message { get; }

        public static Result<QuestionOwnerAckCmd> Create(int questionId, string message)
        {
            if (questionId > 0 && message != "" && message <= 100)
                return new QuestionOwnerAckCmd(questionId, message);
            else
                return new Result<QuestionOwnerAckCmd>(new InvalidArgumentException("Invalid questionId or message"));
        }
    }
}
