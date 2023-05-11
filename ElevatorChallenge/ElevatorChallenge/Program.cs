using System;
using ElevatorChallenge.Controller;

namespace ElevatorChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new elevator controller with 10 floors and 2 elevators
            var elevatorController = new ElevatorController(10, 2);

            // Call elevator to floor 5 with 3 people waiting
            elevatorController.CallElevator(5, 3, 9);

            // Display the status of all elevators
            elevatorController.DisplayStatus();

            // Call elevator to floor 7 with 2 people waiting
            elevatorController.CallElevator(7, 2, 8);

            // Display the status of all elevators
            elevatorController.DisplayStatus();

            // Display the status of all elevators
            elevatorController.DisplayStatus();

            Console.ReadLine();
        }
    }
}
