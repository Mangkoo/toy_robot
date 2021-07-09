using System;
using System.Linq;
using System.Collections.Generic;
using ToyRobot.Player;
using ToyRobot.Environment;

namespace ToyRobot.Game
{
    public class GameInstance
    {

        // Game Config - Change Size of the Map, cardinal directions, turning directions
        private string[] cardinalDirections = {"NORTH", "EAST", "SOUTH", "WEST"};
        private string[] turnDirections = {"RIGHT", "LEFT"};
        private int mapWidth = 5;
        private int mapHeight = 5;
        private bool robotPlaced = false;

        // Robot Default Values
        private int xPosition;
        private int yPosition;
        private string currentDirection;
        private bool userQuit = false;


        public GameInstance()
        {
        }

        public void Run()
        {
            // Allows Test commands to be passed in by automated testing
            string testCommands = null;

            // Main menu that prompts user to place the Robot on the Map 
            MainMenu(testCommands);

            if(!userQuit)
            {
                // Creates the Robot & Game Map with Values provided
                var robot = new Robot(xPosition, yPosition, currentDirection, new Environment.Map(mapWidth, mapHeight));  

                // Game Menu that persists as the Player moves the Robot
                GameInterface(robot, testCommands);
            }
           
        }

        // Main menu that prompts user to place the Robot on the Map 
        public bool MainMenu(string testCommands)
        {
            Console.Clear();
            Console.WriteLine("☼ Welcome to the ToyRobot Game!\n");
            Console.WriteLine($"The Map size is [{mapWidth} x {mapHeight}], please place your Robot on the Map using the PLACE command!\n");
            Console.WriteLine("Commands:\n");
            Console.WriteLine("■ PLACE <x>, <y>, <direction>");
            Console.WriteLine("Places the Robot on the Map, Example: PLACE 0, 2, NORTH\n");
            Console.WriteLine("■ EXIT");
            Console.WriteLine("Exit Game\n");

          while(!robotPlaced)
            {
                PlaceRobot(testCommands);
            }
            return robotPlaced;
        }
    
        // Game Interface that persists as the Player moves the Robot
        public void GameInterface(IRobot robot, string testCommands)
        {
            Console.Clear();
            Console.WriteLine($"▼ Your Robot has been placed at: [{xPosition}, {yPosition}], facing: {currentDirection}\n");
            Console.WriteLine("Commands:\n");
            Console.WriteLine("■ MOVE");
            Console.WriteLine("Moves Robot 1 Space in facing direction\n");
            Console.WriteLine("■ TURN <direction>");
            Console.WriteLine("Rotate the Robot 90° either RIGHT or LEFT\n");
            Console.WriteLine("■ REPORT");
            Console.WriteLine("Display the current postion of the Robot\n");
            Console.WriteLine("■ EXIT");
            Console.WriteLine("Exit Game\n");

            while(!userQuit)
            {
                InteractRobot(robot, testCommands);
            }
        }


        // Interface for user to place the Robot on the Map
        public bool PlaceRobot(string testCommands)
        {

            List<string> commandList = new List<string>();

            if(testCommands != null)
            {
                // Takes Test input and creates a list
                commandList = testCommands.ToUpper().Split(' ').ToList();
                Console.WriteLine("Test commands detected");
            }
            else
            {
                // Takes User input and creates a list 
                commandList = Console.ReadLine().ToUpper().Split(' ').ToList();
                Console.WriteLine("No test commands detected");
            }
                    
            switch (commandList[0])
            {
                case "EXIT":
                Console.WriteLine("» Exiting Applicaiton.");
                userQuit = true;
                return false;

                case "PLACE":
                try
                {
                    // Cleanup & Parse Place command data
                    xPosition = int.Parse(commandList[1].Replace(",","").Trim());
                    yPosition = int.Parse(commandList[2].Replace(",","").Trim());
                    currentDirection = commandList[3].Trim();

                    // Makes sure command adheres to Directions and Map geometry 
                    if(cardinalDirections.Contains(currentDirection) && ((xPosition <= mapWidth && xPosition >=0 ) && (yPosition <= mapHeight && yPosition >=0 )) )
                    {
                        robotPlaced = true;
                        return robotPlaced;
                          
                    }
                    else 
                    {
                        Console.WriteLine("Invalid command, please ensure that the Robot is being placed on the Map, facing either NORTH, EAST, SOUTH or WEST!\n");
                        //return false;
                    } 
                  }

                catch(Exception)
                {
                    Console.WriteLine("Invalid PLACE command, please refer to example!\n");
                    //return false;
                }
                break;

                default:
                Console.WriteLine("Please enter a valid command!\n");
                break;
            }

            return robotPlaced;
        }
            
        public bool InteractRobot(IRobot robot, string testCommands)
        {
            bool successfulInteraction = false;

            // Takes User input and creates a list
            var commandList = Console.ReadLine().ToUpper().Split(' ').ToList();

            switch (commandList[0])
            {
                case "EXIT":
                Console.WriteLine("\n» Exiting Applicaiton.");
                successfulInteraction = true;
                userQuit = true;
                break;

                case "MOVE":
                robot.Move();
                successfulInteraction = true;
                break;

                case "REPORT":
                robot.Report();
                successfulInteraction = true;
                break;

                case "TURN":
                try
                {
                    string turnDirection = commandList[1];
                    if(turnDirections.Contains(turnDirection))
                    {
                        
                        robot.Turn(turnDirection);
                        successfulInteraction = true;
                    }
                    else
                    {
                        Console.WriteLine("Please sepecify either LEFT or RIGHT turn directions!\n");
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Invalid TURN command, please specify either RIGHT or LEFT!\n");
                }
                break;

                default: 
                Console.WriteLine("Unrecognized Command, please use a command from the list above!\n");
                break;
            }  
            return successfulInteraction;
            
        }
    }
    
}
