using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinDoorClosedState: CabinDoorState
    {
        private readonly ElevatorController _elevatorController;

        public CabinDoorClosedState(ElevatorController elevatorController) {
            _elevatorController = elevatorController;
        }

        public void cabinDoorClosedWhenWorkingAndCabinStopped() {
            throw new Exception();
        }

        public bool isClosed() {
            return true;
        }

        public bool isClosing() {
            return false;
        }

        public bool isOpened() {
            return false;
        }

        public bool isOpening() {
            return false;
        }

        public void closeCabinDoorWhenWorkingAndCabinStopped() {
            throw new Exception();
        }

        public void openCabinDoorWhenWorkingAndCabinStopped() {
            throw new Exception();
        }

        public void accept(CabinDoorStateVisitor visitor) {
            visitor.visitCabinDoorClosed(this);
        }
    }
}