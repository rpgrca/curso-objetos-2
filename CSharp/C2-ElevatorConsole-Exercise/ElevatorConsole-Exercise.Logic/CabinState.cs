namespace ElevatorConsole_Exercise.Logic
{
    public interface CabinState
    {
        bool IsStopped();
        bool IsMoving();
        void CabinDoorClosedWhenWorking();
        void CabinDoorOpenedWhenWorking();
        void OpenCabinDoorWhenWorking();
        bool IsWaitingForPeople();
        void WaitForPeopleTimedOutWhenWorking();
        void CloseCabinDoorWhenWorking();
        void Accept(CabinStateVisitor visitor);
    }
}