using System;
using System.Collections.Generic;

namespace DevOps_game
{
    public class Docks : Location
    {
        string currentS = "";
        string previousS = "";
        string currentF = "";
        string previousF = "";
        public override Dictionary<string, List<string>> chooseText(string input)
        {
            List<string> sceneOneStory = new List<string>
                {
					"You awaken to the smell of the sea and gulls squawking overhead, " +
                    "not quite remembering how you got to this point. You begin to gain your bearings and as you try to sit up, " +
                    "you get hit with a wave of nausea and dizziness. Your condition is not at all helped by the smell of fish coming from the cart you have been lying in. " +
                    "You slowly prop yourself up on the wall of the cart and wait for the nausea to subside and for the world to stop spinning. " +
                    "It takes a couple minutes, but you are finally able to lift yourself up and out of the cart. " +
                    "Looking around, you notice that you are standing on a dock on the edge of a small town. " +
                    "As you take in the view, you start to think back on your past, the memories hovering just out of reach. You think harder and harder, trying to remember...  " +
                    "Aha! You remember that your name is:"
				};

            List<string> sceneOneFlavor = new List<string>
                    { "Please enter your character's name:\n" };

            List<string> sceneTwoStory = new List<string> 
				{
					"It seems that remembering your name has it all starting to come back now. " +
					"You are a teacher at the University of Mages and have an exceptional understanding of the arcane arts, with your cautious demeanor making you a perfect fit for teaching the more dangerous subjects. " +
					"Your dedication to your work leaves you with little time off, to the point that your boss has had to step in to force you to have a weekend to yourself. You remember leaving your home for your mandated weekend off... but where ? Why ? " +
					"Wait... You remember a small bit of information: Someone wearing a tuxedo is almost certainly responsible for your condition. \n", 
					"Now that you feel that your mind is back in working order, you take inventory of what is in your pocket, curious as to if whoever left you in that sorry state decided to rob you blind as well. " +
					"\u001b[32;1m[Wallet]\u001b[0m? Still there, nothing seems to be out of place. Coin \u001b[32;1m[purse]\u001b[0m? Seems to be all there, just as depressingly light as it was before. Pocket \u001b[32;1m[watch]\u001b[0m? Still attached to the inside of your coat. Torn off piece of \u001b[32;1m[parchment]\u001b[0m? Yup, just as you... wait. What’s that doing there? "
				};

            List<string> sceneThreeStory = new List<string> 
				{
					"Now that you have your wits about you again, you decide it’s high time to try and get some answers. You look around the docks, seeing if there might be something or someone that might be able to give you answers. " + 
					"On the pier, there stands a seasoned [fisherman] who appears to be loading up his boat for another trip out. Maybe he saw something that can explain your condition? To your right, " + 
					"a group of [dockworkers] are gathered around a few shipping crates. Out of the group of them, maybe one of them saw something happen? On the wall is a wanted [poster]. It might not have answers, but who knows? It could trigger a memory... "
				};

            Dictionary<string, List<string>> story = new Dictionary<string, List<string>>();
            
			if (input != "next" && (input == "help" || input == "?" || input == "h"))
			{
				story.Add("flavor", new List<string> {HelpMessage.Help()});
                currentF = "help";
			}
            
            if (Game.currentState.cycle == 1)
            {
                if (Game.currentState.playerName == "")
                {
                    story.Add("story", sceneOneStory);
                    currentS = "one";
					if (currentF != "help") 
					{
                    	story.Add("flavor", sceneOneFlavor);
                        currentF = "one";
					}
                }
                else if (!Game.currentState.Conditions.ContainsKey("parchment"))
                {
                    story.Add("story", sceneTwoStory);
                    currentS = "two";
                    List<string> sceneTwoFlavor = new List<string>();
                    validInputs = new Dictionary<string, string>
                    {
                        //{ Game.currentState.playerName, "This is your name" }, // not ideal, will need to expand capability for this later
                        { "wallet", "A simple leather wallet. Contains your Mage License - 2nd Class, identification papers, and a coupon for a half priced mead from your local tavern." },
                        { "purse", "A simple pouch, containing a single gold piece, a couple silver pieces, and a handful of copper pieces." },
                        { "watch", "The silver pocket watch that your father got you upon your graduation from University. It has an engraving on the back - \"A wizard is never late, nor is he early, he arrives precisely when he means to.\" - your father’s favorite quote from the old bard’s tale Rings of the Lord." },
                        { "parchment", "You unfold the parchment, trying to make sense of what it says around the damp spots that has caused the ink to bleed. All you can really puzzle out is that it’s dated the 16th of Donnestag. Well, that makes sense, given that your holiday was supposed to be the 15th through the 17th. You figure today must be the 17th or, if you’re particularly unlucky, the 18th. Your boss is the understanding sort, right?" }
                    };

					sceneTwoFlavor = new List<string>() { Game.checker(validInputs) };
					HelpMessage.helpCount = 0;
					if (input == "parchment") 
					{
						Game.currentState.Conditions.Add("parchment", true);
					}
					if (currentF != "help")
					{
                    	story.Add("flavor", sceneTwoFlavor);
                        currentF = "two";
					}
                }
				else 
				{
					story.Add("story", sceneThreeStory);
                    currentS = "three";
                    List<string> sceneThreeFlavor = new List<string>();
                    validInputs = new Dictionary<string, string>
                    {
                        {"fisherman","You approach the fisherman, who is on the pier loading crates onto his boat. As you get closer, you hear him whistling a jaunty tune. You wait until he looks up before greeting him, not wanting to get impaled by the harpoon he’s holding if you startle him. >> “Excuse me, sir?” you ask, somewhat hesitantly. “What can I do for ya, friend?” is his energetic response. “Lookin’ for work? The dockworkers are always lookin’ for an extra hand if ya can spare it. Or are ya lookin’ for some o’ the... goods?” He trails off towards the end, losing some of his friendly demeanor as he levels you with a flat look. >> You cautiously respond “No, no, not looking for either of those. I was wondering if you had seen anything out of the ordinary since last night.” He adopts a face of concentration looking at the ground as he thinks and inadvertently levels his harpoon at your face. “Well, I’ve been down ‘ere since before sunrise, waiting for my delivery o’... supplies and stuff. Only thing I seen out o’ normal’s been a flash o’ light o’er on the dock. Figured ‘twas just the lighthouse at first, but it looked to ‘ave been from on high. Don’t rightly know much else; when I saw you in the cart, I thought you was just a drunk who couldn’t make it the rest o’ the way home.” >> You thank the sailor for his time and go back to the dock." },

                    };
                    sceneThreeFlavor = new List<string>() { Game.checker(validInputs) };
                    HelpMessage.helpCount = 0;
                    if (currentF != "help")
                    {
                        story.Add("flavor", sceneThreeFlavor);
                        currentF = "three";
                    }
                }
            }

            if (currentS != previousS)
            {
                Game.sIndex = 1;
            }
            if (currentF != previousF)
            {
                Game.fIndex = 1;
            }
            previousS = currentS;
            previousF = currentF;
			return story;
        }
    }
}
