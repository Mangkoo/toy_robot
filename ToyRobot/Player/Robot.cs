using System;
using ToyRobot.Environment;

namespace ToyRobot.Player
{
    public class Robot : IRobot
    {
        public int XPosition {get; set; }
        public int YPosition {get; set;}
        public IMap Map{get; set;}
        public string CurrentDirection {get; set;}

        // Construct The Robot & The Map
        public Robot(int xPosition, int yPosition, string currentDirection, IMap map)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            CurrentDirection = currentDirection;
            Map = map;
        }

        // Move the Robot 1 space in the direction currently facing 
        public void Move()
        {
            // If the Robot collides with the edge of map, move operation is ignored
            if(Map.IsCollision(XPosition, YPosition, CurrentDirection))
            {
                Console.WriteLine($"Whoops, you've hit the edge of the map while trying to travel {CurrentDirection}, turn around!\n");
                return;
            }

            // Robot will move according to current direction
            switch (CurrentDirection)
            {
                case "NORTH":
                YPosition++;
                break;

                case "EAST":
                XPosition++;
                break;

                case "SOUTH":
                YPosition--;
                break;

                case "WEST":
                XPosition--;
                break; 
            }
            Console.WriteLine($"Robot has moved {CurrentDirection} 1 square!\n"); 
        }


        // Turn Robot to either left or right
        public void Turn(string turnDirection)
        {   
            if(turnDirection.Equals("RIGHT"))
            {   
                switch(CurrentDirection)
                {
                    case "NORTH":
                    CurrentDirection = "EAST";
                    break;

                    case "EAST":
                    CurrentDirection = "SOUTH";
                    break;

                    case "SOUTH":
                    CurrentDirection = "WEST";
                    break;

                    case "WEST":
                    CurrentDirection = "NORTH";
                    break;
                }
            } 
            else
            {
                switch(CurrentDirection)
                {
                    case "NORTH":
                    CurrentDirection = "WEST";
                    break;

                    case "EAST":
                    CurrentDirection = "NORTH";
                    break;

                    case "SOUTH":
                    CurrentDirection = "EAST";
                    break;

                    case "WEST":
                    CurrentDirection = "SOUTH";
                    break;
                }
            }
            Console.WriteLine($"Robot is now facing {CurrentDirection}!\n");
        }


        
        // Display Robot's current X, Y coordinates as well as currently facing direction 
        public void Report()
        {
            Console.WriteLine($"▼ Your Robot is currently at: [{XPosition}, {YPosition}], facing: {CurrentDirection} \n");
        }

    }
}
