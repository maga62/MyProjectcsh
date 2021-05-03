using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        //overloding iki farklı metod varmış gibi constructor 
        public Result(bool success, string message):this(success)
        {
            //konstructor yapı Result mesaj dödürme 
            Message = message;

        }
        public Result(bool success)
        {
            //konstructor yapı Result basarılı dödürme 
            Success=success;

        }

        public bool Success { get; }

        public string Message { get; }
    }
}
