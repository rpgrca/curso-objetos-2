using System;
using System.Collections.Generic;

namespace ElevatorConsole_Exercise.Logic
{
    public class ActiveVariable<T>
    {
        private readonly List<Observer<T>> _observers = new();
        public T State { get; private set; }

        public void AddObserver(Observer<T> observer) =>
            _observers.Add(observer);

        public void Set(T newState)
        {
            State = newState;
            _observers.ForEach(p =>
            {
                try
                {
                    p.Changed(State);
                }
                catch (Exception)
                {
                    // TODO: handle exception
                }
            });
        }
    }
}