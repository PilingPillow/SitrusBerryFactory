using System.Collections.Generic;
using System.Dynamic;

namespace SitrusBerryFactory._utilities
{
    /// <summary>
    /// Enables dot notation access.
    /// </summary>
    public abstract class DynamicAccessor<T> : DynamicObject
    {
        protected Dictionary<string, T> _values = null;

        protected DynamicAccessor()
        {
            _values = new Dictionary<string, T>();
        }

        public virtual void Register(string key, T value)
        {
            _values[key] = value;
        }

        public virtual void ClearDict()
        {
            _values.Clear();
        }

        /// <summary>
        /// Returns this instance as a dynamic object.
        /// </summary>
        public dynamic AsDynamic() => this;

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _values.TryGetValue(binder.Name, out T value)
                ? value
                : default(T);
            return true;
        }
    }
}
