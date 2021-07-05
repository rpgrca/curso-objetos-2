namespace ElevatorExercise.Logic
{
    public class OpenedDoor : DoorState
    {
        private readonly Door _door;

        public OpenedDoor(Door door) => _door = door;

        public bool IsClosed() => false;

        public bool IsClosing() => false;

        public bool IsOpened() => true;

        public bool IsOpening() => false;

        public void OnClosed() => _door.ClosedDoorWhenOpened();

        public void Open() => _door.OpenWhenAlreadyOpened();

        public void Close() => _door.CloseWhenOpened();
    }
}