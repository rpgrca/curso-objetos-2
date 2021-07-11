using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinMovingState: CabinState
    {
        private readonly ElevatorController _elevatorController;

        public CabinMovingState(ElevatorController elevatorController) =>
            _elevatorController = elevatorController;

        public void CabinDoorClosedWhenWorking() =>
            _elevatorController.CabinDoorClosedWhenWorkingAndCabinMoving();

        public bool IsMoving() => true;

        public bool IsStopped() => false;

        public void CabinDoorOpenedWhenWorking() => throw new Exception();

        public void OpenCabinDoorWhenWorking() =>
            _elevatorController.OpenCabinDoorWhenWorkingAndCabinMoving();

        public bool IsWaitingForPeople() => false;

        public void CloseCabinDoorWhenWorking() =>
            _elevatorController.CloseCabinDoorWhenWorkingAndCabinMoving();

        public void WaitForPeopleTimedOutWhenWorking() => throw new Exception();

        public void Accept(CabinStateVisitor visitor) => visitor.VisitCabinMoving(this);
    }
}