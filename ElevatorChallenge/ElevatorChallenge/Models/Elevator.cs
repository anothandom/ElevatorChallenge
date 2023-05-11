using System;


namespace ElevatorChallenge.Models
{
    
    // Define the elevator class
    public class Elevator
    {
        public int Id { get; set; }
        public int CurrentFloor { get; set; }
        public bool IsMoving { get; set; }
        public Direction Direction { get; set; }
        public int Capacity { get; set; }
        public int NumberOfPeople { get; set; }
        public int Weight { get; set; }

        // Move the elevator to a specific floor
        public void MoveTo(int floor)
        {
            this.IsMoving = true;
            this.Direction = floor > this.CurrentFloor ? Direction.Up : Direction.Down;

            Console.WriteLine($"Elevator {this.Id} is moving {this.Direction} to floor {floor}");

            // Simulate elevator movement
            while (this.CurrentFloor != floor)
            {
                if (this.Direction == Direction.Up)
                {
                    this.CurrentFloor++;
                }
                else
                {
                    this.CurrentFloor--;
                }

                Console.WriteLine($"Elevator {this.Id} is on floor {this.CurrentFloor}");
            }

            this.IsMoving = false;
        }
    }

    
}
