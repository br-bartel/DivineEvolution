using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DevOps_game
{
    static class Game
    {
        /// <summary>
        /// State field containing all state related variables
        /// </summary>
        public static State currentState;
        /// <summary>
        /// Field that holds user input
        /// </summary>
        public static string input = "";


        public static string previousInput = "";
        public static int sIndex = 1;
        public static int fIndex = 1;

        static bool gameOver = false; // control for the game loop, will break loop if set to true
        /// <summary>
        /// Starts the game, initializes currentState, and contains the game loop
        /// </summary>
        internal static void startGame()
        {
            World.Add("Docks", new Docks());

            currentState = new State();

            while (gameOver != true)
            {
                gameLoop();
            }
        }

        private static void gameLoop() // method inside game control loop
        {
            displayText(input);
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine(input);
            Console.Write("> ");
            previousInput = (input == "next" || (input == "help" || input == "?" || input == "h")) ? previousInput : input;
            input = Console.ReadLine(); // reads for user input
            
            if (currentState.playerName == "") // for first scene, assign player name
            {
                currentState.playerName = input;
            }

            input = input.ToLower(); // could maybe make turnary operator?

        }
        private static void displayText(string playerInput)
        {
            Console.Clear();
            Render.MainScreen(World[currentState.location].chooseText(playerInput));            
        }
        internal static List<string> checker(Dictionary<string, List<string>> inputs)
        {
            string currentInput = (input == "next") ? previousInput : input;
            bool isValid = inputs.ContainsKey(currentInput); // checks if user input matches one of the defined value keys, returns true or false

            if (isValid)
            {
                InvalidEntry.InvalidCount = 0; // reset the counter for the invalid method
                return inputs[currentInput]; // return the value of the selected key
            }            
            else if ((currentState.playerName == currentInput && currentState.cycle == 1) || input == "next")
            {
                return new List<string>() { "" };
            }
            else
            {
                return new List<string>() {InvalidEntry.Invalid()}; // executes the invalid method that returns the error text
            }
        }
        /// <summary>
        /// Contains a KVP of the places in the world
        /// </summary>
        public static Dictionary<string, Location> World = new Dictionary<string, Location>();
    }
}
