using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinDoorClosingState: CabinDoorState
    {
        private readonly ElevatorController _elevatorController;

        public CabinDoorClosingState(ElevatorController elevatorController) {
            _elevatorController = elevatorController;
        }

        public bool isOpened() {
            return false;
        }

        public bool isOpening() {
            return false;
        }

        public bool isClosing() {
            return true;
        }

        public bool isClosed() {
            return false;
        }

        public void cabinDoorClosedWhenWorkingAndCabinStopped() {
            _elevatorController.cabinDoorClosedWhenWorkingAndCabinStoppedAndClosing();
        }

        public void openCabinDoorWhenWorkingAndCabinStopped() {
            _elevatorController.openCabinDoorWhenWorkingAndCabinStoppedAndDoorClosing();
        }

        public void closeCabinDoorWhenWorkingAndCabinStopped() {
            throw new Exception();
        }

        public void accept(CabinDoorStateVisitor visitor) {
            visitor.visitCabinDoorClosing(this);
        }
    }
}