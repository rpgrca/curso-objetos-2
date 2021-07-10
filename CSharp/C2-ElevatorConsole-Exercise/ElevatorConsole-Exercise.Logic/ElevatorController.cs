using System;
using System.Collections.Generic;
using System.Linq;

namespace ElevatorConsole_Exercise.Logic
{
    public class ElevatorController
    {
        private ElevatorControllerState _state;
        private CabinState _cabinState;
        private CabinDoorState _cabinDoorState;
        private int _currentCabinFloorNumber;
        private readonly List<CabinStateVisitor> _cabinStateObservers = new();
        private readonly List<CabinDoorStateVisitor> _cabinDoorStateObservers = new();
        private readonly SortedSet<int> _floorsToGo = new();

        public ElevatorController()
        {
            controllerIsIdle();
            cabinIsStopped();
            cabinDoorIsOpened();
            _currentCabinFloorNumber = 0;
        }

        //Elevator state
        private void controllerIsIdle() =>
            changeStateTo(new ElevatorControllerIdleState(this));

        private void changeStateTo(ElevatorControllerState newState) =>
            _state = newState;

        private void controllerIsWorking() =>
            changeStateTo(new ElevatorControllerIsWorkingState(this));

        public bool isIdle() => _state.isIdle();

        public bool isWorking() => _state.isWorking();

        //Door state
        private void cabinDoorIsClosed() =>
            changeDoorStateTo(new CabinDoorClosedState(this));

        private void changeDoorStateTo(CabinDoorState newCabinState)
        {
            _cabinDoorState = newCabinState;
            _cabinDoorStateObservers.ForEach(p => _cabinDoorState.accept(p));
        }

        private void cabinDoorIsOpened() =>
            changeDoorStateTo(new CabinDoorOpenedState(this));

        private void cabinDoorIsClosing() =>
            changeDoorStateTo(new CabinDoorClosingState(this));

        private void cabinDoorIsOpening()
        {
            _cabinDoorState = new CabinDoorOpeningState(this);
            _cabinDoorStateObservers.ForEach(p => _cabinDoorState.accept(p));
        }

        public bool isCabinDoorOpened() => _cabinDoorState.isOpened();

        public bool isCabinDoorOpening() => _cabinDoorState.isOpening();

        public bool isCabinDoorClosed() => _cabinDoorState.isClosed();

        public bool isCabinDoorClosing() => _cabinDoorState.isClosing();

        //Cabin state
        private void cabinIsStopped() =>
            changeCabinStateTo(new CabinStoppedState(this));

        private void changeCabinStateTo(CabinState newCabinState)
        {
            _cabinState = newCabinState;
            _cabinStateObservers.ForEach(p => _cabinState.accept(p));
        }

        private void cabinMoving() =>
            changeCabinStateTo(new CabinMovingState(this));

        private void cabinIsWaitingForPeople() =>
            changeCabinStateTo(new CabinWaitingForPeopleState(this));

        public int cabinFloorNumber() => _currentCabinFloorNumber;

        public bool isCabinStopped() => _cabinState.isStopped();

        public bool isCabinMoving() => _cabinState.isMoving();

        public bool isCabinWaitingForPeople() => _cabinState.isWaitingForPeople();

        //Events
        public void goUpPushedFromFloor(int aFloorNumber) =>
            _state.goUpPushedFromFloor(aFloorNumber);

        public void cabinOnFloor(int aFloorNumber) =>
            _state.cabinOnFloor(aFloorNumber);

        public void cabinDoorClosed() => _state.cabindDoorClosed();

        public void openCabinDoor() => _state.openCabinDoor();

        public void cabinDoorOpened() => _state.cabinDoorOpened();

        public void waitForPeopleTimedOut() => _state.waitForPeopleTimedOut();

        public void closeCabinDoor() => _state.closeCabinDoor();

        public void goUpPushedFromFloorWhenIdle(int aFloorNumber)
        {
            _floorsToGo.Add(aFloorNumber);
            controllerIsWorking();
            cabinDoorIsClosing();
        }

        public void cabinDoorClosedWhenWorking() =>
            _cabinState.cabinDoorClosedWhenWorking();

        public void cabinDoorClosedWhenWorkingAndCabinStopped() =>
            _cabinDoorState.cabinDoorClosedWhenWorkingAndCabinStopped();

        public void cabinDoorClosedWhenWorkingAndCabinStoppedAndClosing()
        {
            cabinDoorIsClosed();
            cabinMoving();
        }

        public void cabinOnFloorWhenWorking(int aFloorNumber)
        {
            if (aFloorNumber < _currentCabinFloorNumber) throw new Exception("Sensor de cabina desincronizado");
            if (_currentCabinFloorNumber + 1 != aFloorNumber) throw new Exception("Sensor de cabina desincronizado");

            _currentCabinFloorNumber = aFloorNumber;
            if (_floorsToGo.ElementAt(0) == aFloorNumber)
            {
                _floorsToGo.Remove(_floorsToGo.ElementAt(0));
                cabinIsStopped();
                cabinDoorIsOpening();
            }
        }

        public void cabinOnFloorWhenIdle(int aFloorNumber) =>
            throw new Exception("Sensor de cabina desincronizado");

        public void cabinDoorOpenendWhenWorking() =>
            _cabinState.cabinDoorOpenedWhenWorking();

        public void cabinDoorOpenedWhenWorkingAndCabinStopped()
        {
            cabinDoorIsOpened();
            if (hasFloorToGo())
                cabinIsWaitingForPeople();
            else
                controllerStateIsIdle();
        }

        private void controllerStateIsIdle() =>
            _state = new ElevatorControllerIdleState(this);

        private bool hasFloorToGo() => _floorsToGo.Count > 0;

        public void openCabinDoorWhenIdle()
        {
            //No hago nada porque me pidieron abrir la puerta cuando no estoy haciendo nada
            //y en ese caso ya está abierta
        }

        public void openCabinDoorWhenWorking() =>
            _cabinState.openCabinDoorWhenWorking();

        public void openCabinDoorWhenWorkingAndCabinStopped() =>
            _cabinDoorState.openCabinDoorWhenWorkingAndCabinStopped();

        public void openCabinDoorWhenWorkingAndCabinStoppedAndDoorClosing() =>
            cabinDoorIsOpening();

        public void openCabinDoorWhenWorkingAndCabinMoving()
        {
            //No puedo abrir la puerta porque la cabina se está moviendo!
        }

        public void openCabinDoorWhenWorkingAndCabinStoppedAndCabinDoorOpening()
        {
            //Ya se está abriendo!! no tengo que hacer nada
        }

        public void goUpPushedFromFloorWhenWorking(int aFloorNumber) =>
            _floorsToGo.Add(aFloorNumber);

        public void waitForPeopleTimedOutWhenWorking() =>
            _cabinState.waitForPeopleTimedOutWhenWorking();

        public void waitForPeopleTimedOutWhenWorkingAndCabinWaitingForPeople()
        {
            cabinIsStopped();
            cabinDoorIsClosing();
        }

        public void closeCabinDoorWhenWorking() =>
            _cabinState.closeCabinDoorWhenWorking();

        public void closeCabinDoorWhenWorkingAndCabinWaitingForPeople() =>
            waitForPeopleTimedOutWhenWorkingAndCabinWaitingForPeople();

        public void closeCabinDoorWhenIdle()
        {
            //No estoy haciendo nada y me piden cerrar la puerta, por lo tanto no la 
            //cierro porque no tengo que mover la cabina puesto que estoy idle
        }

        public void closeCabinDoorWhenWorkingAndCabinMoving()
        {
            //Si la cabina se está moviendo, la puerta ya está cerrada, por lo tanto
            //no tengo que volver a cerrarla
        }

        public void closeCabinDoorWhenWorkingAndCabinStopped() =>
            _cabinDoorState.closeCabinDoorWhenWorkingAndCabinStopped();

        public void closeCabinDoorWhenWorkingAndCabinStoppedAndCabinDoorOpening()
        {
            //Estoy abriendo la puerta para que suba gente y me piden cerrarla. 
            //No la cierro hasta no abrir completamente la puerta
        }

        public void cabinDoorClosedWhenIdle() =>
            throw new Exception("Sensor de puerta desincronizado");

        public void cabinDoorClosedWhenWorkingAndCabinMoving() =>
            throw new Exception("Sensor de puerta desincronizado");

        public void cabinDoorClosedWhenWorkingAndCabinStoppedAndCabinDoorOpening() =>
            throw new Exception("Sensor de puerta desincronizado");

        public void addCabinObserver(CabinStateVisitor cabinStateVisitor) =>
            _cabinStateObservers.Add(cabinStateVisitor);

        public void addCabinDoorObserver(CabinDoorStateVisitor cabinDoorStateVisitor) =>
            _cabinDoorStateObservers.Add(cabinDoorStateVisitor);
    }
}