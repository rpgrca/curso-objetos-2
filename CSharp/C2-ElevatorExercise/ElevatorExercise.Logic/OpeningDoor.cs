namespace ElevatorExercise.Logic
{
    public class OpeningDoor : DoorState
    {
        private readonly Door _door;

        public OpeningDoor(Door door) => _door = door;

        public bool IsClosed() => false;

        public bool IsClosing() => false;

        public bool IsOpened() => false;

        public bool IsOpening() => true;

        public void OnClosed() => _door.ClosedDoorWhenOpening();

        public void Open() => _door.OpenWhenOpening();

        public void Close()
        {
            // undefined
        }
    }
}