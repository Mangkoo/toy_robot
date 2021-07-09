using System;

namespace ToyRobot
{

    // * Class to encapsulate the concept of the Appplicaiton 
    // Add a file reader to import and read the help file
    // Maybe a file writer to save game? 
    class Application
    {

        public Application(string[] args)
        {
        }

        // Runs the Game
        public void Run(){
            try{
                // Launch the Game
                LaunchGame();
            }
            catch (Exception e){
                Console.WriteLine($"Eception caught in Applicaiton.cs\nMessage: {e.Message}");
            }
        }

        // Instanciate the Game and run it
        private void LaunchGame(){

            var game = new Game.GameInstance();
            game.Run();
        }        
    }

}
