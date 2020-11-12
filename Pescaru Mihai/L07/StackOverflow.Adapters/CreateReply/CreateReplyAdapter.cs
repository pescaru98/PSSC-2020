using LanguageExt;
using Primitives.IO;
using StackOverflow.Domain.Schema.Questions.CreateReplyOp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackOverflow.Domain.Schema.Questions.CreateReplyOp.CreateReplyResult;

namespace StackOverflow.Adapters.CreateReply
{
    class CreateReplyAdapter : Adapter<CreateReplyCmd, ICreateReplyResult, QuestionReadContext>
    {
        public override Task PostConditions(CreateReplyCmd cmd, ICreateReplyResult result, QuestionReadContext state)
        {
            throw new NotImplementedException();
        }

        public async override Task<ICreateReplyResult> Work(CreateReplyCmd cmd, QuestionReadContext state)
        {
            var result = from validate in cmd.TryValidate()
                         select validate;
            return await result.Match<ICreateReplyResult>(
                SuccCase: valid => new ReplyCreated(1, cmd.QuestionId, cmd.Body),
                FailCase: ex => new ReplyNotCreated("Didn't work"));
        }
    }
}
