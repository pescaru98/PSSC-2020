using static StackOverflow.Domain.Schema.Questions.CreateQuestionsOp.CreateQuestionsResult;
using StackOverflow.Domain.Schema.Questions.CreateQuestionsOp;
using Primitives.IO;
using System;
using static PortExt;
using static StackOverflow.Domain.Schema.Questions.CreateReplyOp.CreateReplyResult;
using StackOverflow.Domain.Schema.Questions.CreateReplyOp;
using static StackOverflow.Domain.Schema.Questions.LanguageCheckOp.LanguageCheckResult;
using StackOverflow.Domain.Schema.Questions.LanguageCheckOp;
using static StackOverflow.Domain.Schema.Questions.QuestionOwnerAckOp.QuestionOwnerAckResult;
using StackOverflow.Domain.Schema.Questions.QuestionOwnerAckOp;
using static StackOverflow.Domain.Schema.Questions.ReplyAuthorAckOp.ReplyAuthorAckResult;
using StackOverflow.Domain.Schema.Questions.ReplyAuthorAckOp;

namespace StackOverflow.Domain.Core.Contexts.Questions
{
    public static class QuestionDomain
    {
        public static Port<ICreateQuestionsResult> CreateQuestions(string title, Body body, string[] tags) =>
            NewPort<CreateQuestionsCmd, ICreateQuestionsResult>(new CreateQuestionsCmd(title, body, tags));

        public static Port<ICreateReplyResult> CreateReply(int questionId, string body) =>
            NewPort<CreateReplyCmd, ICreateReplyResult>(new CreateReplyCmd(questionId, body));

        public static Port<ILanguageCheckResult> CheckLanguage(string body) =>
            NewPort<LanguageCheckCmd, ILanguageCheckResult>(new LanguageCheckCmd(body));

        public static Port<IQuestionOwnerAckResult> AckQuestionOwner(int questionId, string message) =>
             NewPort<QuestionOwnerAckCmd, IQuestionOwnerAckResult>(new QuestionOwnerAckCmd(questionId,message));

        public static Port<IReplyAuthorAckResult> AckReplyAuthor(int replyId, string message) =>
             NewPort<ReplyAuthorAckCmd, IReplyAuthorAckResult>(new ReplyAuthorAckCmd(replyId,message));
    }
}
  