using System;
public class InvalidEntry
{
	static int invalidCount { private get; set; } // is there a better way of doing this?
	public string invalidEntry(bool isValid) // pass in equality statement i.e. userIn == validIn ???
	{
        string result;
		if (!isValid)
        {
            switch (invalidCount)
            {
                case 0:
                    result = "You try, but you just can't quite do that.";
                    invalidCount++;
                    break;
                case 1:
                    result = "You hear a myterious voice whispering to you, telling you to do something you know you can't.";
                    invalidCount++;
                    break;
                case 2:
                    result = "The object Object.object != OBJECT. Please enter a valid object.";
                    invalidCount++;
                    break;
                case 3:
                    result = "The penguins we hired to deal with memory management can't seem to find anything relating to that command.";
                    invalidCount++;
                    break;
                case 4:
                    result = "Please enter a choice indicated by the brackets in the text.";
                    invalidCount++;
                    break;
                default:
                    result = $"I'm sorry " /*{playerName}*/ + ", I'm afraid I can't do that."; // use player name in this string
                    break;
            }
        }
        else
        {
            invalidCount = 0; // might be replaced in another class 
        }
        return result;
	}
}
