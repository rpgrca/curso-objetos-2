using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorConsole_Exercise
{
    class ElevatorControllerConsole : CabinStateVisitor, CabinDoorStateVisitor
    {
	    private List<String> console;

	    public ElevatorControllerConsole(ElevatorController elevatorController) {
            console = new List<String>();
	    }

	    protected void cabinDoorStateChangedTo(CabinDoorState cabinDoorState) {
		    cabinDoorState.accept(this);
	    }

	    protected void cabinStateChangedTo(CabinState cabinState) {
		    cabinState.accept(this);
	    }

	    public IEnumerator<String> consoleReader() {
		    return console.GetEnumerator();
	    }

	    public void visitCabinMoving(CabinMovingState cabinMovingState) {
		    console.Add("Cabina Moviendose");
	    }

	    public void visitCabinStopped(CabinStoppedState cabinStoppedState) {
		    console.Add("Cabina Detenida");
	    }

	    public void visitCabinWaitingPeople(CabinWaitingForPeopleState cabinWaitingForPeopleState) {
		    console.Add("Cabina Esperando Gente");
	    }

	    public void visitCabinDoorClosing(CabinDoorClosingState cabinDoorClosingState) {
		    console.Add("Puerta Cerrandose");
	    }

	    public void visitCabinDoorClosed(CabinDoorClosedState cabinDoorClosedState) {
		    console.Add("Puerta Cerrada");
	    }

	    public void visitCabinDoorOpened(CabinDoorOpenedState cabinDoorOpenedState) {
		    console.Add("Puerta Abierta");
	    }

	    public void visitCabinDoorOpening(CabinDoorOpeningState cabinDoorOpeningState) {
		    console.Add("Puerta Abriendose");
	    }
    }
}
