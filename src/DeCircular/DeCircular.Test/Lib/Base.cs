using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DeCircular.Test.Lib
{
    internal abstract class BaseClass
    {
        public BaseClass()
        {
            this.Name = this.GetType().Name;
        }

        public string Name { get; }

        public void ShowName() => Console.WriteLine(Name);
    }
}
