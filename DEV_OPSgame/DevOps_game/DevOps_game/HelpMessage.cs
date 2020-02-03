using System;
namespace DevOps_game
{
    public class HelpMessage
    {
        public static int helpCount;

        public static string Help()

        {

            string result = "";
            switch (helpCount)
            {
                case 0:
                    result = "Select an item to interact with by typing the text contained by one set of square brackets"; // reinforces the last message
                    helpCount++;
                    break;
                case 1:
                    result = String.Join(", ", Docks.validInputs.Keys);
                    // helpCount++;
                    helpCount = 0;
                    break;
                case 2:
                    // result = Console.ReadLine(Game.currentState.cycle); // displays the description of the last scene/evironment/location that the player
                    // is in
                    helpCount++;
                    break;
            }
            return result;

        }
    }
}
