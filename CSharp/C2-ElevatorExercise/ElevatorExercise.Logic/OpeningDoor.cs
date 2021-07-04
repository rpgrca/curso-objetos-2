namespace ElevatorExercise.Logic
{
    public class OpeningDoor : DoorState
    {
        public bool IsClosed() => false;

        public bool IsClosing() => false;

        public bool IsOpened() => false;

        public bool IsOpening() => true;
    }
}