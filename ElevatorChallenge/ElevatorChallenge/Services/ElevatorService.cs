using System;
using System.Collections.Generic;
using ElevatorChallenge.Models;

namespace ElevatorChallenge.Services
{
    public interface IElevatorService
    {
        void CallElevator(int floor, int numberOfPeople);
        void DisplayStatus();
    }

    public class ElevatorService : IElevatorService
    {
        private readonly List<Elevator> _elevators;
        private readonly int _numberOfFloors;

        public ElevatorService(int numberOfFloors, int numberOfElevators)
        {
            _numberOfFloors = numberOfFloors;
            _elevators = new List<Elevator>();

            for (int i = 0; i < numberOfElevators; i++)
            {
                _elevators.Add(new Elevator
                {
                    Id = i + 1,
                    CurrentFloor = 1,
                    IsMoving = false,
                    Direction = Direction.Up,
                    Capacity = 10,
                    NumberOfPeople = 0
                });
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
            foreach (var elevator in _elevators)
            {
                Console.WriteLine($"Elevator {elevator.Id} is on floor {elevator.CurrentFloor} and is {(elevator.IsMoving ? $"moving {elevator.Direction}" : "idle")} with {elevator.NumberOfPeople} people");
            }
        }

        private Elevator GetNearestElevator(int floor)
        {
            Elevator nearestElevator = null;
            int minDistance = int.MaxValue;

            foreach (var elevator in _elevators)
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
