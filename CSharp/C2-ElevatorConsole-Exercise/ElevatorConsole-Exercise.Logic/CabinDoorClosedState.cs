using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinDoorClosedState: CabinDoorState
    {
        public CabinDoorClosedState(ElevatorController _)
        {
        }

        public void CabinDoorClosedWhenWorkingAndCabinStopped() => throw new Exception();

        public bool IsClosed() => true;

        public bool IsClosing() => false;

        public bool IsOpened() => false;

        public bool IsOpening() => false;

        public void CloseCabinDoorWhenWorkingAndCabinStopped() => throw new Exception();

        public void OpenCabinDoorWhenWorkingAndCabinStopped() => throw new Exception();

        public void Accept(CabinDoorStateVisitor visitor) => visitor.VisitCabinDoorClosed(this);
    }
}