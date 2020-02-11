using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsDemo.Interfaces
{
    public interface IComparer<in T>
    {
        int Compare(T lhs, T rhs);
    }
}
