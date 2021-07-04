namespace ElevatorExercise.Logic
{
    public class ClosedDoor : DoorState
    {
        private readonly Door _door;

        public ClosedDoor(Door door) => _door = door;

        public bool IsClosed() => true;

        public bool IsClosing() => false;

        public bool IsOpened() => false;

        public bool IsOpening() => false;

        public void Open() => _door.OpenWhenAlreadyClosed();
    }
}