using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using LanguageExt.Common;

namespace StackOverflow.Domain.Schema.Questions.CreateQuestionsOp
{
    public class InvalidBodyException : Exception
    {
        public InvalidBodyException(string value) : base($"Invalid body: {value}"){ }
    }
     
    public struct Body
    {
        private Body(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<Body> Create(string value)
        {
            if (value != "" && value.Length <= 1000)
                return new Body(value);
            else return new Result<Body>(new InvalidBodyException(value));
        }
    }
}
