using System;

namespace DevOps_game
{
    /// <summary>
    /// Class that contains a method that returns a string that can be used to signify to the user that
    /// the text that they entered didn't match an expected value
    /// </summary>
    public class InvalidEntry
    {
        /// <summary>
        /// Holds the number of times that the user has entered incorrect text in a single instance.
        /// Needs to be reset to zero as a part of a conditional when used
        /// </summary>
        public static int InvalidCount;
        /// <summary>
        /// Using the InvalidCount, returns different messages intended to inform the user that
        /// they have entered an invalid choice
        /// </summary>
        /// <returns></returns>
        public static string Invalid()
        {
            string result;
            switch (InvalidCount)
            {
                case 0:
                    result = "You try, but you just can't quite do that.";
                    InvalidCount++;
                    break;
                case 1:
                    result = "You hear a myterious voice whispering to you, telling you to do something you know you can't.";
                    InvalidCount++;
                    break;
                case 2:
                    result = "The object Object.object != OBJECT. Please enter a valid object.";
                    InvalidCount++;
                    break;
                case 3:
                    result = "The penguins we hired to deal with memory management can't seem to find anything relating to that command.";
                    InvalidCount++;
                    break;
                case 4:
                    result = "Please enter a choice indicated by the brackets in the text.";
                    InvalidCount++;
                    break;
                default:
                    result = $"I'm sorry {Game.currentState.playerName}, I'm afraid I can't do that."; // use player name in this string
                    break;
            }
            return result;
        }
    }
}