using System;
using System.Collections.Generic;

namespace DevOps_game
{
    public class Docks : Location
    {
        public override List<string> chooseText(string input)
        {
            List<string> openingArray = new List<string> 
                    {"You awaken to the smell of the sea and gulls squawking overhead, " +
                    "not quite remembering how you got to this point. You begin to gain your bearings and as you try to sit up, " +
                    "you get hit with a wave of nausea and dizziness. Your condition is not at all helped by the smell of fish coming from the cart you have been lying in. " +
                    "You slowly prop yourself up on the wall of the cart and wait for the nausea to subside and for the world to stop spinning. " +
                    "It takes a couple minutes, but you are finally able to lift yourself up and out of the cart. " +
                    "Looking around, you notice that you are standing on a dock on the edge of a small town. " +
                    "As you take in the view, you start to think back on your past, the memories hovering just out of reach. You think harder and harder, trying to remember...  " +
                    "Aha! You remember that your name is:\nPlease enter your character's name:\n"};

            List<string> defaultArray = new List<string> 
                    {"It seems that remembering your name has it all starting to come back now. " +
                    "You are a teacher at the University of Mages and have an exceptional understanding of the arcane arts, with your cautious demeanor making you a perfect fit for teaching the more dangerous subjects. " +
                    "Your dedication to your work leaves you with little time off, to the point that your boss has had to step in to force you to have a weekend to yourself. You remember leaving your home for your mandated weekend off... but where ? Why ? " +
                    "Wait... You remember a small bit of information: Someone wearing a tuxedo is almost certainly responsible for your condition. \n", "Now that you feel that your mind is back in working order, you take inventory of what is in your pocket, curious as to if whoever left you in that sorry state decided to rob you blind as well.  " +
                    "[Wallet]? Still there, nothing seems to be out of place. Coin [purse]? Seems to be all there, just as depressingly light as it was before. Pocket [watch]? Still attached to the inside of your coat. Torn off piece of [parchment]? Yup, just as you... wait. What’s that doing there? \n\nSelect an item to interact with by typing the text contained by one set of square brackets:"};

            if (Game.currentState.cycle == 1)
            {
                if (Game.currentState.playerName == "")
                {
                    return openingArray;
                }
                else
                {
                    validInputs = new Dictionary<string, string>
                    {
                        { Game.currentState.playerName, "This is your name" }, // not ideal, will need to expand capability for this later
                        { "wallet", "A simple leather wallet. Contains your Mage License - 2nd Class, identification papers, and a coupon for a half priced mead from your local tavern." },
                        { "purse", "A simple pouch, containing a single gold piece, a couple silver pieces, and a handful of copper pieces." },
                        { "watch", "The silver pocket watch that your father got you upon your graduation from University. It has an engraving on the back - \"A wizard is never late, nor is he early, he arrives precisely when he means to.\" - your father’s favorite quote from the old bard’s tale Rings of the Lord." },
                        { "parchment", "You unfold the parchment, trying to make sense of what it says around the damp spots that has caused the ink to bleed. All you can really puzzle out is that it’s dated the 16th of Donnestag. Well, that makes sense, given that your holiday was supposed to be the 15th through the 17th. You figure today must be the 17th or, if you’re particularly unlucky, the 18th. Your boss is the understanding sort, right?" }
                    };
                    string checkedString = Game.checker(validInputs);
                    defaultArray.Add(checkedString);
                    return defaultArray;
                }
            }
            else
            {
                return defaultArray;
            }
        }
    }
}
