using System;

namespace ElevatorExercise
{
    public abstract class CabinState1
    {
        protected DoorState1 _doorState;

        protected CabinState _cabinState;

        public abstract void OpenDoor();

        internal void OpenedDoor() => _doorState = new OpenedDoor();

        internal bool IsDoorOpened() => _doorState.IsOpened();

        internal bool IsDoorOpening() => _doorState.IsOpening();

        internal bool IsDoorClosed() => _doorState.IsClosed();

        internal bool IsDoorClosing() => _doorState.IsClosing();

        public abstract bool IsStopped();

        public abstract bool IsMoving();
    }

    public class StoppedCabin : CabinState1
    {
        public StoppedCabin()
        {
            _doorState = new OpenedDoor();
        }

        public StoppedCabin(DoorState1 doorState) => _doorState = doorState;

        public override void OpenDoor() => _doorState.Open();
        public override bool IsStopped() => true;
        public override bool IsMoving() => false;
    }

    public class MovingCabin : CabinState1
    {
        public MovingCabin()
        {
            _doorState = new ClosedDoor();
        }

        public override bool IsStopped() => false;
        public override bool IsMoving() => true;

        public override void OpenDoor() {}
    }

    public class DoorState1
    {
        private DoorState _state;

        public DoorState1(DoorState state) => _state = state;

        internal void Open()
        {
            if (_state != DoorState.Opened)
            {
                _state = DoorState.Opening;
            }
        }

        internal bool IsClosed() => _state == DoorState.Closed;

        internal bool IsClosing() => _state == DoorState.Closing;

        internal bool IsOpened() => _state == DoorState.Opened;

        internal bool IsOpening() => _state == DoorState.Opening;
    }

    public class ClosedDoor : DoorState1
    {
        public ClosedDoor() : base(DoorState.Closed)
        {
        }
    }

    public class ClosingDoor : DoorState1
    {
        public ClosingDoor() : base(DoorState.Closing)
        {
        }
    }

    public class OpenedDoor : DoorState1
    {
        public OpenedDoor() : base(DoorState.Opened)
        {
        }
    }

    public class OpeningDoor : DoorState1
    {
        public OpeningDoor() : base(DoorState.Opening)
        {
        }
    }


    public enum DoorState
    {
        Opening,
        Opened,
        Closing,
        Closed
    }

    public enum CabinState
    {
        Stopped,
        Moving
    }

    internal class ElevatorController
    {
        private int _cabinFloorNumber;
        private CabinState1 _cabinState;
        private bool _isIdle;

        public ElevatorController()
        {
            _cabinState = new StoppedCabin();
            _isIdle = true;
        }

        //Elevator state
        public bool isIdle() => _isIdle;

        public bool isWorking() => ! isIdle();

        //Door state
        public bool isCabinDoorOpened() => _cabinState.IsDoorOpened();

        public bool isCabinDoorOpening() => _cabinState.IsDoorOpening();

        public bool isCabinDoorClosed() => _cabinState.IsDoorClosed();

        public bool isCabinDoorClosing() => _cabinState.IsDoorClosing();

        //Cabin state
        public int cabinFloorNumber() => _cabinFloorNumber;

        public bool isCabinStopped() => _cabinState.IsStopped();

        public bool isCabinMoving() => _cabinState.IsMoving();

        public bool isCabinWaitingForPeople() => throw new Exception("You should implement this method");

        //Events
        public void goUpPushedFromFloor(int aFloorNumber)
        {
            _cabinState = new StoppedCabin(new ClosingDoor());
            _isIdle = false;
        }

        public void cabinOnFloor(int aFloorNumber)
        {
            _cabinFloorNumber = aFloorNumber;
            _cabinState = new StoppedCabin(new OpeningDoor());
        }

        public void cabinDoorClosed()
        {
            _cabinState = new MovingCabin();
        }

        public void openCabinDoor()
        {
            _cabinState.OpenDoor();
        }

        public void cabinDoorOpened()
        {
            _cabinState.OpenedDoor();
            _isIdle = true;
        }

        public void waitForPeopleTimedOut() => throw new Exception("You should implement this method");

        public void closeCabinDoor() => throw new Exception("You should implement this method");
    }
}
