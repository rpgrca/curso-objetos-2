using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinDoorClosingState: CabinDoorState
    {
        private ElevatorController elevatorController;
	
	    public CabinDoorClosingState(ElevatorController elevatorController) {
		    this.elevatorController = elevatorController;
	    }
	    
	    public bool isOpened() {
		    return false;
	    }

	    
	    public bool isOpening() {
		    return false;
	    }

	    
	    public bool isClosing() {
		    return true;
	    }

	    
	    public bool isClosed() {
		    return false;
	    }

	    
	    public void cabinDoorClosedWhenWorkingAndCabinStopped() {
		    elevatorController.cabinDoorClosedWhenWorkingAndCabinStoppedAndClosing();
	    }

	    
	    public void openCabinDoorWhenWorkingAndCabinStopped() {
		    elevatorController.openCabinDoorWhenWorkingAndCabinStoppedAndDoorClosing();
	    }

	    
	    public void closeCabinDoorWhenWorkingAndCabinStopped() {
		    throw new Exception();
	    }

	    
	    public void accept(CabinDoorStateVisitor visitor) {
		    visitor.visitCabinDoorClosing(this);
	    }
    }
}
