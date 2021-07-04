using System;

namespace ElevatorExercise
{
    internal class ElevatorEmergency : Exception
    {
        public ElevatorEmergency(string message) : base(message)
        {
        }
    }
}
