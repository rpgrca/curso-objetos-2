using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinDoorOpenedState: CabinDoorState
    {
        private readonly ElevatorController _elevatorController;

        public CabinDoorOpenedState(ElevatorController elevatorController) =>
            _elevatorController = elevatorController;

        public bool isOpened() => true;

        public bool isOpening() => false;

        public bool isClosing() => false;

        public bool isClosed() => false;

        public void cabinDoorClosedWhenWorkingAndCabinStopped() => throw new Exception();

        public void closeCabinDoorWhenWorkingAndCabinStopped() => throw new Exception();

        public void openCabinDoorWhenWorkingAndCabinStopped() => throw new Exception();

        public void Accept(CabinDoorStateVisitor visitor) => visitor.visitCabinDoorOpened(this);
    }
}