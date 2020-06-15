using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeCircular
{
    /// <summary>
    /// 循环引用的服务容器。
    /// </summary>
    public interface ICircularServiceCollection
    {
        /// <summary>
        /// 添加单例。
        /// </summary>
        /// <returns></returns>
        ICircularServiceCollection AddTransient<Target>() where Target : class;


        /// <summary>
        /// 添加Scoped。
        /// </summary>
        /// <returns></returns>
        ICircularServiceCollection AddScoped<Target>() where Target : class;

        /// <summary>
        /// 添加Scoped、
        /// </summary>
        /// <typeparam name="Target">目标。</typeparam>
        /// <typeparam name="TImplementation">实例。</typeparam>
        /// <returns></returns>
        ICircularServiceCollection AddScoped<Target, TImplementation>() where Target : class where TImplementation : class, Target;

        /// <summary>
        /// 添加单例。
        /// </summary>
        /// <returns></returns>
        ICircularServiceCollection AddSingleton<Target>() where Target : class;

        /// <summary>
        /// 完成。
        /// </summary>
        /// <returns></returns>
        IServiceCollection Completed();
    }
}
