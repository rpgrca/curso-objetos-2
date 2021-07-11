namespace ElevatorConsole_Exercise.Logic
{
    public interface CabinStateVisitor
    {
        void VisitCabinMoving(CabinMovingState cabinMovingState);
        void VisitCabinStopped(CabinStoppedState cabinStoppedState);
        void VisitCabinWaitingPeople(CabinWaitingForPeopleState cabinWaitingForPeopleState);
    }
}