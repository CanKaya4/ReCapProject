using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //default : dataya karşılık gelir.
        //4 farklı versiyonunu yazdık.

        //Data ve mesaj içeren versiton
        public SuccessDataResult(T data, string message):base(data,message,true)
        {

        }
        //Sadece data
        public SuccessDataResult(T data):base(data,true)
        {

        }
        //sadece mesaj ver
        public SuccessDataResult(string message):base(default,message,true)
        {

        }
        //hiç birşey de vermeyebilirsin.
        public SuccessDataResult():base(default,true)
        {

        }
    }
}
