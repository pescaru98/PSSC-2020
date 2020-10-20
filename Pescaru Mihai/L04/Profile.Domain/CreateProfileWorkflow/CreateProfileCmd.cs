using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Profile.Domain.CreateProfileWorkflow
{
    public struct CreateProfileCmd
    {
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string Tags { get; private set; }


        public CreateProfileCmd(string title, string body, string tags)
        {
            Title = title;
            Body = body;
            Tags = tags;
        }
    }
}
