using System;
using System.Collections.Generic;
using System.Linq;

namespace ElevatorConsole_Exercise.Logic
{
    public class ElevatorController
    {
        private readonly ActiveVariable<CabinState> _cabinState;
        private readonly ActiveVariable<CabinDoorState> _doorState;
        private readonly SortedSet<int> _floorsToGo;
        private ElevatorControllerState _state;
        private int _currentCabinFloorNumber;

        public ElevatorController()
        {
            _currentCabinFloorNumber = 0;

            _cabinState = new();
            _doorState = new();
            _floorsToGo = new();

            controllerIsIdle();
            cabinIsStopped();
            cabinDoorIsOpened();
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
            _doorState.Set(new CabinDoorClosedState(this));

        private void cabinDoorIsOpened() =>
            _doorState.Set(new CabinDoorOpenedState(this));

        private void cabinDoorIsClosing() =>
            _doorState.Set(new CabinDoorClosingState(this));

        private void cabinDoorIsOpening() =>
            _doorState.Set(new CabinDoorOpeningState(this));

        public bool isCabinDoorOpened() => _doorState.State.isOpened();

        public bool isCabinDoorOpening() => _doorState.State.isOpening();

        public bool isCabinDoorClosed() => _doorState.State.isClosed();

        public bool isCabinDoorClosing() => _doorState.State.isClosing();

        //Cabin state
        private void cabinIsStopped() =>
            _cabinState.Set(new CabinStoppedState(this));

        private void cabinMoving() =>
            _cabinState.Set(new CabinMovingState(this));

        private void cabinIsWaitingForPeople() =>
            _cabinState.Set(new CabinWaitingForPeopleState(this));

        public int cabinFloorNumber() => _currentCabinFloorNumber;

        public bool isCabinStopped() => _cabinState.State.isStopped();

        public bool isCabinMoving() => _cabinState.State.isMoving();

        public bool isCabinWaitingForPeople() => _cabinState.State.isWaitingForPeople();

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
            _cabinState.State.cabinDoorClosedWhenWorking();

        public void cabinDoorClosedWhenWorkingAndCabinStopped() =>
            _doorState.State.cabinDoorClosedWhenWorkingAndCabinStopped();

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
            _cabinState.State.cabinDoorOpenedWhenWorking();

        public void cabinDoorOpenedWhenWorkingAndCabinStopped()
        {
            cabinDoorIsOpened();
            if (hasFloorToGo())
            {
                cabinIsWaitingForPeople();
            }
            else
            {
                controllerStateIsIdle();
            }
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
            _cabinState.State.openCabinDoorWhenWorking();

        public void openCabinDoorWhenWorkingAndCabinStopped() =>
            _doorState.State.openCabinDoorWhenWorkingAndCabinStopped();

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
            _cabinState.State.waitForPeopleTimedOutWhenWorking();

        public void waitForPeopleTimedOutWhenWorkingAndCabinWaitingForPeople()
        {
            cabinIsStopped();
            cabinDoorIsClosing();
        }

        public void closeCabinDoorWhenWorking() =>
            _cabinState.State.closeCabinDoorWhenWorking();

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
            _doorState.State.closeCabinDoorWhenWorkingAndCabinStopped();

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

        public void addCabinObserver(Observer<CabinState> observer) =>
            _cabinState.AddObserver(observer);

        public void addCabinDoorObserver(Observer<CabinDoorState> observer) =>
            _doorState.AddObserver(observer);
    }
}