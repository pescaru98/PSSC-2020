using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharp.Choices;

namespace Profile.Domain.CreateProfileWorkflow
{
    [AsChoice]
    public static partial class CreateProfileResult
    {
        public interface ICreateProfileResult { }

        public class ProfileCreated: ICreateProfileResult
        {
            public Guid QuestionId { get; private set; }
            public string Title { get; private set; }
            public string Body { get; private set; }

            public ProfileCreated(Guid questionId, string title,string body)
            {
                QuestionId = questionId;
                Title = title;
                Body = body;
            }
        }

        public class ProfileNotCreated: ICreateProfileResult
        {
            public string Reason { get; set; }

            public ProfileNotCreated(string reason)
            {
                Reason = reason;
            }
        }

        public class ProfileValidationFailed: ICreateProfileResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public ProfileValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
