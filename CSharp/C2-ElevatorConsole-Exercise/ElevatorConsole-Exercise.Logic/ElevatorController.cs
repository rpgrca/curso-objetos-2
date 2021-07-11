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

            ControllerIsIdle();
            CabinIsStopped();
            CabinDoorIsOpened();
        }

        //Elevator state
        private void ControllerIsIdle() =>
            ChangeStateTo(new ElevatorControllerIdleState(this));

        private void ChangeStateTo(ElevatorControllerState newState) =>
            _state = newState;

        private void ControllerIsWorking() =>
            ChangeStateTo(new ElevatorControllerIsWorkingState(this));

        public bool IsIdle() => _state.IsIdle();

        public bool IsWorking() => _state.IsWorking();

        //Door state
        private void CabinDoorIsClosed() =>
            _doorState.Set(new CabinDoorClosedState(this));

        private void CabinDoorIsOpened() =>
            _doorState.Set(new CabinDoorOpenedState(this));

        private void CabinDoorIsClosing() =>
            _doorState.Set(new CabinDoorClosingState(this));

        private void CabinDoorIsOpening() =>
            _doorState.Set(new CabinDoorOpeningState(this));

        public bool IsCabinDoorOpened() => _doorState.State.IsOpened();

        public bool IsCabinDoorOpening() => _doorState.State.IsOpening();

        public bool IsCabinDoorClosed() => _doorState.State.IsClosed();

        public bool IsCabinDoorClosing() => _doorState.State.IsClosing();

        //Cabin state
        private void CabinIsStopped() =>
            _cabinState.Set(new CabinStoppedState(this));

        private void CabinMoving() =>
            _cabinState.Set(new CabinMovingState(this));

        private void CabinIsWaitingForPeople() =>
            _cabinState.Set(new CabinWaitingForPeopleState(this));

        public int CabinFloorNumber() => _currentCabinFloorNumber;

        public bool IsCabinStopped() => _cabinState.State.IsStopped();

        public bool IsCabinMoving() => _cabinState.State.IsMoving();

        public bool IsCabinWaitingForPeople() => _cabinState.State.IsWaitingForPeople();

        //Events
        public void GoUpPushedFromFloor(int aFloorNumber) =>
            _state.GoUpPushedFromFloor(aFloorNumber);

        public void CabinOnFloor(int aFloorNumber) =>
            _state.CabinOnFloor(aFloorNumber);

        public void CabinDoorClosed() => _state.CabindDoorClosed();

        public void OpenCabinDoor() => _state.OpenCabinDoor();

        public void CabinDoorOpened() => _state.CabinDoorOpened();

        public void WaitForPeopleTimedOut() => _state.WaitForPeopleTimedOut();

        public void CloseCabinDoor() => _state.CloseCabinDoor();

        public void GoUpPushedFromFloorWhenIdle(int aFloorNumber)
        {
            _floorsToGo.Add(aFloorNumber);
            ControllerIsWorking();
            CabinDoorIsClosing();
        }

        public void CabinDoorClosedWhenWorking() =>
            _cabinState.State.CabinDoorClosedWhenWorking();

        public void CabinDoorClosedWhenWorkingAndCabinStopped() =>
            _doorState.State.CabinDoorClosedWhenWorkingAndCabinStopped();

        public void CabinDoorClosedWhenWorkingAndCabinStoppedAndClosing()
        {
            CabinDoorIsClosed();
            CabinMoving();
        }

        public void CabinOnFloorWhenWorking(int aFloorNumber)
        {
            if (aFloorNumber < _currentCabinFloorNumber) throw new Exception("Sensor de cabina desincronizado");
            if (_currentCabinFloorNumber + 1 != aFloorNumber) throw new Exception("Sensor de cabina desincronizado");

            _currentCabinFloorNumber = aFloorNumber;
            if (_floorsToGo.ElementAt(0) == aFloorNumber)
            {
                _floorsToGo.Remove(_floorsToGo.ElementAt(0));
                CabinIsStopped();
                CabinDoorIsOpening();
            }
        }

        public void CabinOnFloorWhenIdle(int _) =>
            throw new Exception("Sensor de cabina desincronizado");

        public void CabinDoorOpenendWhenWorking() =>
            _cabinState.State.CabinDoorOpenedWhenWorking();

        public void CabinDoorOpenedWhenWorkingAndCabinStopped()
        {
            CabinDoorIsOpened();
            if (HasFloorToGo())
            {
                CabinIsWaitingForPeople();
            }
            else
            {
                ControllerStateIsIdle();
            }
        }

        private void ControllerStateIsIdle() =>
            _state = new ElevatorControllerIdleState(this);

        private bool HasFloorToGo() => _floorsToGo.Count > 0;

        public void OpenCabinDoorWhenIdle()
        {
            //No hago nada porque me pidieron abrir la puerta cuando no estoy haciendo nada
            //y en ese caso ya está abierta
        }

        public void OpenCabinDoorWhenWorking() =>
            _cabinState.State.OpenCabinDoorWhenWorking();

        public void OpenCabinDoorWhenWorkingAndCabinStopped() =>
            _doorState.State.OpenCabinDoorWhenWorkingAndCabinStopped();

        public void OpenCabinDoorWhenWorkingAndCabinStoppedAndDoorClosing() =>
            CabinDoorIsOpening();

        public void OpenCabinDoorWhenWorkingAndCabinMoving()
        {
            //No puedo abrir la puerta porque la cabina se está moviendo!
        }

        public void OpenCabinDoorWhenWorkingAndCabinStoppedAndCabinDoorOpening()
        {
            //Ya se está abriendo!! no tengo que hacer nada
        }

        public void GoUpPushedFromFloorWhenWorking(int aFloorNumber) =>
            _floorsToGo.Add(aFloorNumber);

        public void WaitForPeopleTimedOutWhenWorking() =>
            _cabinState.State.WaitForPeopleTimedOutWhenWorking();

        public void WaitForPeopleTimedOutWhenWorkingAndCabinWaitingForPeople()
        {
            CabinIsStopped();
            CabinDoorIsClosing();
        }

        public void CloseCabinDoorWhenWorking() =>
            _cabinState.State.CloseCabinDoorWhenWorking();

        public void CloseCabinDoorWhenWorkingAndCabinWaitingForPeople() =>
            WaitForPeopleTimedOutWhenWorkingAndCabinWaitingForPeople();

        public void CloseCabinDoorWhenIdle()
        {
            //No estoy haciendo nada y me piden cerrar la puerta, por lo tanto no la 
            //cierro porque no tengo que mover la cabina puesto que estoy idle
        }

        public void CloseCabinDoorWhenWorkingAndCabinMoving()
        {
            //Si la cabina se está moviendo, la puerta ya está cerrada, por lo tanto
            //no tengo que volver a cerrarla
        }

        public void CloseCabinDoorWhenWorkingAndCabinStopped() =>
            _doorState.State.CloseCabinDoorWhenWorkingAndCabinStopped();

        public void CloseCabinDoorWhenWorkingAndCabinStoppedAndCabinDoorOpening()
        {
            //Estoy abriendo la puerta para que suba gente y me piden cerrarla. 
            //No la cierro hasta no abrir completamente la puerta
        }

        public void CabinDoorClosedWhenIdle() =>
            throw new Exception("Sensor de puerta desincronizado");

        public void CabinDoorClosedWhenWorkingAndCabinMoving() =>
            throw new Exception("Sensor de puerta desincronizado");

        public void CabinDoorClosedWhenWorkingAndCabinStoppedAndCabinDoorOpening() =>
            throw new Exception("Sensor de puerta desincronizado");

        public void AddCabinObserver(Observer<CabinState> observer) =>
            _cabinState.AddObserver(observer);

        public void AddCabinDoorObserver(Observer<CabinDoorState> observer) =>
            _doorState.AddObserver(observer);
    }
}