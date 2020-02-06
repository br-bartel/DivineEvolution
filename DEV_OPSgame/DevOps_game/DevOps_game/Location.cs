using System;
using System.Collections.Generic;

namespace DevOps_game
{
    public abstract class Location
    {
		public string currentS = "";
        public string previousS = "";
        public string currentF = "";
        public string previousF = "";
        public static Dictionary<string, List<string>> validInputs = new Dictionary<string, List<string>>(); // explore JSON for next sprint
		// public static Dictionary<string, List<string>> story = new Dictionary<string, List<string>>();
        public abstract Dictionary<string, List<string>> chooseText(string input);
    }
}
