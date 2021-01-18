
//Jordan Moss

using System;
using System.Collections;   //Used to create an ArrayList
using System.IO;            //Used to read in data from a text file

public class Code
{
    readonly ArrayList list;         //The ArrayList is declared as a field

    public Code(String filename)    //Constructor. Reads the Morse.txt file and stores it in an ArrayList.
	{
        StreamReader sr = new StreamReader(filename);   //Create a StringReader object to read input from the specified file
        list = new ArrayList(36);                       //Create an ArrayList of size 36 (10 numbers and 26 letters) to hold the Morse code for each alphanumeric character

        //Create an ArrayList to hold the characters A-Z and 0-9, and their Morse code translations
        string line;                                    //A string to hold the current line from the Morse.txt text file
        while ((line = sr.ReadLine()) != null)          //Loops as long as the file has more lines to read
        {
            String[] text = line.Split(' ', '\n');      //Splits the line using a space and a newline as a delimiter, and stores the tokens in a string array.
                                                        //Index 0 is the character and index 1 is the Morse encoding
            list.Add(text);                             //Add the string array to the ArrayList
        }
    }

    public string Convert(String message)   //Takes in a message to convert, and returns the message after it has been converted
    {
        String codedMessage = "";                               //Holds the message after it has been converted. Begins with an empty string, which is later concatenated onto.
        char[] charArray = (message.ToUpper()).ToCharArray();   //Converts the original string message to an array of characters.
                                                                //Converts all alphabetic characters to uppercase for simplicity.
        //Iterates through the length of the message
        for (int i = 0; i < charArray.Length; i++)
        {
            //if the character at index i of the message is alphanumeric, it should be converted.
            if (Char.IsLetterOrDigit(charArray[i]))
            {
                //To convert - goes through the ArrayList of strings, searching for the index 0 position (regular character) that matches the character in the message
                foreach (String[] listArr in list)
                {
                    //if the character in the ArrayList matches the character in the message, which has been converted back to a string,
                    //add the ArrayList character's encoding (at ArrayList index 1) to the end of the converted message.
                    if (listArr[0] == charArray[i].ToString())
                    {
                        codedMessage += listArr[1] + " ";   //Add a space at the end to separate Morse code characters, for readability.
                    }
                }

            }
            else if (charArray[i] == ' ')
                codedMessage += "   ";   //if the character is a space between words, it should converted to three spaces
        }
        
        return codedMessage;    //returns the finished Morse code message
    }
}
