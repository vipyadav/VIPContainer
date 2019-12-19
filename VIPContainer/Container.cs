using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIPContainer
{
    public class Container : IContainer
    {
        private Dictionary<Type, object> _store;
        private Dictionary<Type, Type> typeDict;

        /// <summary>
        /// Default constructor; instantiates a new ServiceResolver object.
        /// </summary>
        public Container()
        {
            this.DependencyInjector = new DependencyInjector(this);
            _store = new Dictionary<Type, object>();
            typeDict = new Dictionary<Type, Type>();
        }

        /// <summary>
        /// Creates a new ServiceResolver with a given IDependencyInjector.
        /// </summary>
        /// <param name="injector">The IDependencyInjector to use for dependency injection.</param>
        public Container(IDependencyInjector injector)
        {
            this.DependencyInjector = injector;
            _store = new Dictionary<Type, object>();
            typeDict = new Dictionary<Type, Type>();
        }

        /// <summary>
        /// Registers a pluginType with its corresponding concreteType.
        /// </summary>
        /// <typeparam name="TPluginType">The abstract type or interface to use as a key.</typeparam>
        /// <typeparam name="TConcreteType">The concrete type to use as a value.</typeparam>
        public void Register<TPluginType, TConcreteType>() where TPluginType : class where TConcreteType : class
        {
            typeDict.Add(typeof(TPluginType), typeof(TConcreteType));
        }


        /// <summary>
        /// Gets an implementation object of a registered abstract type or interface.
        /// </summary>
        /// <typeparam name="T">The registered abstract type or interface to look up.</typeparam>
        /// <returns>Returns an object of the given type.</returns>
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        /// <summary>
        /// Gets an implementation object of a registered abstract type or interface.
        /// </summary>
        /// <param name="fromType">The registered abstract type or interface to look up.</param>
        /// <returns>Returns an object of the given type.</returns>
        public object Resolve(Type fromType)
        {
            // check for registration
            if (!typeDict.ContainsKey(fromType))
                return DependencyInjector.GetInjectedInstance(fromType);

            // get destination type
            Type dest = typeDict[fromType];

            // check for already requested object
            if (_store.ContainsKey(dest))
                return _store[dest];

            // create a new instance of this type
            object obj = DependencyInjector.GetInjectedInstance(dest);

            // add to store for future use
            _store.Add(dest, obj);

            return obj;
        }

        /// <summary>
        /// Gets or sets a dependency injector to use for types that need injection.
        /// </summary>
        public IDependencyInjector DependencyInjector { get; set; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~VIPContainer()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
