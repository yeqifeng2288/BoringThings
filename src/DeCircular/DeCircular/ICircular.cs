using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DeCircular
{
    /// <summary>
    /// 循环引用的接口。
    /// </summary>
    /// <typeparam name="TClass">会循环引用的类型。</typeparam>
    public interface ICircular<Target> where Target : class
    {
        /// <summary>
        /// 实例。
        /// </summary>
        public Target Instance { get; }

        /// <summary>
        /// 生命周期类型。
        /// </summary>
        public ServiceLifetime Lifetime { get; }
    }
}
