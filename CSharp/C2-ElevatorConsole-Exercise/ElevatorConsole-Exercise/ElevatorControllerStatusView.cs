using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorConsole_Exercise
{
    class ElevatorControllerStatusView: CabinStateVisitor, CabinDoorStateVisitor
    {
	    private string m_cabinFieldModel;
	    private string m_cabinDoorFieldModel;

	    public ElevatorControllerStatusView(ElevatorController elevatorController) {
			elevatorController.addCabinObserver(this);
			elevatorController.addCabinDoorObserver(this);
	    }

	    protected void cabinDoorStateChangedTo(CabinDoorState cabinDoorState) {
		    cabinDoorState.accept(this);
	    }

	    protected void cabinStateChangedTo(CabinState cabinState) {
		    cabinState.accept(this);
	    }

	    
	    public void visitCabinDoorClosing(CabinDoorClosingState cabinDoorClosingState) {
		    m_cabinDoorFieldModel = "Closing";
	    }

	    
	    public void visitCabinDoorClosed(CabinDoorClosedState cabinDoorClosedState) {
		    m_cabinDoorFieldModel = "Closed";
	    }

	    
	    public void visitCabinDoorOpened(CabinDoorOpenedState cabinDoorOpenedState) {
		    m_cabinDoorFieldModel = "Open";
	    }

	    
	    public void visitCabinDoorOpening(CabinDoorOpeningState cabinDoorOpeningState) {
		    m_cabinDoorFieldModel = "Opening";
	    }

	    
	    public void visitCabinMoving(CabinMovingState cabinMovingState) {
		    m_cabinFieldModel = "Moving";
	    }

	    
	    public void visitCabinStopped(CabinStoppedState cabinStoppedState) {
		    m_cabinFieldModel = "Stopped";
	    }

	    
	    public void visitCabinWaitingPeople(CabinWaitingForPeopleState cabinWaitingForPeopleState) {
		    m_cabinFieldModel = "Waiting People";
	    }

	    public string cabinFieldModel() {
		    return m_cabinFieldModel;
	    }

	    public string cabinDoorFieldModel() {
		    return m_cabinDoorFieldModel;
	    }
    }
}
