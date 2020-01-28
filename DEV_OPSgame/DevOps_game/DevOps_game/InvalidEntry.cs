using System;
public class InvalidEntry
{
	static int InvalidCount { get; set; } // is there a better way of doing this?
	public string Invalid(bool isValid) // pass in equality statement i.e. userIn == validIn ???
	{
        string result;
		if (!isValid)
        {
            switch (InvalidCount)
            {
                case 0:
                    result = "You try, but you just can't quite do that.";
                    InvalidCount++;
                    break;
                case 1:
                    result = "You hear a myterious voice whispering to you, telling you to do something you know you can't.";
                    InvalidCount++;
                    break;
                case 2:
                    result = "The object Object.object != OBJECT. Please enter a valid object.";
                    InvalidCount++;
                    break;
                case 3:
                    result = "The penguins we hired to deal with memory management can't seem to find anything relating to that command.";
                    InvalidCount++;
                    break;
                case 4:
                    result = "Please enter a choice indicated by the brackets in the text.";
                    InvalidCount++;
                    break;
                default:
                    result = $"InvalidCount'm sorry " /*{playerName}*/ + ", InvalidCount'm afraid InvalidCount can't do that."; // use player name in this string
                    break;
            }
        }
        else
        {
            InvalidCount = 0; // might be replaced in another class
            result = ""; 
        }
        return result;
	}
}
