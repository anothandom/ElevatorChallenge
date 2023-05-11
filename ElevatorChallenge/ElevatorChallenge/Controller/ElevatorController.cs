using System;
using System.Collections.Generic;
using ElevatorChallenge.Models;
using ElevatorChallenge.Services;

namespace ElevatorChallenge.Controller
{
    // Define the elevator controller class
    public class ElevatorController : ElevatorService
    {
        public ElevatorController(int numberOfFloors, int numberOfElevators) : base(numberOfFloors, numberOfElevators)
        {
            
        }
    }
}
