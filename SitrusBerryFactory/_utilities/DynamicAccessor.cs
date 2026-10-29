using System.Collections.Generic;
using System.Dynamic;

namespace SitrusBerryFactory._utilities
{
    /// <summary>
    /// Enables dot notation access.
    /// </summary>
    public abstract class DynamicAccessor<T> : DynamicObject
    {
        protected readonly Dictionary<string, T> _values = null;

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
        /// Returns a dynamic proxy for this instance.
        /// </summary>
        public dynamic AsDynamic()
        {
            return new DynamicProxy(this);
        }

        private sealed class DynamicProxy : DynamicObject
        {
            private readonly DynamicAccessor<T> _owner;

            public DynamicProxy(DynamicAccessor<T> owner)
            {
                _owner = owner;
            }

            public override bool TryGetMember(
                GetMemberBinder binder,
                out object result)
            {
                result = _owner._values.TryGetValue(
                    binder.Name, out T value)
                    ? value
                    : default(T);

                return true;
            }

            public override bool TrySetMember(
                SetMemberBinder binder,
                object value)
            {
                _owner._values[binder.Name] =
                    value is T typedValue
                        ? typedValue
                        : default(T);

                return true;
            }

            public override bool TryGetIndex(
                GetIndexBinder binder,
                object[] indexes,
                out object result)
            {
                if (indexes != null &&
                    indexes.Length == 1 &&
                    indexes[0] is string key)
                {
                    result = _owner._values.TryGetValue(
                        key, out T value)
                        ? value
                        : default(T);

                    return true;
                }

                result = default(T);
                return false;
            }

            public override bool TrySetIndex(
                SetIndexBinder binder,
                object[] indexes,
                object value)
            {
                if (indexes == null ||
                    indexes.Length != 1 ||
                    !(indexes[0] is string key))
                {
                    return false;
                }

                _owner._values[key] =
                    value is T typedValue
                        ? typedValue
                        : default(T);

                return true;
            }
        }
    }

    public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _values.TryGetValue(binder.Name, out T value)
                ? value
                : default(T);

            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _values[binder.Name] = value is T typedValue
                ? typedValue
                : default(T);

            return true;
        }

        public override bool TryGetIndex(
            GetIndexBinder binder,
            object[] indexes,
            out object result)
        {
            result = indexes[0] is string key && _values.TryGetValue(key, out T value)
                ? value
                : default(T);

            return true;
        }

        public override bool TrySetIndex(
            SetIndexBinder binder,
            object[] indexes,
            object value)
        {
            _values[(string)indexes[0]] = value is T typedValue
                ? typedValue
                : default(T);

            return true;
        }
    }
}
