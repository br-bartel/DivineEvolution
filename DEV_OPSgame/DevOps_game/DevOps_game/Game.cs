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
				string[] lines = displayText[i]
									.Replace("\t", new String(' ', 8))
									.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

				for (int index = 0; index < lines.Length; index++) {
					string process = lines[index];
					List<String> wrapped = new List<string>();

					while (process.Length > Console.WindowWidth) {
						int wrapAt = process.LastIndexOf(' ', Math.Min(Console.WindowWidth - 1, process.Length));
						if (wrapAt <= 0) break;

						wrapped.Add(process.Substring(0, wrapAt));
						process = process.Remove(0, wrapAt + 1);
					}

					foreach (string wrap in wrapped) {
						Console.WriteLine(wrap);
					}

					Console.WriteLine(process);
				}
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
