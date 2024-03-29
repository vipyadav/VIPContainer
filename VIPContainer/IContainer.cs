﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIPContainer
{
    public interface IContainer : IDisposable
    {
        void Register<TPluginType, TConcreteType>() where TPluginType : class where TConcreteType : class;
        T Resolve<T>();
        object Resolve(Type fromType);
    }
}
