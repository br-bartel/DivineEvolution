using System;
using System.Collections.Generic;

namespace DevOps_game
{
    public class TownSquare : Location
    {

		bool changeScene = false;
		List<string> sceneOneStory = new List<string>() 
		{ 
			"Taking a look around, you get a vague sense of familiarity from the town square. You swear you’ve been here before, but you can’t quite place if you’ve been here before or if it just reminds you of somewhere. The inn to the north specifically tugs on your memory... The Horse and Shoe \u001b[32;1;4m[Inn]\u001b[0m. You’re pretty sure you made reservations there for the weekend. Maybe they still have some of your stuff? Next door is the Sad Peacock \u001b[32;1;4m[Tavern]\u001b[0m. At the center of the square, there is a paper \u001b[32;1;4m[boy]\u001b[0m trying to sell the stack of papers that are almost as tall as he is." 
		};
		public override Dictionary<string, List<string>> chooseText(string input) 
		{
	        Dictionary<string, List<string>> story = new Dictionary<string, List<string>>();
			if (Game.currentState.cycle <= 3) {

				string[] tavern = 
				{
					"You decide to quash your crippling disappointment with the tried and true method of copious amounts of alcohol."
				};
				string[] inn = 
				{
					"Surprise! There are reservations in your name."
				};
				string[] boy = 
				{
					"The paper says... it’s Friday?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?"
				};

				validInputs = new Dictionary<string, List<string>>()
					{
						{"tavern", new List<string>(tavern)},
						{"inn", new List<string>(inn)},
						{"boy", new List<string>(boy)}
					};

				List<string> sceneOneFlavor = Game.checker(validInputs, out currentF);
				story.Add("story", sceneOneStory);
				story.Add("flavor", sceneOneFlavor);
			}
			if (changeScene) 
			{
				Game.currentState.location = "Outskirts";
				story["story"] = new List<string>() {"You wake up from a hangover..."};
				story["flavor"] = new List<string>() {"Type \u001b[32;1;4m[next]\u001b[0m to continue."};
			}
			if (currentF == "boy") 
			{
				Game.currentState.date = "Friday";
			}
			if (currentF == "inn")
			{
				changeScene = true;
			}
			return story;
		}
	}
}