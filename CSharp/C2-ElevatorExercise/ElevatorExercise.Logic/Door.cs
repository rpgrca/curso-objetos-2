namespace ElevatorExercise.Logic
{
    public class Door
    {
        private DoorState _state;

        public Door() => _state = new OpenedDoor();

        public bool IsOpened() => _state.IsOpened();

        public bool IsOpening() => _state.IsOpening();

        public bool IsClosed() => _state.IsClosed();

        public bool IsClosing() => _state.IsClosing();

        public void Close() => _state = new ClosingDoor();

        public void Open() => _state = new OpeningDoor();

        public void Closed() => _state = new ClosedDoor();

        public void Opened() => _state = new OpenedDoor();
    }
}