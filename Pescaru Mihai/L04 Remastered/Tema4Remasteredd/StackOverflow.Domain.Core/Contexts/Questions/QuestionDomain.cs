using Primitives.IO;
using static PortExt;
using static StackOverflow.Domain.Schema.Questions.CreateQuestionsOp.CreateQuestionsResult;
using StackOverflow.Domain.Schema.Questions.CreateQuestionsOp;

namespace StackOverflow.Domain.Core.Contexts.Questions
{
    public static class QuestionDomain
    {
        public static Port<ICreateQuestionsResult> CreateQuestions( string title, string body, string tags ) =>
            NewPort<CreateQuestionsCmd, ICreateQuestionsResult>(new CreateQuestionsCmd(title,body,tags));
       
    }
}
