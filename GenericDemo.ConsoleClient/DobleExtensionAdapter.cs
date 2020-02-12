using System;
using System.Collections.Generic;
using System.Text;
using GenericsDemo.Interfaces;
using DoubleManipulation;

namespace GenericDemo.ConsoleClient
{
    public class DobleExtensionAdapter : ITransformer<double, string>
    {
        public string Transform(double value)
        {
            return DoubleExtension.TransformToIEEE754(value);
        }
    }
}
