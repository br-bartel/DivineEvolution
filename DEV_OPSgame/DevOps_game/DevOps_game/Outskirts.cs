using System;
using System.Collections.Generic;

namespace DevOps_game
{
    public class Outskirts : Location
    {

		List<string> sceneOneStory = new List<string>(){"You are in the outskirts"};
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