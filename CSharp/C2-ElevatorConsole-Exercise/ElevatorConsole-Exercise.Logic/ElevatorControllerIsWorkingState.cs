﻿namespace ElevatorConsole_Exercise.Logic
{
    internal class ElevatorControllerIsWorkingState: ElevatorControllerState
    {
        private readonly ElevatorController _elevatorController;

        public ElevatorControllerIsWorkingState(ElevatorController elevatorController) =>
            _elevatorController = elevatorController;

        public void goUpPushedFromFloor(int aFloorNumber) =>
            _elevatorController.goUpPushedFromFloorWhenWorking(aFloorNumber);

        public bool isIdle() => false;

        public bool isWorking() => true;

        public void cabindDoorClosed() =>
            _elevatorController.cabinDoorClosedWhenWorking();

        public void cabinOnFloor(int aFloorNumber) =>
            _elevatorController.cabinOnFloorWhenWorking(aFloorNumber);

        public void cabinDoorOpened() =>
            _elevatorController.cabinDoorOpenendWhenWorking();

        public void openCabinDoor() =>
            _elevatorController.openCabinDoorWhenWorking();

        public void waitForPeopleTimedOut() =>
            _elevatorController.waitForPeopleTimedOutWhenWorking();

        public void closeCabinDoor() =>
            _elevatorController.closeCabinDoorWhenWorking();
    }
}