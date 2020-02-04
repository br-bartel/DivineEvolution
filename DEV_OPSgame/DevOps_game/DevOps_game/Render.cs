using System;
using System.Collections.Generic;
using System.Text;

namespace DevOps_game
{
    static class Render
    {
        internal static int verticalSlice;
        internal static int horizSlice;
        static Dictionary<string, List<string>> displayText = new Dictionary<string, List<string>>();
        private static void StoryDisplay(int rightEdge, int bottomEdge, List<string> story, int i)
        {
            string[] lines = story[i]
                                .Replace("\t", new String(' ', 8))
                                .Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for (int index = 0; index < lines.Length; index++)
            {
                string process = lines[index];
                List<String> wrapped = new List<string>();

                while (process.Length > rightEdge)
                {
                    int wrapAt = process.LastIndexOf(' ', Math.Min(rightEdge - 1, process.Length));
                    if (wrapAt <= 0) break;

                    wrapped.Add(process.Substring(0, wrapAt));
                    process = process.Remove(0, wrapAt + 1);
                }

                foreach (string wrap in wrapped)
                {
                    Console.WriteLine(wrap);
                }

                Console.WriteLine(process);
            }    
        }
        private static void FlavorDisplay(int rightEdge, int topEdge, List<string> flavor, int i)
        {
            Console.SetCursorPosition(0, topEdge + 1);
            string[] lines = flavor[i]
                                .Replace("\t", new String(' ', 8))
                                .Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for (int index = 0; index < lines.Length; index++)
            {
                string process = lines[index];
                List<String> wrapped = new List<string>();

                while (process.Length > rightEdge)
                {
                    int wrapAt = process.LastIndexOf(' ', Math.Min(rightEdge - 1, process.Length));
                    if (wrapAt <= 0) break;

                    wrapped.Add(process.Substring(0, wrapAt));
                    process = process.Remove(0, wrapAt + 1);
                }

                foreach (string wrap in wrapped)
                {
                    Console.WriteLine(wrap);
                }

                Console.WriteLine(process);
            }
        }

        private static void MapDisplay(int leftEdge, int bottomEdge)
        {

        }

        private static void StatusDisplay(int leftEdge, int topEdge)
        {
            Console.SetCursorPosition(leftEdge + 2, topEdge);
            Console.WriteLine($"{Game.currentState.playerName}'s Current Status:");
            Console.SetCursorPosition(leftEdge + 2, topEdge + 1);
            Console.WriteLine($"Date: ???"); // will need to add date to state
        }

        internal static void MainScreen(Dictionary<string, List<string>> text)
        {
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            verticalSlice = (windowWidth * 2 / 3);
            horizSlice = windowHeight / 2 + 2;
            displayText = text;           
            if (Game.input == "next") 
            {
                if (text["flavor"].Count > Game.fIndex)
                {
                    Game.fIndex++;
                } else if (text["story"].Count > Game.sIndex)
                {
                    Game.sIndex++;
                }
            }

            StoryDisplay(verticalSlice, horizSlice, text["story"], Game.sIndex - 1);
            FlavorDisplay(verticalSlice, horizSlice + 1, text["flavor"], Game.fIndex - 1); // positions below break
            MapDisplay(verticalSlice, horizSlice);
            StatusDisplay(verticalSlice, horizSlice + 1); // positions below break
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, horizSlice);
                Console.Write("-");
            }
            for (int j = 0; j < Console.WindowHeight; j++)
            {
                Console.SetCursorPosition(verticalSlice, j);
                Console.Write("|");
            }
        }
    }
}
