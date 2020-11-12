using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Domain.Schema.Questions.ReplyAuthorAckOp
{
    public class ReplyAuthorAckCmd
    {

        //should be private ctor
        public ReplyAuthorAckCmd(global::System.Int32 replyId, global::System.Int32 message)
        {
            ReplyId = replyId;
            Message = message;
        }

        //we can get the user_id of reply author by ReplyId
        [Required]
        public int ReplyId { get; }
        [Required]
        [MaxLength(50)]
        public int Message { get; }

        public static Result<ReplyAuthorAckCmd> Create(int replyId, int message)
        {
            if (replyId > 0 && message != "" && message.Length <= 50)
                return new ReplyAuthorAckCmd(replyId, message);
            else
                return new Result<ReplyAuthorAckCmd>(new InvalidArgumentException("ReplyId or message invalid"));
        }
    }
}
