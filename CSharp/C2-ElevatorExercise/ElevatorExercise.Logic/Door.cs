using System;

namespace ElevatorExercise.Logic
{
    public class Door
    {
        private readonly Cabin _cabin;
        private DoorState _state;

        public Door(Cabin cabin)
        {
            _cabin = cabin;
            _state = new OpenedDoor(this);
        }

        public bool IsOpened() => _state.IsOpened();

        public bool IsOpening() => _state.IsOpening();

        public bool IsClosed() => _state.IsClosed();

        public bool IsClosing() => _state.IsClosing();

        public void Close() => _state = new ClosingDoor(this);

        public void Open() => _state.Open();

        public void OnClosed() => _state = new ClosedDoor(this);

        public void OnOpened() => _state = new OpenedDoor(this);

        internal void OpenWhenOpening()
        {
            // door is opening, do nothing 
        }

        internal void OpenWhenAlreadyOpened()
        {
            // door is already opened, do nothing
        }

        internal void OpenWhenClosing() => _state = new OpeningDoor(this);

        internal void OpenWhenAlreadyClosed() => _state = new OpeningDoor(this);
    }
}