using System.Collections.Generic;
using ElevatorChallenge.Models;
using System;

namespace ElevatorService
{
    public interface IElevatorService
    {
        void CallElevator(int floor, int numberOfPeople);
        void DisplayStatus();
    }

    public class ElevatorService : IElevatorService
    {
        private readonly List<Elevator> elevators;

        public ElevatorService(int numberOfFloors, int numberOfElevators)
        {
            elevators = new List<Elevator>();

            for (int i = 0; i < numberOfElevators; i++)
            {
                elevators.Add(new Elevator());
            }
        }

        public void CallElevator(int floor, int numberOfPeople)
        {
            Elevator nearestElevator = GetNearestElevator(floor);

            if (nearestElevator != null)
            {
                nearestElevator.MoveTo(floor);
                nearestElevator.NumberOfPeople = numberOfPeople;

                Console.WriteLine($"Elevator {nearestElevator.Id} has arrived at floor {floor} and picked up {numberOfPeople} people");
            }
            else
            {
                Console.WriteLine($"No available elevator for floor {floor}");
            }
        }

        public void DisplayStatus()
        {
            foreach (var elevator in elevators)
            {
                Console.WriteLine($"Elevator {elevator.Id} is on floor {elevator.CurrentFloor} and is {(elevator.IsMoving ? $"moving {elevator.Direction}" : "not moving")} with {elevator.NumberOfPeople} people");
            }
        }

        private Elevator GetNearestElevator(int floor)
        {
            Elevator nearestElevator = null;
            int minDistance = int.MaxValue;

            foreach (var elevator in elevators)
            {
                if (!elevator.IsMoving)
                {
                    int distance = Math.Abs(elevator.CurrentFloor - floor);

                    if (distance < minDistance)
                    {
                        nearestElevator = elevator;
                        minDistance = distance;
                    }
                }
            }

            return nearestElevator;
        }
    }
}
