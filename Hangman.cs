using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using CaveAdventure;

public static class Hangman
{
    private static System.Timers.Timer Timer;

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

            string blankstring = ""; // Will eventually become the blanket out _ _ _ _ _ word
            string tries = ""; // What the user has tried before
            string StringTries = ""; // Will be used for spacing dialogue
            int lives = 7; // How many lives left, standard 7

            if (blankstring == "") { // Blanks out the word
                foreach (var letter in chosenword)
                {
                    blankstring += "_";
                }
            }
            MainActivity();


            void MainActivity() {

                if (lives == 0) { // Check if you have lives left
                    stickman();
                    GamePlay.Talk("You ran out of lives! Sorry!");
                    GamePlay.Talk($"The correct word was: {chosenword}");
                    GameEnd();
                    
                } else if (!blankstring.Contains("_")) { // No underscores means that the entire word is there, = user has won
                    GamePlay.Talk("Congratulations! You won!");
                    Win();
                    GameEnd();

                } else {

                    var chosenWordSpaced = "";

                    foreach (var letter in blankstring) // For putting spaces in the word
                    {
                        if (chosenWordSpaced == "") {
                            chosenWordSpaced += letter;
                        } else {
                            chosenWordSpaced += " " + letter;
                        }
                        
                    }

                    stickman(); // To draw the stickman
                    //GamePlay.Talk($"Word is: {chosenword}, blanked out: {blankstring}\nTry any letter!\n"); // Debug

                    
                    if (tries != "") { // If this isn't the first input, show list of tried letters
                        StringTries = ($" You've tried: {tries}\n");
                    }

                    GamePlay.Talk($"{chosenWordSpaced}\n\nTry a letter or an entire word!{StringTries}\n");



                    var guess = Console.ReadLine().ToUpper(); // The user guesses

                    if (guess.Length > 1) { // User guessing a word, not just a letter
                        if (guess == chosenword) { // User guessed the word correctly
                            GamePlay.Talk("Congratulations! You won!");
                            Win();
                            GameEnd();
                        } else {
                            incorrect();
                        }
                    } else { // Single letter guess
                        if (tries.Contains(guess)) { // Check if user has tried this letter before
                            GamePlay.Talk($"You've already tried {guess}.");
                            MainActivity(); // restart

                        } else { // New letter guess
                            tries += guess; // Add guess to tried letters

                            if (chosenword.Contains(guess)) { // Match was found
                                GamePlay.Talk("That's correct!");

                                foreach (Match match in Regex.Matches(chosenword, "(" + guess + ")")) // Find all occurances of the letter in the chosen word
                                {
                                    var stringb = new StringBuilder(blankstring);
                                    stringb.Remove(match.Index, 1); // remove the underscore at index
                                    stringb.Insert(match.Index, guess); // insert the letter guessed
                                    blankstring = stringb.ToString(); // set string to new string with guessed letter
                                }

                                MainActivity(); // start the function over when we've finished the foreach
                            } else {
                                incorrect();
                            }
                        }
                    }

                    void incorrect() {
                        GamePlay.Talk("Oh no! That's wrong..");
                        Thread.Sleep(50);
                        lives--;
                        MainActivity();
                    }
                }

                void Win() {
                    GamePlay.Talk("You got the hangman key!");
                    GamePlay.HangmanKey = true;
                    GamePlay.AwaitInput();
                }
            }

            void GameEnd() {
                GamePlay.Talk("Would you like to play again? (yes or no)\n");
                var decision = Console.ReadLine();

                if (decision.Contains("yes")) {
                    Console.Clear();
                    HangmanStart();
                } else {
                    GamePlay.Tavern();
                }
            }


void stickman() { // Logic for typing out mr stickmans limbs depending on number of lives left
string thestickman = @"
/----|
|
|
|
|"; // Default state

switch (lives)
{
case 6:
thestickman = @"
/----|
|    O
|
|
|";
break;
    
case 5:
thestickman = @"
/----|
|    O
|    |
|
|";
break;

case 4:
thestickman = @"
/----|
|    O
|    | -
|   
|";
break;

case 3:
thestickman = @"
/----|
|    O
|    | -
|     \
|";
break;

case 2:
thestickman = @"
/----|
|    O
|  - | -
|     \
|";
break;

case 1:
thestickman = @"
/----|
|    O
|  - | -
|   / \
|";
break;

case 0:
thestickman = @"
The stickman has died.
/----|
| 
|
|
| 0 - c";
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