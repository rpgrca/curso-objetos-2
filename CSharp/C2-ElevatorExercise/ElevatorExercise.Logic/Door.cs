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

        public void Close() => _state.Close();

        public void Open() => _state.Open();

        public void OnClosed() => _state.OnClosed();

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

        internal void DoorClosedWhenAlreadyClosed() => ThrowOutOfSyncException();

        private static void ThrowOutOfSyncException() => throw new ElevatorEmergency("Sensor de puerta desincronizado");

        internal void DoorClosedWhenClosing() => _state = new ClosedDoor(this);

        internal void ClosedDoorWhenOpened() => ThrowOutOfSyncException();

        internal void ClosedDoorWhenOpening() => ThrowOutOfSyncException();

        internal void CloseWhenOpened() => _state = new ClosingDoor(this);
    }
}