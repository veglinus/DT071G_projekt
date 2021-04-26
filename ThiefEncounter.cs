using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using CaveAdventure;

public partial class ThiefEncounter
{
    public void Thief() {
    int score = 0;
    int rounds = 0;

    Console.Clear();
    Console.WriteLine("As you exit the building a nimble thief starts picking your pockets, and you catch him in the midst of it!");
    Console.WriteLine("What do you do? (Write a VERB)\n");

    string verb = Console.ReadLine().ToLower();
    Console.Clear();
    Console.WriteLine($"You {verb} the thief, he's shocked!");
    GamePlay.Talk($"Wha?! What did you do that for?! Don't you know {verb} is illegal here?");
    GamePlay.Talk("Tell you what, if you defeat me in a game I might let you go..");
    GamePlay.Talk("So what will it be..?");
    GameStart();

    void GameStart() {
        GamePlay.Talk($"Rock, paper, or scissor? Score: {score}\n");

        string UserChoice = Console.ReadLine().ToLower();
        if (UserChoice != "rock" && UserChoice != "paper" && UserChoice != "scissor" && UserChoice != "cheat") { // Validation for input
            Console.WriteLine("That's not a valid input. Let's try that again.\n");
            GameStart();
        }

        List<string> rps = new List<string>(){ // List of possible choicse
        "rock",
        "paper",
        "scissor"
        };

        int randomIndex = 1;
        string ThiefChoice = "rock";
        int notRandom = 0;

        // Make the thief choose rock, paper, scissor, rock, paper, scissor, repeat etc
        if (rounds > 5) { // If we've played more than 5 rounds, make the game predictable
            
            notRandom++; // Increase by 1 for each round after 5 rounds played
            randomIndex = notRandom; // Make the game use the index that is not random

            if (notRandom == 4) { // If we were to roll around to four, go back to one, as we only have 3 things in the list
                notRandom = 1;
            }

        } else { // If less than 5 rounds played, pick one randomly
            randomIndex = new Random().Next(rps.Count); // Take a random number
            ThiefChoice = rps[randomIndex]; // Pick option from list using random number
        }

        rounds++; // Amount of rounds played
        if (ThiefChoice == UserChoice) { // if choices are the same, tie
            GamePlay.Talk($"Ah darn, you picked {ThiefChoice} aswell! It's a tie!");
            GameStart();
        } else if (UserChoice == "rock") {
            if (ThiefChoice == "scissor") {
                Win();
            } else {
                Loss();
            }
        } else if (UserChoice == "paper") {
            if (ThiefChoice == "rock") {
                Win();
            } else {
                Loss();
            }
        } else if (UserChoice == "scissor") {
            if (ThiefChoice == "paper") {
                Win();
            } else {
                Loss();
            }
        } else if (UserChoice == "cheat") { // to get past the event quickly
            GamePlay.Talk("What the?! How did you do that?");
            Win();
        }

        void Win() {
            score++;
            Console.WriteLine($"You beat the thief's {ThiefChoice} with your {UserChoice}!");
            if (score == 3) {
                GamePlay.Talk("Oh geez I'm getting tired of this. I'm off!\n");
                Console.WriteLine("The thief runs away, dropping a key on the ground before you. You got the brave key!");
                GamePlay.BraveKey = true;
                GamePlay.ThievesEncounter = 1;
                GamePlay.Save();
                GamePlay.AwaitInput();
                GamePlay.Outside();
            } else {
                GameStart();
            }
        }
        void Loss() {
            if (score > 0) {
                score--;
            }
            GamePlay.Talk("Ha! Beat ya!");
            Console.WriteLine($"\nThe thief beats your {UserChoice} with his {ThiefChoice}..");
            GameStart();
        }
    }
}
}