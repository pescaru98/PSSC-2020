using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Domain.Schema.Questions.LanguageCheckOp
{
    [AsChoice]
    public static partial class LanguageCheckResult
    {
        public interface ILanguageCheckResult { }

        public class LanguageValidated : ILanguageCheckResult
        {
            public LanguageValidated(global::System.String body)
            {
                Body = body;
            }

            public string Body { get; }
        }

        public class LanguageInvalidated : ILanguageCheckResult
        {
            public LanguageInvalidated(global::System.String message)
            {
                Message = message;
            }

            public string Message { get; }
        }

        public class ManualReview : ILanguageCheckResult
        {
            public ManualReview(global::System.String body)
            {
                Body = body;
            }

            public string Body { get; }
        }
    }
}
