namespace ElevatorConsole_Exercise.Logic
{
    public interface CabinState
    {
        bool isStopped();
        bool isMoving();
        void cabinDoorClosedWhenWorking();
        void cabinDoorOpenedWhenWorking();
        void openCabinDoorWhenWorking();
        bool isWaitingForPeople();
        void waitForPeopleTimedOutWhenWorking();
        void closeCabinDoorWhenWorking();
        void accept(CabinStateVisitor visitor);
    }
}