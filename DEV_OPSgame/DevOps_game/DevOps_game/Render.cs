using System;
using System.Collections.Generic;
using System.Text;

namespace DevOps_game
{
    static class Render
    {
        internal static int verticalSlice;
        internal static int horizSlice;
        static List<string> displayText = new List<string>();
        private static void StoryDisplay(int rightEdge, int bottomEdge)
        {
            int i = 0;
            while (i < displayText.Count)
            {
                string[] lines = displayText[i]
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
                i++;
            }
        }
        private static void FlavorDisplay(int rightEdge, int topEdge)
        {

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

        internal static void MainScreen(List<string> text)
        {
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            verticalSlice = (windowWidth * 2 / 3);
            horizSlice = windowHeight / 2 + 2;
            displayText = text;
            StoryDisplay(verticalSlice, horizSlice);
            FlavorDisplay(verticalSlice, horizSlice + 1); // positions below break
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
