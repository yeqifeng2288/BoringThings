using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeCircular.Extension
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 重复引用选项。
        /// </summary>
        public static ICircularServiceCollection AddCircularOptions(this IServiceCollection serviceDescriptors)
        {
            return new CircularServiceCollection(serviceDescriptors);
        }
    }
}
