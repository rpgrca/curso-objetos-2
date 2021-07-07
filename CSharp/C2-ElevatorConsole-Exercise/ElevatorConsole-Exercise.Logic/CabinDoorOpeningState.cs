namespace ElevatorConsole_Exercise.Logic
{
    public class CabinDoorOpeningState: CabinDoorState
    {
	    private readonly ElevatorController _elevatorController;

	    public CabinDoorOpeningState(ElevatorController elevatorController) {
		    _elevatorController = elevatorController;
	    }

	    public void cabinDoorClosedWhenWorkingAndCabinStopped() {
		    _elevatorController.cabinDoorClosedWhenWorkingAndCabinStoppedAndCabinDoorOpening();
	    }

	    public bool isClosed() {
		    return false;
	    }

	    public bool isClosing() {
		    return false;
	    }

	    public bool isOpened() {
		    return false;
	    }

	    public bool isOpening() {
		    return true;
	    }

	    public void openCabinDoorWhenWorkingAndCabinStopped() {
		    _elevatorController.openCabinDoorWhenWorkingAndCabinStoppedAndCabinDoorOpening();
	    }

	    public void closeCabinDoorWhenWorkingAndCabinStopped() {
		    _elevatorController.closeCabinDoorWhenWorkingAndCabinStoppedAndCabinDoorOpening();
	    }

	    public void accept(CabinDoorStateVisitor visitor) {
		    visitor.visitCabinDoorOpening(this);
	    }
    }
}