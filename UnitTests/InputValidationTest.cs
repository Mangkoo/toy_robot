using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Game;
using ToyRobot.Player;
using ToyRobot.Environment;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CanIgnorePlacementExceedingMapBoundaries()
        {
            // Arrange - Place the robot @ 5, 5, NORTH
            var testCommands = "PLACE 5, 5, NORTH";
            var gameInstance = new GameInstance();

            // Act - Call PlaceRobot 
            var result = gameInstance.PlaceRobot(testCommands);
     
            // Assert - Verify if PlaceRobot returns true/false
            Assert.IsTrue(result);
        }
    }
}
