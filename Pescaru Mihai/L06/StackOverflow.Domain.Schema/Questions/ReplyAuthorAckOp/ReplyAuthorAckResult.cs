using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Domain.Schema.Questions.ReplyAuthorAckOp
{
    [AsChoice]
    public static partial class ReplyAuthorAckResult
    {
        public interface IReplyAuthorAckResult { }

        public class ReplyAckSent : IReplyAuthorAckResult
        {
            public ReplyAckSent(global::System.Int32 replyId, global::System.String message)
            {
                ReplyId = replyId;
                Message = message;
            }

            public int ReplyId { get; }
            public string Message { get; }
        }

        public class ReplyAckNotSent : IReplyAuthorAckResult
        {
            public ReplyAckNotSent(global::System.String errorMessage)
            {
                ErrorMessage = errorMessage;
            }

            public string ErrorMessage { get; }
        }
    }
}
