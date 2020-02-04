using System.Collections.Generic;

namespace DevOps_game
{
    public class State
    {
        public string playerName = "";
        public int cycle = 1;
        public string location = "Docks";
        public Dictionary<string, bool> Conditions = new Dictionary<string, bool>();
    }
}
