namespace ElevatorConsole_Exercise.Logic
{
    public interface CabinState : Visitor<CabinStateVisitor>
    {
        bool isStopped();
        bool isMoving();
        void cabinDoorClosedWhenWorking();
        void cabinDoorOpenedWhenWorking();
        void openCabinDoorWhenWorking();
        bool isWaitingForPeople();
        void waitForPeopleTimedOutWhenWorking();
        void closeCabinDoorWhenWorking();
    }
}