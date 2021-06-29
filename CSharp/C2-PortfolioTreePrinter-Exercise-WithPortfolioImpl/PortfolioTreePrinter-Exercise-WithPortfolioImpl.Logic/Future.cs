using System;
using System.Threading;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class Future<T>
    {
        private readonly Thread _thread;
        private T _result;

        public Future(Func<T> callback)
        {
            _thread = new Thread(() => _result = callback());
            _thread.Start();
        }

        public T Value()
        {
            _thread.Join();
            return _result;
        }
    }
}