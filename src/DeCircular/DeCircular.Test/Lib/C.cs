using System;
using System.Collections.Generic;
using System.Text;

namespace DeCircular.Test.Lib
{
    internal class C : BaseClass
    {
        private readonly ICircular<BaseClass> _baseClass;

        public C(ICircular<BaseClass> baseClass)
        {
            _baseClass = baseClass;
        }

        public BaseClass BaseClass { get => _baseClass.Instance; }
    }
}
