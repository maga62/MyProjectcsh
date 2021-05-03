using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
            //data ve mesacı aynı anda ver

        }

        public ErrorDataResult(T data) : base(data, false)
        {
            //ister data ver message verme

        }
        public ErrorDataResult(string message) : base(default, false, message)
        {
            // ister mesage ver data verme 
        }
        public ErrorDataResult() : base(default, false)
        {
            //yada hiç bir şey verme 
        }
    }
}
