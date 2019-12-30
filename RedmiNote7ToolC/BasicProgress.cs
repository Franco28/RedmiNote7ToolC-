using System;

namespace RedmiNote7ToolC
{
    class BasicProgress<T> : IProgress<T>
    {
        private readonly Action<T> _handler;

        public BasicProgress(Action<T> handler)
        {
            _handler = handler;
        }

        void IProgress<T>.Report(T value)
        {
            _handler(value);
        }
    }
}
