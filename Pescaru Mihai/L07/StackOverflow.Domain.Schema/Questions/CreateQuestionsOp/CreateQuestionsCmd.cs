using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackOverflow.Domain.Schema.Questions.CreateQuestionsOp
{
    public class CreateQuestionsCmd
    {
        //should be privat ctor
        public CreateQuestionsCmd(string title, Body body, string[] tags)
        {
            Title = title;
            Body = body;
            Tags = tags;
        }
        //should be privat ctor
        public CreateQuestionsCmd(global::System.String title, Body body, global::System.String[] tags, global::System.Int32 voteNumber)
        {
            Title = title;
            Body = body;
            Tags = tags;
            VoteNumber = voteNumber;
        }

        [MaxLength(50)]
        [Required]
        public string Title { get; }
        [MaxLength(1000)]
        [Required]
        public Body Body { get; }
        [Required]
        public string[] Tags { get; }
        public int VoteNumber { get; }
    }
}
