namespace ElevatorConsole_Exercise.Logic
{
    internal interface ElevatorControllerState
    {
        bool isIdle();
        void goUpPushedFromFloor(int aFloorNumber);
        bool isWorking();
        void cabindDoorClosed();
        void cabinOnFloor(int aFloorNumber);
        void cabinDoorOpened();
        void openCabinDoor();
        void waitForPeopleTimedOut();
        void closeCabinDoor();
    }
}