using System;
using System.Collections.Generic;
using ElevatorChallenge.Models;

namespace ElevatorChallenge.Controller
{
    // Define the elevator controller class
    public class ElevatorController
    {
        public List<Elevator> Elevators { get; set; }
        public int NumberOfFloors { get; set; }

        // Initialize the elevator controller with the number of floors and elevators
        public ElevatorController(int numberOfFloors, int numberOfElevators)
        {
            this.NumberOfFloors = numberOfFloors;
            this.Elevators = new List<Elevator>();

            for (int i = 0; i < numberOfElevators; i++)
            {
                this.Elevators.Add(new Elevator
                {
                    Id = i + 1,
                    CurrentFloor = 1,
                    IsMoving = false,
                    Direction = Direction.Up,
                    Capacity = 10,
                    NumberOfPeople = 0,
                    Weight = 0
                });
            }
        }

        // Get the nearest elevator that can service a specific floor
        public Elevator GetNearestElevator(int floor, int weight)
        {
            Elevator nearestElevator = null;
            int minDistance = int.MaxValue;

            foreach (var elevator in this.Elevators)
            {
                if (!elevator.IsMoving && elevator.Weight + weight <= elevator.Capacity)
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

        // Call an elevator to a specific floor
        public void CallElevator(int floor, int numberOfPeople, int weight)
        {
            Elevator nearestElevator = GetNearestElevator(floor, weight);

            if (nearestElevator != null)
            {
                nearestElevator.MoveTo(floor);
                nearestElevator.NumberOfPeople = numberOfPeople;
                nearestElevator.Weight += weight;

                Console.WriteLine($"Elevator {nearestElevator.Id} has arrived at floor {floor} and picked up {numberOfPeople} people with a weight of {weight}");
            }
            else
            {
                Console.WriteLine($"No available elevator for floor {floor}");
            }
        }

        // Display the status of all elevators
        public void DisplayStatus()
        {
            foreach (var elevator in this.Elevators)
            {
                Console.WriteLine($"Elevator {elevator.Id} is on floor {elevator.CurrentFloor} and is {(elevator.IsMoving ? "moving" : "not moving")}. It has {elevator.NumberOfPeople} people and a weight of {elevator.Weight} out of a capacity of {elevator.Capacity}.");
            }
        }
    }
}
