using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinDoorClosedState: CabinDoorState
    {
        public CabinDoorClosedState(ElevatorController _)
        {
        }

        public void cabinDoorClosedWhenWorkingAndCabinStopped() => throw new Exception();

        public bool isClosed() => true;

        public bool isClosing() => false;

        public bool isOpened() => false;

        public bool isOpening() => false;

        public void closeCabinDoorWhenWorkingAndCabinStopped() => throw new Exception();

        public void openCabinDoorWhenWorkingAndCabinStopped() => throw new Exception();

        public void accept(CabinDoorStateVisitor visitor) => visitor.visitCabinDoorClosed(this);
    }
}