namespace ElevatorExercise.Logic
{
    public class OpenedDoor : DoorState
    {
        public bool IsClosed() => false;

        public bool IsClosing() => false;

        public bool IsOpened() => true;

        public bool IsOpening() => false;
    }
}