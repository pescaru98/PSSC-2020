using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Domain.Schema.Questions.CreateReplyOp
{
    [AsChoice]
    public static partial class CreateReplyResult
    {
        public interface ICreateReplyResult { }

        public class ReplyCreated : ICreateReplyResult
        {
            public ReplyCreated(global::System.Int32 replyid, global::System.Int32 questionId, global::System.String body)
            {
                ReplyId = replyid;
                QuestionId = questionId;
                Body = body;
            }

            public int ReplyId { get; set; }
            public int QuestionId { get; set; }
            public string Body { get; set; }
        }

        public class ReplyNotCreated : ICreateReplyResult
        {
            public ReplyNotCreated(global::System.String message)
            {
                Message = message;
            }

            public string Message { get; }
        }

        public class InvalidRequest : ICreateReplyResult
        {
            public InvalidRequest(global::System.String message)
            {
                Message = message;
            }

            public string Message { get; }
        }

    }
}
