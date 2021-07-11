using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinMovingState: CabinState
    {
        private readonly ElevatorController _elevatorController;

        public CabinMovingState(ElevatorController elevatorController) =>
            _elevatorController = elevatorController;

        public void cabinDoorClosedWhenWorking() =>
            _elevatorController.cabinDoorClosedWhenWorkingAndCabinMoving();

        public bool isMoving() => true;

        public bool isStopped() => false;

        public void cabinDoorOpenedWhenWorking() => throw new Exception();

        public void openCabinDoorWhenWorking() =>
            _elevatorController.openCabinDoorWhenWorkingAndCabinMoving();

        public bool isWaitingForPeople() => false;

        public void closeCabinDoorWhenWorking() =>
            _elevatorController.closeCabinDoorWhenWorkingAndCabinMoving();

        public void waitForPeopleTimedOutWhenWorking() => throw new Exception();

        public void Accept(CabinStateVisitor visitor) => visitor.visitCabinMoving(this);
    }
}