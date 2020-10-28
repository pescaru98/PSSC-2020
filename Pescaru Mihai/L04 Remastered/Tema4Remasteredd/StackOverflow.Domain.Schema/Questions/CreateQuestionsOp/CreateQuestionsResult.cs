using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackOverflow.Domain.Schema.Questions.CreateQuestionsOp
{
    [AsChoice]
    public static partial class CreateQuestionsResult
    {

        public interface ICreateQuestionsResult { }

        public class QuestionsCreated : ICreateQuestionsResult
        {
            public QuestionsCreated(Guid userId, string title, string body)
            {
                UserId = userId;
                Title = title;
                Body = body;
            }

            public Guid UserId { get; }
            public string Title { get; }
            public string Body { get; }
        }

        public class QuestionsNotCreated : ICreateQuestionsResult
        {

        }

        public class InvalidRequest : ICreateQuestionsResult
        {

        }

    }


}
