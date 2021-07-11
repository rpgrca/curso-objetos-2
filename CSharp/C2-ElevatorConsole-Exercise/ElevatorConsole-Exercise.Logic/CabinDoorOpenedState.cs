using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinDoorOpenedState: CabinDoorState
    {
        public CabinDoorOpenedState(ElevatorController _)
        {
        }

        public bool IsOpened() => true;

        public bool IsOpening() => false;

        public bool IsClosing() => false;

        public bool IsClosed() => false;

        public void CabinDoorClosedWhenWorkingAndCabinStopped() => throw new Exception();

        public void CloseCabinDoorWhenWorkingAndCabinStopped() => throw new Exception();

        public void OpenCabinDoorWhenWorkingAndCabinStopped() => throw new Exception();

        public void Accept(CabinDoorStateVisitor visitor) => visitor.VisitCabinDoorOpened(this);
    }
}