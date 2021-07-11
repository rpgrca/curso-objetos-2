namespace ElevatorConsole_Exercise.Logic
{
    internal interface ElevatorControllerState
    {
        bool IsIdle();
        void GoUpPushedFromFloor(int aFloorNumber);
        bool IsWorking();
        void CabindDoorClosed();
        void CabinOnFloor(int aFloorNumber);
        void CabinDoorOpened();
        void OpenCabinDoor();
        void WaitForPeopleTimedOut();
        void CloseCabinDoor();
    }
}