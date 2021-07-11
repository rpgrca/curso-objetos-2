using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinStoppedState: CabinState
    {
        private readonly ElevatorController _elevatorController;

        public CabinStoppedState(ElevatorController elevatorController) =>
            _elevatorController = elevatorController;

        public bool IsStopped() => true;

        public bool IsMoving() => false;

        public void CabinDoorClosedWhenWorking() =>
            _elevatorController.CabinDoorClosedWhenWorkingAndCabinStopped();

        public void CabinDoorOpenedWhenWorking() =>
            _elevatorController.CabinDoorOpenedWhenWorkingAndCabinStopped();

        public void OpenCabinDoorWhenWorking() =>
            _elevatorController.OpenCabinDoorWhenWorkingAndCabinStopped();

        public bool IsWaitingForPeople() => false;

        public void CloseCabinDoorWhenWorking() =>
            _elevatorController.CloseCabinDoorWhenWorkingAndCabinStopped();

        public void WaitForPeopleTimedOutWhenWorking() => throw new Exception();

        public void Accept(CabinStateVisitor visitor) => visitor.VisitCabinStopped(this);
    }
}