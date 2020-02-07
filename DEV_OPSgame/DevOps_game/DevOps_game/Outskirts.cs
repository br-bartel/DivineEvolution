using System;
using System.Collections.Generic;

namespace DevOps_game
{
    public class Outskirts : Location
    {

		List<string> sceneOneStory = new List<string>()
		{
			"As you near an open field along the side of the road, you start to hear faint chanting and begin to feel the chill of the arcane energy associated with summoning. Knowing nothing good can come from summoning, you dash into the field and ready a shield spell just to be safe. As the chanting reaches its apex, you feel a wave of energy as the sky opens directly above you. You cast your shield spell upwards, hoping to protect yourself from whatever may come through. You see an individual in a tuxedo with their arms pointed skyward as a few tentacles begin hoisting their host out of the abyss... and directly on top of you. With a sense of impending doom, you look up, and only briefly register the fact that the creature resembles a massive giant squid before it falls directly on top of you. Well, this was an awful end to your weekend..."
		};
		List<string> sceneOneFlavor = new List<string>(){ "Type \u001b[32;1;4m[next]\u001b[0m to continue." };

		public override Dictionary<string, List<string>> chooseText(string input) 
		{
			Dictionary<string, List<string>> story = new Dictionary<string, List<string>>();
			if (Game.currentState.cycle < 2)
			{
				Game.currentState.Conditions["parchment"] = false;
				Game.currentState.playerName = "";

				Docks.picks["fisherman"] = false;
				Docks.picks["dockworkers"] = false;
				Docks.picks["poster"] = false;
				Map.PlacesVisited["Town Square"] = false;
				Map.PlacesVisited["Outskirts"] = false;
				Map.TownText = "???";
				Map.OutskirtsText = "???";
				Game.currentState.location = "Docks";
				Game.currentState.date = "???";
				Game.currentState.cycle++;
				story.Add("story", sceneOneStory);
				story.Add("flavor", sceneOneFlavor);
			} 
			else
			{
				story.Add("story", new List<string>() { "The End" });
				story.Add("flavor", new List<string>() { "Thanks for playing\nUse CTRL/COMMAND + C to quit." });
			}

			return story;
		}
	}
}