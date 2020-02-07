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
		List<string> sceneOneFlavor = new List<string>(){"Hooray"};

		public override Dictionary<string, List<string>> chooseText(string input) 
		{
			Dictionary<string, List<string>> story = new Dictionary<string, List<string>>();
			story.Add("story", sceneOneStory);
			story.Add("flavor", sceneOneFlavor);
			return story;
		}
	}
}