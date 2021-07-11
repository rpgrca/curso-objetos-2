using System;
using System.Collections.Generic;

namespace ElevatorConsole_Exercise.Logic
{
    public class ActiveVariable<TState>
    {
        private readonly List<Observer<TState>> _observers = new();
        public TState State { get; private set; }

        public void AddObserver(Observer<TState> observer) =>
            _observers.Add(observer);

        public void Set(TState newState)
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