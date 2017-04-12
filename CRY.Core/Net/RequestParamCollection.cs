using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRY.Core.Net
{
    public class RequestParam{
        public string Key { get;  set; }
        public string Value { get;  set; }
    }
    public class RequestParamCollection : ICollection, IEnumerable, IEnumerator<RequestParam>
    {
        private object _syncRoot = new object();
        internal IList<RequestParam> Value { get; private set; }
        public RequestParam this[int index] {
            get
            {
                if (index < 0 || Count < index +1)
                {
                    throw new ArgumentException();
                }
                return Value.ElementAt(index);
            }
        }
        public RequestParam this[string name] {
            get
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentNullException();
                }
                return Value.FirstOrDefault(_=>_.Key == name);
            }
        }

        public void Empty()
        {
            Value.Clear();
        }

        public void Add(RequestParam param)
        {
            if (param == null || string.IsNullOrEmpty(param.Key))
            {
                throw new ArgumentNullException();
            }

            if (Value == null)
            {
                Value = new List<RequestParam>();
            }
            var paramOld = this[param.Key];
            if (paramOld == null) {
                Value.Add(param);
            }else
            {
                paramOld.Value = param.Value;
            }
        }

        public int Count
        {
            get
            {
                return Value.Count();
            }
        }

        public object SyncRoot
        {
            get
            {
                return _syncRoot;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public RequestParam Current
        {
            get
            {
                return Value[position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void CopyTo(Array array, int index)
        {
            Value.CopyTo((RequestParam[])array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return Value.GetEnumerator();
        }
        void IDisposable.Dispose() { }

        int position = -1;
        public bool MoveNext()
        {
            position++;
            return (position < Count);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
