using System;
using System.Collections.Generic;

namespace DevOps_game
{
    class Game
    {


        static void Main(string[] args)
        {
            startGame();

        }

        static bool gameOver = false;

        private static void gameLoop()
        {
            displayText();
            string input = Console.ReadLine();

        }
        private static void startGame()
        {
            World.Add("Docks", new Location());

            while (gameOver != true)
            {
                gameLoop();
            }
        }
        private static void displayText()
            {
            Console.WriteLine("Test");
            }


        public static Dictionary<string, Location> World = new Dictionary<string, Location>();


        public /*abstract*/ class Location
        {

            List <string>  validInputs = new List<string>();

           // public abstract void chooseText();
          

        }

     

        public class State
        {
            int cycle;
            string location;
            Dictionary <string, bool> Conditions;
        }
    }
}
