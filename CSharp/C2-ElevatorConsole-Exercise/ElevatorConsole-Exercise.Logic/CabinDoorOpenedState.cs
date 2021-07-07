using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinDoorOpenedState: CabinDoorState
    {
        private readonly ElevatorController _elevatorController;

        public CabinDoorOpenedState(ElevatorController elevatorController) {
            _elevatorController = elevatorController;
        }

        public bool isOpened() {
            return true;
        }

        public bool isOpening() {
            return false;
        }

        public bool isClosing() {
            return false;
        }

        public bool isClosed() {
            return false;
        }

        public void cabinDoorClosedWhenWorkingAndCabinStopped() {
            throw new Exception();
        }

        public void closeCabinDoorWhenWorkingAndCabinStopped() {
            throw new Exception();
        }

        public void openCabinDoorWhenWorkingAndCabinStopped() {
            throw new Exception();
        }

        public void accept(CabinDoorStateVisitor visitor) {
            visitor.visitCabinDoorOpened(this);
        }
    }
}