using System;
using System.Collections.Generic;

namespace DevOps_game
{
    public abstract class Location
    {
        public static Dictionary<string, string> validInputs = new Dictionary<string, string>(); // explore JSON for next sprint

        public abstract List<string> chooseText(string input);
    }
}
