using System;

namespace ToyRobot.Environment
{
    public interface IMap
    {
        int Width {get; set;}
        int Height {get; set;}
        bool IsCollision(int xPosition, int yPosition, string currentDirection);

    }

}
