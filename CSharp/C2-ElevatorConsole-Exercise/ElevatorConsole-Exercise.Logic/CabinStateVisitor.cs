namespace ElevatorConsole_Exercise.Logic
{
    public interface CabinStateVisitor
    {
        void visitCabinMoving(CabinMovingState cabinMovingState);
        void visitCabinStopped(CabinStoppedState cabinStoppedState);
        void visitCabinWaitingPeople(CabinWaitingForPeopleState cabinWaitingForPeopleState);
    }
}
