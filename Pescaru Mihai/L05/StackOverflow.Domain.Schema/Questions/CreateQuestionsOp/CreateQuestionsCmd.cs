using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackOverflow.Domain.Schema.Questions.CreateQuestionsOp
{
    public class CreateQuestionsCmd
    {

        public CreateQuestionsCmd(string title, Body body, string[] tags)
        {
            Title = title;
            Body = body;
            Tags = tags;
        }

        [MaxLength(50)]
        [Required]
        public string Title { get; }
        [MaxLength(1000)]
        [Required]
        public Body Body { get; }
        [Required]
        
        public string[] Tags { get; }
    }
}
