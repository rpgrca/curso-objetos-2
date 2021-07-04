namespace ElevatorExercise.Logic
{
    public class ClosingDoor : DoorState
    {
        public bool IsClosed() => false;

        public bool IsClosing() => true;

        public bool IsOpened() => false;

        public bool IsOpening() => false;
    }
}