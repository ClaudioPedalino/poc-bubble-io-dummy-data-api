using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Products.api.Models
{
    public class Result
    {
        public Result()
        {
            HasErrors = false;
            Messages = new List<string>();
        }

        public bool HasErrors { get; set; }
        public IList<string> Messages { get; set; }

        public static Result Success(string message)
            => new Result() { HasErrors = false, Messages = new List<string>() { message } };

        public static Result Fail(string message)
            => new Result() { HasErrors = true, Messages = new List<string>() { message } };

        public static Result NotFound(string message)
            => new Result() { HasErrors = true, Messages = new List<string>() { message } };
    }
}