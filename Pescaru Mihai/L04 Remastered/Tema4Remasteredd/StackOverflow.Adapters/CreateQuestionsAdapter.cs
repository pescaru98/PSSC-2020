using Primitives.IO;
using StackOverflow.Domain.Schema.Questions.CreateQuestionsOp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackOverflow.Domain.Schema.Questions.CreateQuestionsOp.CreateQuestionsResult;

namespace StackOverflow.Adapters
{
    class CreateQuestionsAdapter : Adapter<CreateQuestionsCmd, ICreateQuestionsResult>
    {
        public override Task PostConditions(CreateQuestionsCmd cmd, ICreateQuestionsResult result, object state)
        {
            throw new NotImplementedException();
        }

        public override async Task<ICreateQuestionsResult> Work(CreateQuestionsCmd cmd, object state)
        {
            //TODO Create Questions logic
            ICreateQuestionsResult create;
            //create.Match();
            return new QuestionsCreated(Guid.Empty, "Title", "Body");
        }
    }
}
