using System;
using System.Collections.Generic;
using System.Text;

namespace DeCircular.Test.Lib
{
    internal class A : BaseClass
    {
        private readonly ICircular<B> _b;

        public A(ICircular<B> b)
        {
            _b = b;
        }

        public B B { get => _b.Instance; }
    }
}
