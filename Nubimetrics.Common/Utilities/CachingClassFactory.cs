using System;
using System.Collections.Generic;
using System.Threading;

namespace Nubimetrics.Common.Utilities
{
    public static class CachingClassFactory
    {
        private static readonly ReaderWriterLockSlim _Lock = new ReaderWriterLockSlim();

        private static readonly Dictionary<Type, object> _InstantiatedClasses = new Dictionary<Type, object>();

        /// <summary>
        /// Return or create a new instance
        /// </summary>
        /// <typeparam name="T"> T must be a class</typeparam>
        public static T GetOrCreate<T>() where T : class
        {
            T result;

            Type key = typeof(T);
            object instantiatedClass;

            /// If there is no value with the specified key
            /// a new instance is created and added to the dictionary
            if (!_InstantiatedClasses.TryGetValue(key, out instantiatedClass))
            {
                result = Activator.CreateInstance<T>();
                _InstantiatedClasses.Add(key, result);
            }
            /// If the value exists the instance is returned
            else
            {
                result = (T)instantiatedClass;
            }

            return result;
        }
    }
}
