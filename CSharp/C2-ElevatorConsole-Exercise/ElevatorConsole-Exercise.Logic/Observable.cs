using System.Collections.Generic;

namespace ElevatorConsole_Exercise.Logic
{
    public class Observable<TState, TVisitor>
        where TState : Visitor<TVisitor>
    {
        private readonly List<TVisitor> _observers = new();
        public TState State { get; private set; }

        public void AddObserver(TVisitor observer) =>
            _observers.Add(observer);

        public void ChangeStateTo(TState newState)
        {
            State = newState;
            _observers.ForEach(p => State.Accept(p));
        }
    }
}