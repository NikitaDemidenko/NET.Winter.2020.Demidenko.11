using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsDemo.Interfaces
{
    public interface ITransformer<in TSource, out TResult>
    {
        TResult Transform(TSource value);
    }
}
