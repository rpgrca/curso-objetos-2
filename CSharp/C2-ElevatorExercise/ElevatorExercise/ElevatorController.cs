using System;

namespace ElevatorExercise
{
    public interface CabinState
    {
        bool IsStopped();

        bool IsMoving();
    }

    public class StoppedCabin : CabinState
    {
        public bool IsStopped() => true;
        public bool IsMoving() => false;
    }

    public class MovingCabin : CabinState
    {
        public bool IsStopped() => false;
        public bool IsMoving() => true;
    }

    public abstract class DoorState
    {
        public abstract bool IsClosed();

        public abstract bool IsClosing();

        public abstract bool IsOpened();

        public abstract bool IsOpening();
    }

    public class ClosedDoor : DoorState
    {
        public override bool IsClosed() => true;

        public override bool IsClosing() => false;

        public override bool IsOpened() => false;

        public override bool IsOpening() => false;
    }

    public class ClosingDoor : DoorState
    {
        public override bool IsClosed() => false;

        public override bool IsClosing() => true;

        public override bool IsOpened() => false;

        public override bool IsOpening() => false;
    }

    public class OpenedDoor : DoorState
    {
        public override bool IsClosed() => false;

        public override bool IsClosing() => false;

        public override bool IsOpened() => true;

        public override bool IsOpening() => false;
    }

    public class OpeningDoor : DoorState
    {
        public override bool IsClosed() => false;

        public override bool IsClosing() => false;

        public override bool IsOpened() => false;

        public override bool IsOpening() => true;
    }

    internal class ElevatorController
    {
        private int _cabinFloorNumber;
        private CabinState _cabinState;
        private DoorState _doorState;
        private bool _isIdle;

        public ElevatorController()
        {
            _cabinState = new StoppedCabin();
            _doorState = new OpenedDoor();
            _isIdle = true;
        }

        //Elevator state
        public bool isIdle() => _isIdle;

        public bool isWorking() => ! isIdle();

        //Door state
        public bool isCabinDoorOpened() => _doorState.IsOpened();

        public bool isCabinDoorOpening() => _doorState.IsOpening();

        public bool isCabinDoorClosed() => _doorState.IsClosed();

        public bool isCabinDoorClosing() => _doorState.IsClosing();

        //Cabin state
        public int cabinFloorNumber() => _cabinFloorNumber;

        public bool isCabinStopped() => _cabinState.IsStopped();

        public bool isCabinMoving() => _cabinState.IsMoving();

        public bool isCabinWaitingForPeople() => throw new Exception("You should implement this method");

        //Events
        public void goUpPushedFromFloor(int aFloorNumber)
        {
            _doorState = new ClosingDoor();
            _isIdle = false;
        }

        public void cabinOnFloor(int aFloorNumber)
        {
            _cabinFloorNumber = aFloorNumber;
            _cabinState = new StoppedCabin();
            _doorState = new OpeningDoor();
        }

        public void cabinDoorClosed()
        {
            _doorState = new ClosedDoor();
            _cabinState = new MovingCabin();
        }

        public void openCabinDoor()
        {
            if (!_doorState.IsOpened() && !_doorState.IsOpening())
            {
                _doorState = new OpeningDoor();
            }
        }

        public void cabinDoorOpened()
        {
            _doorState = new OpenedDoor();
            _isIdle = true;
        }

        public void waitForPeopleTimedOut() => throw new Exception("You should implement this method");

        public void closeCabinDoor() => throw new Exception("You should implement this method");
    }
}
