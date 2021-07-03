namespace ElevatorExercise
{
    public class ClosedDoor : DoorState
    {
        public bool IsClosed() => true;

        public bool IsClosing() => false;

        public bool IsOpened() => false;

        public bool IsOpening() => false;
    }
}
