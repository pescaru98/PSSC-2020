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
            public QuestionsCreated(Guid questionId, Guid userId, string title, Body body)
            {
                QuestionId = questionId;
                UserId = userId;
                Title = title;
                Body = body;
            }

            public Guid QuestionId { get; }
            public Guid UserId { get; }
            public string Title { get; }
            public Body Body { get; }
        }

        public class QuestionsNotCreated : ICreateQuestionsResult
        {

        }

        public class InvalidRequest : ICreateQuestionsResult
        {

        }

    }


}
