﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevOps_game
{
    internal class Map
    {
        static Dictionary<string, bool> PlacesVisited = new Dictionary<string, bool>
        {
            {"Docks", true },
            {"Town Square", false },
            {"Outskirts", false }
        };
        static readonly string DocksText = "DOCKS";
        static string TownText = "???";
        static string OutskirtsText = "???";
        static readonly List<string> TextMap = new List<string> { $"{OutskirtsText}", "/", "\\", " \\", $" {TownText}", " /", "/", "\\", $"{DocksText}" };

        /// <summary>
        /// Displays the game map. Uses the left edge of partition as starting value for setting cursor position.
        /// Also contains logic to check if locations have been visited and will update when current state updates.
        /// </summary>
        /// <param name="leftEdge"></param>
        internal static void DisplayMap(int leftEdge)
        {
            string currentLocation = Game.currentState.location;
            if (PlacesVisited.ContainsKey(currentLocation) && PlacesVisited[currentLocation] == false)
            {
                PlacesVisited[currentLocation] = true;
                if (currentLocation == "Town Square")
                {
                    TownText = "TOWN SQUARE";
                }
                else if (currentLocation == "Outskirts")
                {
                    OutskirtsText = "OUTSKIRTS";
                }
            }
            int i = 1;
            foreach  (string text in TextMap)
            {
                Console.SetCursorPosition(leftEdge, i);
                Console.WriteLine(text);
                i++;
            }
        }
    }
}