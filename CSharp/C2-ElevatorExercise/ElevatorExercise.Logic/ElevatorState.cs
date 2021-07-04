namespace ElevatorExercise.Logic
{
    public interface ElevatorState
    {
        bool IsIdle();
        bool IsWorking();
        void goUpPushedFromFloor(int aFloorNumber);
        void DoorOpened();
        void CloseDoor();
    }
}