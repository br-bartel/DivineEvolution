﻿using System;
using System.Collections.Generic;

namespace DevOps_game
{
    public class Docks : Location
    {
        public string currentS = "";
        string previousS = "";
        public string currentF = "";
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
                    "Wait... You remember a small bit of information: Someone wearing a tuxedo is almost certainly responsible for your condition. \nType \u001b[32;1m[next]\u001b[0m to continue.", 
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
            
			if (input == "help" || input == "?" || input == "h")
			{
				story.Add("flavor", new List<string> {HelpMessage.Help()});
			}
            
            if (Game.currentState.cycle == 1)
            {
                if (Game.currentState.playerName == "")
                {
                    story.Add("story", sceneOneStory);
                    currentS = "one";
					if (input != "help" && input != "?" && input != "h") 
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
                    string[] wallet = 
                    { 
                        "A simple leather wallet. Contains your Mage License - 2nd Class, identification papers, and a coupon for a half priced mead from your local tavern."             
                    };
                    string[] purse = 
                    {
                        "A simple pouch, containing a single gold piece, a couple silver pieces, and a handful of copper pieces."
                    };
                    string[] watch =
                    {
                        "The silver pocket watch that your father got you upon your graduation from University.\n \nType \u001b[32;1m[next]\u001b[0m to continue.",
                        "It has an engraving on the back - \"A wizard is never late, nor is he early, he arrives precisely when he means to.\" - your father’s favorite quote from the old bard’s tale Rings of the Lord."
                    };
                    string[] parchment =
                    {
                        "You unfold the parchment, trying to make sense of what it says around the damp spots that has caused the ink to bleed.\n \nType \u001b[32;1m[next]\u001b[0m to continue.", 
                        "All you can really puzzle out is that it's dated the 16th of Donnestag. Well, that makes sense, given that your holiday was supposed to be the 15th through the 17th. \n \nType \u001b[32;1m[next]\u001b[0m to continue.",
                        "You figure today must be the 17th or, if you’re particularly unlucky, the 18th. Your boss is the understanding sort, right?\n \nType \u001b[32;1m[next]\u001b[0m to continue."
                    };
                    validInputs = new Dictionary<string, List<string>>()
                    {                      
                        { "wallet", new List<string>(wallet)},
                        { "purse", new List<string>(purse)},
                        { "watch", new List<string>(watch)},
                        { "parchment", new List<string>(parchment)}
                    };

					sceneTwoFlavor = Game.checker(validInputs);
					if (Game.previousInput == "parchment" && Game.fIndex == 2) 
					{
						Game.currentState.Conditions.Add("parchment", true);
					}
					if (input != "help" && input != "?" && input != "h")
					{
					    HelpMessage.helpCount = 0;
                    	story.Add("flavor", sceneTwoFlavor);
                        currentF = "two";
					}
                }
				else 
				{
					story.Add("story", sceneThreeStory);
                    currentS = "three";
                    List<string> sceneThreeFlavor = new List<string>();
                    string[] fisherman = {
                        "You approach the fisherman, who is on the pier loading crates onto his boat. As you get closer, you hear him whistling a jaunty tune.\n \nType \u001b[32;1m[next]\u001b[0m",
                        "You wait until he looks up before greeting him, not wanting to get impaled by the harpoon he’s holding if you startle him.\n \nType \u001b[32;1m[next]\u001b[0m to continue.",
                        "“Excuse me, sir?” you ask, somewhat hesitantly. “What can I do for ya, friend?” is his energetic response. “Lookin’ for work? The dockworkers are always lookin’ for an extra hand if ya can spare it.\n \nType \u001b[32;1m[next]\u001b[0m",
                        "Or are ya lookin’ for some o’ the... goods?” He trails off towards the end, losing some of his friendly demeanor as he levels you with a flat look.\n \nType \u001b[32;1m[next]\u001b[0m to continue.",
                        "You cautiously respond “No, no, not looking for either of those. I was wondering if you had seen anything out of the ordinary since last night.”\n \nType \u001b[32;1m[next]\u001b[0m", 
                        "He adopts a face of concentration looking at the ground as he thinks and inadvertently levels his harpoon at your face. “Well, I’ve been down ‘ere since before sunrise, waiting for my delivery o’... supplies and stuff.\nType \u001b[32;1m[next]\u001b[0m to continue.",
                        "Only thing I seen out o’ normal’s been a flash o’ light o’er on the dock. Figured ‘twas just the lighthouse at first, but it looked to ‘ave been from on high.\n \nType \u001b[32;1m[next]\u001b[0m",
                        "Don’t rightly know much else; when I saw you in the cart, I thought you was just a drunk who couldn’t make it the rest o’ the way home.”\nType \u001b[32;1m[next]\u001b[0m to continue.",
                        "You thank the sailor for his time and go back to the dock."
                    };
                    string[] dockworkers = {
                        "You walk over to group of dockworkers gathered on the docks. One of the older ones sees your approach, spits on the ground and goes back to chewing as he gruffly calls out “Wha’ is it ya want?\n \nType \u001b[32;1m[next]\u001b[0m",
                        "Don’t need no more help fer the day and ya’d have ta go talk to bossman if you’s lookin’ to ship somet’in.”\n \nType \u001b[32;1m[next]\u001b[0m",
                        "Taken aback by the gruff greeting, you tentatively respond “I was just wondering if any of you had seen anything out of the ordinary since last night.”\n \nType \u001b[32;1m[next]\u001b[0m",
                        "The dockworker spits again, this time closer to your feet before replying “Ain’t seen nothi’n ‘sides the harpoon wieldin’ madman loadin ‘is boat.\n \nType \u001b[32;1m[next]\u001b[0m",
                        "Now if ya ain’t got nothi’n else, git goin’ and leave us alone.” Taking the hint, you hurry away from the group."
                    };
                    string[] poster = {
                        "You examine the poster nailed to a post nearby where you woke up. The sketch is of a young man with a scar above his left eye with a rather prominent handlebar moustache.\n \nType \u001b[32;1m[next]\u001b[0m",
                        "The sketch doesn’t show much of his torso, but it appears to show a bow tie and a collared shirt. Could there be a tuxedo jacket as a part of the outfit too?\n \nType \u001b[32;1m[next]\u001b[0m",
                        "The text of the poster reads: WANTED: \nBY THE ORDER OF THE CROWN FOR CRIMES INCLUDING: \nPIRACY; \nCRIMES OF THE HIGH SEAS,\n \nType \u001b[32;1m[next]\u001b[0m",
                        "\nMURDER, \nDESECRATION OF MOSTE SACRED SITES, \nand littering. \nREWARD OF 5,000 GOLD PIECES FOR HIS HEAD LIVING XOR DEAD."
                    };
                    validInputs = new Dictionary<string, List<string>>()
                    {

                        {"fisherman", new List<string>(fisherman)},
                        {"dockworkers", new List<string>(dockworkers)},
                        {"poster", new List<string>(poster)}
                    };
                    sceneThreeFlavor = Game.checker(validInputs);                    
                    if (input != "help" && input != "?" && input != "h")
                    {
                        HelpMessage.helpCount = 0;
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
