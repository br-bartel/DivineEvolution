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
            Console.Write("> ");
            input = Console.ReadLine().ToLower(); // reads for user input
            if (currentState.playerName == "") // for first scene, assign player name
            {
                currentState.playerName = input;
            }
        }
        private static void displayText(string playerInput)
        {
            Console.Clear();
            List<string> displayText = World[currentState.location].chooseText(playerInput);
            int i = 0;
            while (i < displayText.Count)
            {
                Console.WriteLine(displayText[i]);
                //var words = displayText[i].Split("");
                //var lines = words.Skip(1).Aggregate(words.Take(1).ToList(), (l, w) =>
                //{
                //    if (l.Last().Length + w.Length >= 80)
                //        l.Add(w);
                //    else
                //        l[l.Count - 1] += " " + w;
                //    return l;
                //});
                Thread.Sleep(1000);
                i++;
            }
        }
        internal static string checker(Dictionary<string, string> inputs)
        {
            bool isValid = inputs.ContainsKey(input); // checks if user input matches one of the defined value keys, returns true or false
            if (isValid == false)
            {
                return InvalidEntry.Invalid(); // executes the invalid method that returns the error text
            }
            else if (input == currentState.playerName && currentState.cycle == 1)
            {
                return "";
            }
            else
            {
                InvalidEntry.InvalidCount = 0; // reset the counter for the invalid method
                return inputs[input]; // return the value of the selected key
            }
        }
        /// <summary>
        /// Contains a KVP of the places in the world
        /// </summary>
        public static Dictionary<string, Location> World = new Dictionary<string, Location>();
    }
}
