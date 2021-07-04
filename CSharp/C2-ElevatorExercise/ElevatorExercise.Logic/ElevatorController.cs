using System.Linq;
using System.Collections.Generic;

namespace ElevatorExercise.Logic
{
    public class ElevatorController
    {
        private int _cabinFloorNumber;
        private CabinState _cabinState;
        private DoorState _doorState;
        private readonly List<int> _floorQueue;
        private bool _waitingForPeople;

        public ElevatorController()
        {
            _cabinState = new StoppedCabin();
            _doorState = new OpenedDoor();
            _floorQueue = new List<int>();
            _waitingForPeople = true;
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
            return _waitingForPeople;
        }

        //Events
        public void goUpPushedFromFloor(int aFloorNumber)
        {
            if (_floorQueue.Count > 0)
            {
                _floorQueue.AddRange(Enumerable.Range(_floorQueue.Last() + 1, aFloorNumber));
            }
            else
            {
                _floorQueue.AddRange(Enumerable.Range(1, aFloorNumber));
            }
            _doorState = new ClosingDoor();
        }

        public void cabinOnFloor(int aFloorNumber)
        {
            if (_floorQueue.Count > 0 && aFloorNumber == _floorQueue[0])
            {
                _cabinFloorNumber = aFloorNumber;
                _floorQueue.RemoveAt(0);
            }
            else
            {
                throw new ElevatorEmergency("Sensor de cabina desincronizado");
            }

            _cabinState = new StoppedCabin();
            _doorState = new OpeningDoor();
        }

        public void cabinDoorClosed()
        {
            if (_floorQueue.Count == 0)
            {
                throw new ElevatorEmergency("Sensor de puerta desincronizado");
            }

            if (_doorState.IsClosed())
            {
                throw new ElevatorEmergency("Sensor de puerta desincronizado");
            }

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

        public void waitForPeopleTimedOut()
        {
            _waitingForPeople = false;
            _doorState = new ClosingDoor();
        }

        public void closeCabinDoor()
        {
            if (! isIdle() && !isCabinMoving() && !isCabinDoorOpening())
            {
                _doorState = new ClosingDoor();
            }
        }
    }
}