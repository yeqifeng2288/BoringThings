using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeCircular
{
    public class CircularServiceCollection : ICircularServiceCollection
    {
        private readonly IServiceCollection _serviceDescriptors;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="serviceDescriptors">注入容器。</param>
        public CircularServiceCollection(IServiceCollection serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }

        public ICircularServiceCollection AddScoped<Target>() where Target : class
        {
            _serviceDescriptors.AddScoped<Target>();
            _serviceDescriptors.AddScoped(ImplementationAction<Target>(ServiceLifetime.Scoped));
            return this;
        }

        public ICircularServiceCollection AddScoped<Target, TImplementation>()
            where Target : class
            where TImplementation : class, Target
        {
            _serviceDescriptors.AddScoped<Target, TImplementation>();
            _serviceDescriptors.AddScoped(ImplementationAction<Target>(ServiceLifetime.Scoped));
            return this;
        }

        public ICircularServiceCollection AddSingleton<Target>() where Target : class
        {
            _serviceDescriptors.AddSingleton<Target>();
            _serviceDescriptors.AddSingleton(ImplementationAction<Target>(ServiceLifetime.Singleton));
            return this;
        }

        public ICircularServiceCollection AddTransient<Target>() where Target : class
        {
            _serviceDescriptors.AddTransient<Target>();
            _serviceDescriptors.AddTransient(ImplementationAction<Target>(ServiceLifetime.Transient));
            return this;
        }

        public IServiceCollection Completed()
        {
            return _serviceDescriptors;
        }

        private Func<IServiceProvider, ICircular<Target>> ImplementationAction<Target>(ServiceLifetime lifetime) where Target : class
        {
            return (serviceProvider) =>
            {
                return new Circular<Target>(new Lazy<Target>(() => serviceProvider.GetService<Target>()), lifetime);
            };
        }
    }
}
