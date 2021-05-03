using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base (data,true,message)
        {
            //data ve mesacı aynı anda ver

        }

        public SuccessDataResult(T data):base(data,true)
        {
            //ister data ver message verme

        }
        public SuccessDataResult(string message):base(default,true,message)
        {
            // ister mesage ver data verme 
        }
        public SuccessDataResult():base(default,true)
        {
            //yada hiç bir şey verme 
        }
    }
}
