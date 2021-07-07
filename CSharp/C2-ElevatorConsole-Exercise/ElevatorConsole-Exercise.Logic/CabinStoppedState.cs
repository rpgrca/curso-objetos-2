using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinStoppedState: CabinState
    {
        private readonly ElevatorController _elevatorController;

        public CabinStoppedState(ElevatorController elevatorController) =>
            _elevatorController = elevatorController;

        public bool isStopped() => true;

        public bool isMoving() => false;

        public void cabinDoorClosedWhenWorking() =>
            _elevatorController.cabinDoorClosedWhenWorkingAndCabinStopped();

        public void cabinDoorOpenedWhenWorking() =>
            _elevatorController.cabinDoorOpenedWhenWorkingAndCabinStopped();

        public void openCabinDoorWhenWorking() =>
            _elevatorController.openCabinDoorWhenWorkingAndCabinStopped();

        public bool isWaitingForPeople() => false;

        public void closeCabinDoorWhenWorking() =>
            _elevatorController.closeCabinDoorWhenWorkingAndCabinStopped();

        public void waitForPeopleTimedOutWhenWorking() => throw new Exception();

        public void accept(CabinStateVisitor visitor) => visitor.visitCabinStopped(this);
    }
}