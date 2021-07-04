using System;

namespace ElevatorExercise.Logic
{
    public class ElevatorEmergency : Exception
    {
        public ElevatorEmergency(string message) : base(message)
        {
        }
    }
}