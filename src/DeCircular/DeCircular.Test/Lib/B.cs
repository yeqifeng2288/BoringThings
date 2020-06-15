using System;
using System.Collections.Generic;
using System.Text;

namespace DeCircular.Test.Lib
{
    internal class B : BaseClass
    {
        private readonly ICircular<A> _a;

        public B(ICircular<A> a)
        {
            _a = a;
        }

        public A A { get => _a.Instance; }
    }
}
