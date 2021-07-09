using System;

namespace ToyRobot.Environment
{
    public class Map: IMap
    {
        public int Width {get; set; }
        public int Height {get; set; }

        // Constructs the Map
        public Map(int width, int height)
        {
            Width = width;
            Height = height;
        }

        // Checks if collision with boundaries of the Map (Called when Robot moves)
        public bool IsCollision(int xPosition, int yPosition, string currentDirection)
        {
            bool isCollision = false;

            // Detects North Boundary Collision 
            if(currentDirection.Equals("NORTH"))
            {
                if(yPosition++ >= Height)
                {
                    isCollision = true;
                }
            }

            // Detects East Boundary Collision 
            if(currentDirection.Equals("EAST"))
            {
                if(xPosition++ >= Width )
                {
                    isCollision = true;
                }
            }

            // Detects South Boundary Collision 
            if(currentDirection.Equals("SOUTH"))
            {
                if(yPosition-- <= 0)
                {
                    isCollision = true;
                }
            }

            // Detects West Boundary Collision 
            if(currentDirection.Equals("WEST"))
            {
                if(xPosition-- <= 0 )
                {
                    isCollision = true;
                }
            }
            return isCollision;
        }
    }
}
