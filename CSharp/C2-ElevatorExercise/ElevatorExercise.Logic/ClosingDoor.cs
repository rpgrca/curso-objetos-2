namespace ElevatorExercise.Logic
{
    public class ClosingDoor : DoorState
    {
        private readonly Door _door;

        public ClosingDoor(Door door) => _door = door;

        public bool IsClosed() => false;

        public bool IsClosing() => true;

        public bool IsOpened() => false;

        public bool IsOpening() => false;

        public void OnClosed() => _door.CloseDoorWhenClosing();

        public void Open() => _door.OpenWhenClosing();
    }
}