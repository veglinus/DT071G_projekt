using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;

/*
TODO:


*/
public static class Hangman
{
    private static System.Timers.Timer Timer;

    public static void writeSlow(string text)
    {
        Console.Write("\n");
        foreach(char letter in text) {
            Console.Write(letter);
            Thread.Sleep(50);
        }
    }

    public static void Talk(string msg) {
        Console.ForegroundColor = ConsoleColor.Green;
        writeSlow(msg);
        Console.ResetColor();
    }
    public static void HangmanStart() {
        try
        {
            List<string> dictionary = new List<string>(){
                "HIPPOPOTAMUS",
                "MICROWAVE",
                "JACKPOT",
                "WRISTWATCH",
                "BEEKEEPER"
            };

            var random = new Random(); // Choosing a random word
            int i = random.Next(dictionary.Count);
            var chosenword = dictionary[i]; // this is the word we're using
            int length = chosenword.Length;

            string blankstring = "";

            foreach (var letter in chosenword)
            {
                blankstring += "_";
            }

            Talk("Word is: " + chosenword + ", blanked out: " + blankstring + "\n");

            var guess = Console.ReadLine().ToUpper();

            if (chosenword.Contains(guess)) {
                Console.WriteLine("Correct guess");
                var pos = chosenword.IndexOf(guess);

                foreach (Match match in Regex.Matches(chosenword, "(" + guess + ")"))
                {
                    Console.WriteLine("match!");
                    
                    var stringb = new StringBuilder(blankstring);
                    stringb.Remove(match.Index, 1);
                    stringb.Insert(match.Index, guess);

                    blankstring = stringb.ToString();
                }
            } else {
                Console.WriteLine("Wrong guess");
            }


            Talk("Word is: " + chosenword + ", blanked out: " + blankstring + "\n");
            
        }
        catch (System.Exception)
        {
            Console.WriteLine("You trip over Billy, causing him to have to start the game over.");
            HangmanStart();
        }
    }
}