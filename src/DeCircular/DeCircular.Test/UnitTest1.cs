using DeCircular.Extension;
using DeCircular.Test.Lib;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DeCircular.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test_AReferenceB_Should_B()
        {
            var serviceProvider = new ServiceCollection()
                .AddCircularOptions()
                .AddScoped<A>()
                .AddTransient<B>()
                .Completed().BuildServiceProvider();

            var a = serviceProvider.GetRequiredService<A>();
            var b = serviceProvider.GetRequiredService<ICircular<B>>();
            var c = serviceProvider.GetRequiredService<B>();

            Assert.Equal(ServiceLifetime.Transient, b.Lifetime);
            Assert.Equal("B", a.B.Name);
            Assert.Equal("A", c.A.Name);
        }

        [Fact]
        public void Test_CReferenceBaseClass_Should_B()
        {
            var serviceProvider = new ServiceCollection()//.AddScoped<BaseClass, C>()
                .AddCircularOptions()
                .AddScoped<BaseClass, C>()
                .Completed()
                .BuildServiceProvider();

            var a = serviceProvider.GetRequiredService<BaseClass>();
            Assert.Equal("C", a.Name);
        }
    }
}
