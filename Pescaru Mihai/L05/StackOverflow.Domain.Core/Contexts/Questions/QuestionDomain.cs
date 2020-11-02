using static StackOverflow.Domain.Schema.Questions.CreateQuestionsOp.CreateQuestionsResult;
using StackOverflow.Domain.Schema.Questions.CreateQuestionsOp;
using Primitives.IO;
using System;
using static PortExt;

namespace StackOverflow.Domain.Core.Contexts.Questions
{
    public static class QuestionDomain
    {
        public static Port<ICreateQuestionsResult> CreateQuestions( string title, Body body, string[] tags ) =>
            NewPort<CreateQuestionsCmd, ICreateQuestionsResult>(new CreateQuestionsCmd(title,body,tags));
       
    }
}
 