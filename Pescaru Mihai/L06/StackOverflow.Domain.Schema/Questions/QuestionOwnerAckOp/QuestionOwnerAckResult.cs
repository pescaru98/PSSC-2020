using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Domain.Schema.Questions.QuestionOwnerAckOp
{
    [AsChoice]
    public static partial class QuestionOwnerAckResult
    {
        public interface IQuestionOwnerAckResult { }

        public class AckSent : IQuestionOwnerAckResult
        {
            public AckSent(global::System.String message, global::System.Int32 questionId)
            {
                Message = message;
                QuestionId = questionId;
            }

            public string Message { get; }
            public int QuestionId { get;  }
        }

        public class AckNotSent : IQuestionOwnerAckResult
        {
            public AckNotSent(global::System.String errorMessage)
            {
                ErrorMessage = errorMessage;
            }

            public string ErrorMessage { get; }
        }
    }
}
