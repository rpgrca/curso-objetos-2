using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ElevatorConsole_Exercise
{
    public class ElevatorControllerTest
    {
        [Fact]
        public void testElevatorStartsIdleWithDoorOpenOnFloorZero()
        {
            ElevatorController elevatorController = new ElevatorController();

            Assert.True(elevatorController.isIdle());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpened());
            Assert.Equal(0, elevatorController.cabinFloorNumber());
        }

        [Fact]
        public void testCabinDoorStartsClosingWhenElevatorGetsCalled()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);

            Assert.False(elevatorController.isIdle());
            Assert.True(elevatorController.isWorking());

            Assert.True(elevatorController.isCabinStopped());
            Assert.False(elevatorController.isCabinMoving());

            Assert.False(elevatorController.isCabinDoorOpened());
            Assert.False(elevatorController.isCabinDoorOpening());
            Assert.True(elevatorController.isCabinDoorClosing());
            Assert.False(elevatorController.isCabinDoorClosed());
        }

        [Fact]
        public void testCabinStartsMovingWhenDoorGetsClosed()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();

            Assert.False(elevatorController.isIdle());
            Assert.True(elevatorController.isWorking());

            Assert.False(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinMoving());

            Assert.False(elevatorController.isCabinDoorOpened());
            Assert.False(elevatorController.isCabinDoorOpening());
            Assert.False(elevatorController.isCabinDoorClosing());
            Assert.True(elevatorController.isCabinDoorClosed());
        }

        [Fact]
        public void testCabinStopsAndStartsOpeningDoorWhenGetsToDestination()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);

            Assert.False(elevatorController.isIdle());
            Assert.True(elevatorController.isWorking());

            Assert.True(elevatorController.isCabinStopped());
            Assert.False(elevatorController.isCabinMoving());

            Assert.False(elevatorController.isCabinDoorOpened());
            Assert.True(elevatorController.isCabinDoorOpening());
            Assert.False(elevatorController.isCabinDoorClosing());
            Assert.False(elevatorController.isCabinDoorClosed());

            Assert.Equal(1, elevatorController.cabinFloorNumber());
        }

        [Fact]
        public void testElevatorGetsIdleWhenDoorGetOpened()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);
            elevatorController.cabinDoorOpened();

            Assert.True(elevatorController.isIdle());
            Assert.False(elevatorController.isWorking());

            Assert.True(elevatorController.isCabinStopped());
            Assert.False(elevatorController.isCabinMoving());

            Assert.True(elevatorController.isCabinDoorOpened());
            Assert.False(elevatorController.isCabinDoorOpening());
            Assert.False(elevatorController.isCabinDoorClosing());
            Assert.False(elevatorController.isCabinDoorClosed());

            Assert.Equal(1, elevatorController.cabinFloorNumber());
        }

        // STOP HERE!

        [Fact]
        public void testDoorKeepsOpenedWhenOpeningIsRequested()
        {
            ElevatorController elevatorController = new ElevatorController();

            Assert.True(elevatorController.isCabinDoorOpened());

            elevatorController.openCabinDoor();

            Assert.True(elevatorController.isCabinDoorOpened());

        }

        [Fact]
        public void testDoorMustBeOpenedWhenCabinIsStoppedAndClosingDoors()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorClosing());

            elevatorController.openCabinDoor();
            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());
        }

        [Fact]
        public void testCanNotOpenDoorWhenCabinIsMoving()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinMoving());
            Assert.True(elevatorController.isCabinDoorClosed());

            elevatorController.openCabinDoor();
            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinMoving());
            Assert.True(elevatorController.isCabinDoorClosed());
        }

        [Fact]
        public void testDoorKeepsOpeneingWhenItIsOpeneing()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());

            elevatorController.openCabinDoor();
            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());
        }

        // STOP HERE!!

        [Fact]
        public void testRequestToGoUpAreEnqueueWhenRequestedWhenCabinIsMoving()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);
            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinDoorOpened();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinWaitingForPeople());
            Assert.True(elevatorController.isCabinDoorOpened());
        }

        [Fact]
        public void testCabinDoorStartClosingAfterWaitingForPeople()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);
            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinDoorOpened();
            elevatorController.waitForPeopleTimedOut();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorClosing());
        }

        [Fact]
        public void testStopsWaitingForPeopleIfCloseDoorIsPressed()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);
            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinDoorOpened();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinWaitingForPeople());
            Assert.True(elevatorController.isCabinDoorOpened());

            elevatorController.closeCabinDoor();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorClosing());

        }

        [Fact]
        public void testCloseDoorDoesNothingIfIdle()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.closeCabinDoor();

            Assert.True(elevatorController.isIdle());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpened());

        }

        [Fact]
        public void testCloseDoorDoesNothingWhenCabinIsMoving()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinMoving());
            Assert.True(elevatorController.isCabinDoorClosed());

            elevatorController.closeCabinDoor();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinMoving());
            Assert.True(elevatorController.isCabinDoorClosed());
        }

        [Fact]
        public void testCloseDoorDoesNothingWhenOpeningTheDoorToWaitForPeople()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());

            elevatorController.closeCabinDoor();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());

        }

        // STOP HERE!!

        [Fact]
        public void testElevatorHasToEnterEmergencyIfStoppedAndOtherFloorSensorTurnsOn()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);
            try
            {
                elevatorController.cabinOnFloor(0);
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de cabina desincronizado");
            }
        }

        [Fact]
        public void testElevatorHasToEnterEmergencyIfFalling()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);
            try
            {
                elevatorController.cabinOnFloor(0);
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de cabina desincronizado");
            }
        }

        [Fact]
        public void testElevatorHasToEnterEmergencyIfJumpsFloors()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(3);
            elevatorController.cabinDoorClosed();
            try
            {
                elevatorController.cabinOnFloor(3);
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de cabina desincronizado");
            }
        }

        [Fact]
        public void testElevatorHasToEnterEmergencyIfDoorClosesAutomatically()
        {
            ElevatorController elevatorController = new ElevatorController();

            try
            {
                elevatorController.cabinDoorClosed();
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de puerta desincronizado");
            }
        }

        [Fact]
        public void testElevatorHasToEnterEmergencyIfDoorClosedSensorTurnsOnWhenClosed()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            try
            {
                elevatorController.cabinDoorClosed();
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de puerta desincronizado");
            }
        }

        [Fact]
        public void testElevatorHasToEnterEmergencyIfDoorClosesWhenOpening()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);
            try
            {
                elevatorController.cabinDoorClosed();
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de puerta desincronizado");
            }
        }

        // STOP HERE!!
        // More tests here to verify bad sensor function

        [Fact]
        public void testCabinHasToStopOnTheFloorsOnItsWay()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinOnFloor(1);

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());
        }

        [Fact]
        public void testElevatorCompletesAllTheRequests()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinOnFloor(1);
            elevatorController.cabinDoorOpened();
            elevatorController.waitForPeopleTimedOut();
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(2);

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());
        }

        [Fact]
        public void testCabinHasToStopOnFloorsOnItsWayNoMatterHowTheyWellCalled()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinDoorClosed();
            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinOnFloor(1);

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());
        }

        [Fact]
        public void testCabinHasToStopAndWaitForPeopleOnFloorsOnItsWayNoMatterHowTheyWellCalled()
        {
            ElevatorController elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinDoorClosed();
            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinOnFloor(1);
            elevatorController.cabinDoorOpened();
            elevatorController.waitForPeopleTimedOut();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorClosing());
        }
    }
}
