namespace ElevatorExercise
{
    public interface DoorState
    {
        bool IsClosed();

        bool IsClosing();

        bool IsOpened();

        bool IsOpening();
    }
}
