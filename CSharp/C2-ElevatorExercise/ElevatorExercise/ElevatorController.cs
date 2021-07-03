using System;
using System.Collections.Generic;

namespace ElevatorExercise
{
    internal class ElevatorController
    {
        private int _cabinFloorNumber;
        private CabinState _cabinState;
        private DoorState _doorState;
        private readonly List<int> _floorQueue;

        public ElevatorController()
        {
            _cabinState = new StoppedCabin();
            _doorState = new OpenedDoor();
            _floorQueue = new List<int>();
        }

        //Elevator state
        public bool isIdle() => _cabinState.IsStopped() && _doorState.IsOpened() && _floorQueue.Count == 0;

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

        public bool isCabinWaitingForPeople()
        {
            return true;
        }

        //Events
        public void goUpPushedFromFloor(int aFloorNumber)
        {
            _floorQueue.Add(aFloorNumber);
            _doorState = new ClosingDoor();
        }

        public void cabinOnFloor(int aFloorNumber)
        {
            if (aFloorNumber == _floorQueue[0])
            {
                _cabinFloorNumber = aFloorNumber;
                _floorQueue.RemoveAt(0);
            }
            else
            {
                throw new Exception();
            }

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
            if (! _cabinState.IsMoving())
            {
                if (!_doorState.IsOpened() && !_doorState.IsOpening())
                {
                    _doorState = new OpeningDoor();
                }
            }
        }

        public void cabinDoorOpened()
        {
            _doorState = new OpenedDoor();
        }

        public void waitForPeopleTimedOut() => throw new Exception("You should implement this method");

        public void closeCabinDoor() => throw new Exception("You should implement this method");
    }
}
