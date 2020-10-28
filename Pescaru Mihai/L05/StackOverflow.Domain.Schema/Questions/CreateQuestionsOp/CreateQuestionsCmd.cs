using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackOverflow.Domain.Schema.Questions.CreateQuestionsOp
{
    public class CreateQuestionsCmd
    {

        public CreateQuestionsCmd(string title, string body, string tags)
        {
            Title = title;
            Body = body;
            Tags = tags;
        }

        [MaxLength(50)]
        [Required]
        public string Title { get; }
        [MaxLength(2000)]
        [Required]
        public string Body { get; }
        public string Tags { get; }
    }
}
