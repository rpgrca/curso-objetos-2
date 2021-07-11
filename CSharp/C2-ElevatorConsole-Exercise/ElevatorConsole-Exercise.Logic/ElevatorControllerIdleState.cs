using System;

namespace ElevatorConsole_Exercise.Logic
{
    internal class ElevatorControllerIdleState: ElevatorControllerState
    {
        private readonly ElevatorController _elevatorController;

        public ElevatorControllerIdleState(ElevatorController elevatorController) =>
            _elevatorController = elevatorController;

        public bool IsIdle() => true;

        public void GoUpPushedFromFloor(int aFloorNumber) =>
            _elevatorController.GoUpPushedFromFloorWhenIdle(aFloorNumber);

        public bool IsWorking() => false;

        public void CabindDoorClosed() => _elevatorController.CabinDoorClosedWhenIdle();

        public void CabinOnFloor(int aFloorNumber) =>
            _elevatorController.CabinOnFloorWhenIdle(aFloorNumber);

        public void CabinDoorOpened() => throw new Exception();

        public void OpenCabinDoor() => _elevatorController.OpenCabinDoorWhenIdle();

        public void CloseCabinDoor() => _elevatorController.CloseCabinDoorWhenIdle();

        public void WaitForPeopleTimedOut() => throw new Exception();
    }
}