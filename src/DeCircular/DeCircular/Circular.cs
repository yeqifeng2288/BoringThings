using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DeCircular
{
    public class Circular<Target> : ICircular<Target> where Target : class
    {
        private readonly Lazy<Target> _implemente;

        public Circular(Lazy<Target> target, ServiceLifetime lifetime)
        {
            _implemente = target;
            Lifetime = lifetime;
        }

        public Target Instance => _implemente.Value;

        public ServiceLifetime Lifetime { get; }
    }
}
