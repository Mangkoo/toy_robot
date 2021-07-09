using System;
using ToyRobot.Environment;

namespace ToyRobot.Player
{
    public interface IRobot
    {
        int XPosition {get; set;}
        int YPosition {get; set;}
        string CurrentDirection {get; set;}
        IMap Map{get; set;}
        void Move();
        void Turn(string turnDirection);

        void Report();
    }

    

}
