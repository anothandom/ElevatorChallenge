using System.Collections.Generic;
using ElevatorChallenge.Models;
using System;

namespace ElevatorChallenge.Interfaces
{
    public interface IElevatorService
    {
        void CallElevator(int floor, int numberOfPeople, int weight);
        void DisplayStatus();
    }
   
}
