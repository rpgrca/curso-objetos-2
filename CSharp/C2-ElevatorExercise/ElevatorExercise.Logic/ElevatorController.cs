using System.Linq;
using System.Collections.Generic;

namespace ElevatorExercise.Logic
{
    public class ElevatorController
    {
        private int _cabinFloorNumber;
        private readonly Cabin _cabin;
        private readonly Door _door;
        private readonly List<int> _floorQueue;
        private bool _waitingForPeople;

        public ElevatorController()
        {
            _cabin = new Cabin();
            _door = new Door();
            _floorQueue = new List<int>();
            _waitingForPeople = true;
        }

        //Elevator state
        public bool isIdle() => _door.IsOpened() && _floorQueue.Count == 0;

        public bool isWorking() => ! isIdle();

        //Door state
        public bool isCabinDoorOpened() => _door.IsOpened();

        public bool isCabinDoorOpening() => _door.IsOpening();

        public bool isCabinDoorClosed() => _door.IsClosed();

        public bool isCabinDoorClosing() => _door.IsClosing();

        //Cabin state
        public int cabinFloorNumber() => _cabinFloorNumber;

        public bool isCabinStopped() => _cabin.IsStopped();

        public bool isCabinMoving() => _cabin.IsMoving();

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

            _door.Close();
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

            _cabin.Stop();
            _door.Open();
        }

        public void cabinDoorClosed()
        {
            if (_floorQueue.Count == 0)
            {
                throw new ElevatorEmergency("Sensor de puerta desincronizado");
            }

            if (_door.IsClosed())
            {
                throw new ElevatorEmergency("Sensor de puerta desincronizado");
            }

            _door.Closed();
            _cabin.Move();
        }

        public void openCabinDoor()
        {
            if (! _cabin.IsMoving())
            {
                if (!_door.IsOpened() && !_door.IsOpening())
                {
                    _door.Open();
                }
            }
        }

        public void cabinDoorOpened()
        {
            _door.Opened();
        }

        public void waitForPeopleTimedOut()
        {
            _waitingForPeople = false;
            _door.Close();
        }

        public void closeCabinDoor()
        {
            if (! isIdle() && !isCabinMoving() && !isCabinDoorOpening())
            {
                _door.Close();
            }
        }
    }
}