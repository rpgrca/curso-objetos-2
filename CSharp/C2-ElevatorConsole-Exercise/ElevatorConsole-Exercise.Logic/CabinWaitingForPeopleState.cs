using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinWaitingForPeopleState: CabinState
    {
        private readonly ElevatorController _elevatorController;

        public CabinWaitingForPeopleState(ElevatorController elevatorController) =>
            _elevatorController = elevatorController;

        public void CabinDoorClosedWhenWorking() => throw new Exception();

        public void CabinDoorOpenedWhenWorking() => throw new Exception();

        public bool IsMoving() => false;

        public bool IsStopped() => true;

        public void OpenCabinDoorWhenWorking() => throw new Exception();

        public bool IsWaitingForPeople() => true;

        public void WaitForPeopleTimedOutWhenWorking() =>
            _elevatorController.WaitForPeopleTimedOutWhenWorkingAndCabinWaitingForPeople();

        public void CloseCabinDoorWhenWorking() =>
            _elevatorController.CloseCabinDoorWhenWorkingAndCabinWaitingForPeople();

        public void Accept(CabinStateVisitor visitor) => visitor.VisitCabinWaitingPeople(this);
    }
}