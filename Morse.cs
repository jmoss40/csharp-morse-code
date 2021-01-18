
//Jordan Moss

using System;
using static System.Console;    //Used for inputting and outputting to/from the console

namespace MorseCode
{
    class Morse
    {
        static void Main()
        {
            String message = "";                                    //variable to hold the original message
            String convertedMessage = "";                           //variable to hold the message after it has been converted to Morse code
            char quit = 'n';                                        //variable used to allow user to exit the program when prompted

            Code morseCode = new Code("Morse.txt");                 //instantiate the Code class, passing the Morse.txt file name as an argument

            WriteLine("\t~ MORSE CODE CONVERTER ~");                //Display program title

            do
            {
                WriteLine("\nPlease enter a message to convert to Morse code."); //Ask for user to provide input
                message = ReadLine();

                convertedMessage = morseCode.Convert(message);      //Pass the string to the Convert method in the Code class
                WriteLine("Converted message: {0}", convertedMessage);

                WriteLine("\n\nQuit? [y/n]");                       //Give user a chance to exit - only quits if 'y' is entered
                quit = Char.Parse(ReadLine());

            } while (quit != 'y');  //Loop executes until user wants to stop converting messages
        }
    }
}
