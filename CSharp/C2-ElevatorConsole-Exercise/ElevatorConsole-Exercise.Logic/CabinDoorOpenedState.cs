using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinDoorOpenedState: CabinDoorState
    {
        public CabinDoorOpenedState(ElevatorController _)
        {
        }

        public bool isOpened() => true;

        public bool isOpening() => false;

        public bool isClosing() => false;

        public bool isClosed() => false;

        public void cabinDoorClosedWhenWorkingAndCabinStopped() => throw new Exception();

        public void closeCabinDoorWhenWorkingAndCabinStopped() => throw new Exception();

        public void openCabinDoorWhenWorkingAndCabinStopped() => throw new Exception();

        public void accept(CabinDoorStateVisitor visitor) => visitor.visitCabinDoorOpened(this);
    }
}