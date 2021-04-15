using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;

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
            string tries = "";
            int lives = 7;

            if (blankstring == "") {
                foreach (var letter in chosenword)
                {
                    blankstring += "_";
                }
            }
            MainActivity();

            


            void MainActivity() {

                if (lives == 0) { // Check if you have lives left
                    stickman();
                    Talk("You ran out of lives! Sorry!");
                } else if (!blankstring.Contains("_")) { // No underscores means that the entire word is there, = user has won
                    Talk("Congratulations! You won!");
                } else {

                    stickman(); // To draw the stickman
                    //Talk($"Word is: {chosenword}, blanked out: {blankstring}\nTry any letter!\n"); // Debug
                    Talk($"{blankstring}\n\nTry a letter!\n");

                    if (tries != "") { // If this isn't the first input, show list of tried letters
                    Talk($"You've tried: {tries}\n");
                    }

                    var guess = Console.ReadLine().ToUpper(); // The user guesses

                    if (guess.Length > 1) { // User guessing a word, not just a letter
                        if (guess == chosenword) { // User guessed the word correctly
                            Talk("Congratulations! You won!");
                        } else {
                            incorrect();
                        }
                    } else { // Single letter guess
                        if (tries.Contains(guess)) { // Check if user has tried this letter before
                            Talk($"You've already tried {guess}.");
                            MainActivity(); // restart

                        } else { // New letter guess
                            tries += guess; // Add guess to tried letters

                            if (chosenword.Contains(guess)) { // Match was found
                                Talk("That's correct!");

                                foreach (Match match in Regex.Matches(chosenword, "(" + guess + ")")) // Find all occurances of the letter in the chosen word
                                {
                                    var stringb = new StringBuilder(blankstring);
                                    stringb.Remove(match.Index, 1); // remove the underscore at index
                                    stringb.Insert(match.Index, guess); // insert the letter guessed
                                    blankstring = stringb.ToString(); // set string to new string with guessed letter

                                    MainActivity(); // start the function over
                                }
                            } else {
                                incorrect();
                            }
                        }
                    }

                    void incorrect() {
                        Talk("Oh no! That's wrong..");
                        Thread.Sleep(1000);
                        lives--;
                        MainActivity();
                    }
                }

            }


            void stickman() { // Logic for typing out mr stickmans limbs depending on number of lives left
                string thestickman = @"
                /----|
                |    O
                |  - | -
                |   / \
                |
                "; // Default state

                switch (lives)
                {
                case 6:
                thestickman = @"
                    O
                 -- | -
                   / \
                ";
                break;
                    
                case 5:
                thestickman = @"
                    O
                  - | -
                   / \
                ";
                break;

                case 4:
                thestickman = @"
                    O
                  - | -
                   / 
                ";
                break;

                case 3:
                thestickman = @"
                    O
                    | -
                   / 
                ";
                break;

                case 2:
                thestickman = @"
                    O
                    |
                   / 
                ";
                break;

                case 1:
                thestickman = @"
                    O
                    |
                 
                ";
                break;

                case 0:
                thestickman = @"
                The stickman has died.
                -    o
                ";
                break;
                    
                default:
                break;
                }
                Console.WriteLine(thestickman);
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("You trip over Billy, causing him to have to start the game over.");
            HangmanStart();
        }
    }
}