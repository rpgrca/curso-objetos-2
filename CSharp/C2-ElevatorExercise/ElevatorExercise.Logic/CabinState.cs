namespace ElevatorExercise.Logic
{
    public interface CabinState
    {
        bool IsStopped();
        bool IsMoving();
        void CloseDoor();
        void OpenDoor();
    }
}
