using StackOverflow.Domain.Schema.Questions.CreateQuestionsOp;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Domain.Schema.Questions.LanguageCheckOp
{

    public class LanguageCheckCmd
    {
        //should be privat ctor
        //maybe (not sure) should be added as attributes: replyId and questionId (so the languagecmd operation can output them for 
        //question owner and reply author operations <- questionownerackop needs the questionId and replyauthorackop needs the replyid)
        public LanguageCheckCmd(global::System.String body)
        {
            Body = body;
        }

        [Required]
        [MaxLength(1000)]
        public string Body { get; }

        public static Result<LanguageCheckCmd> Create(string body)
        {
            if (body != "" && body.Length <= 1000)
                return new LanguageCheckCmd(body);
            else
                return new Result<LanguageCheckCmd>(new InvalidArgumentException("Invalid body"));
        }
    }
}
