using System;
using System.Collections.Generic;

namespace DevOps_game
{
    public class TownSquare : Location
    {

		List<string> sceneOneStory = new List<string>() { "Town Square" };
		List<string> sceneOneFlavor = new List<string>() { "I made it" };

		public override Dictionary<string, List<string>> chooseText(string input) 
		{
	        Dictionary<string, List<string>> story = new Dictionary<string, List<string>>();
			story.Add("story", sceneOneStory);
			story.Add("flavor", sceneOneFlavor);
			return story;
		}
	}
}