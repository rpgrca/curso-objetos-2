using System.Collections.Generic;

namespace ElevatorConsole_Exercise
{
	interface ElevatorControllerVisitor : CabinStateVisitor, CabinDoorStateVisitor
	{
	}

    class ElevatorControllerDummy : ElevatorControllerVisitor
    {
        public void visitCabinDoorClosed(CabinDoorClosedState cabinDoorClosedState)
        {
        }

        public void visitCabinDoorClosing(CabinDoorClosingState cabindDoorClosingState)
        {
        }

        public void visitCabinDoorOpened(CabinDoorOpenedState cabinDoorOpenedState)
        {
        }

        public void visitCabinDoorOpening(CabinDoorOpeningState cabinDoorOpeningState)
        {
        }

        public void visitCabinMoving(CabinMovingState cabinMovingState)
        {
        }

        public void visitCabinStopped(CabinStoppedState cabinStoppedState)
        {
        }

        public void visitCabinWaitingPeople(CabinWaitingForPeopleState cabinWaitingForPeopleState)
        {
        }
    }

    class ElevatorControllerConsole : ElevatorControllerVisitor
    {
	    private readonly List<string> _console;

        public ElevatorControllerConsole(ElevatorController elevatorController) {
            _console = new List<string>();
            elevatorController.accept(this);
        }

	    protected void cabinDoorStateChangedTo(CabinDoorState cabinDoorState) {
		    cabinDoorState.accept(this);
	    }

	    protected void cabinStateChangedTo(CabinState cabinState) {
		    cabinState.accept(this);
	    }

	    public IEnumerator<string> consoleReader() {
		    return _console.GetEnumerator();
	    }

	    public void visitCabinMoving(CabinMovingState cabinMovingState) {
		    _console.Add("Cabina Moviendose");
	    }

	    public void visitCabinStopped(CabinStoppedState cabinStoppedState) {
		    _console.Add("Cabina Detenida");
	    }

	    public void visitCabinWaitingPeople(CabinWaitingForPeopleState cabinWaitingForPeopleState) {
		    _console.Add("Cabina Esperando Gente");
	    }

	    public void visitCabinDoorClosing(CabinDoorClosingState cabinDoorClosingState) {
		    _console.Add("Puerta Cerrandose");
	    }

	    public void visitCabinDoorClosed(CabinDoorClosedState cabinDoorClosedState) {
		    _console.Add("Puerta Cerrada");
	    }

	    public void visitCabinDoorOpened(CabinDoorOpenedState cabinDoorOpenedState) {
		    _console.Add("Puerta Abierta");
	    }

	    public void visitCabinDoorOpening(CabinDoorOpeningState cabinDoorOpeningState) {
		    _console.Add("Puerta Abriendose");
	    }
    }
}
