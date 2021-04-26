using System;

// Used for all dialog options in the game
namespace CaveAdventure
{
    public partial class Dialogue
    {
        public void Billy()
        { // Dialogue for Billy
            Console.WriteLine("You approach your neighbor Billy!");

            GamePlay.Talk("Howdy there neighbor! Boy you look like you're having an adventure. Are you doing alright?");
            if (GamePlay.Billy == 0)
            { // If this is the first talk
                GamePlay.Talk("Can I ask you for a favor? I havn't seen Nessie since last night. Give me a shout if you see her alright? She loves when you whistle at her, so you can try that.");
                GamePlay.Billy = 1;
                GamePlay.Save();
                Console.WriteLine("\nYou nod and leave Billy.");
                GamePlay.AwaitInput();
                GamePlay.Tavern();
            }
            else if (GamePlay.Billy == 1)
            { // Havn't seen dog yet
                GamePlay.Talk("Have you caught a glimpse of my dog Nessie yet? Just try whistling if you see her okay?");
                Console.WriteLine("\nYou shake your head and leave Billy.");
                GamePlay.AwaitInput();
                GamePlay.Tavern();
            }
            else if (GamePlay.Billy == 2)
            { // You ahve seen the dog
                GamePlay.Talk("Have you caught a glimpse of my dog Nessie yet?\n");
                Console.WriteLine("Where did you see the dog?\n");
                var response = Console.ReadLine().ToLower();

                if (response.Contains("graveyard"))
                { // You give the correct response
                    GamePlay.Talk("She was at the graveyard?! Boy is she far from home. Thanks for helping out neighbor. Here's a little reward.\n");
                    Console.WriteLine("You got an old key!");
                    GamePlay.Billy = 3;
                    GamePlay.BillyKey = true;
                    GamePlay.Save();
                    GamePlay.AwaitInput();
                    GamePlay.Tavern();
                }
                else if (response.Contains("exit") || response.Contains("back"))
                {
                    GamePlay.Tavern();
                }
                else
                { // You give the wrong response
                    GamePlay.Talk("No.. I don't think she would be there. You probably saw something else.\n");
                    Console.WriteLine("Billy looks sad. You better find his dog soon. You walk away.");
                    GamePlay.AwaitInput();
                    GamePlay.Tavern();
                }
            }
        }

        public void Bartender(string error = "")
        { // Because every tavern needs a bartender

            if (error != "")
            {
                GamePlay.Talk(error);
            }
            else
            {
                GamePlay.Talk($"Hello there, what can I do for ya {GamePlay.Name}?\n");
            }

            Console.WriteLine("1) Beer, 2) Gossip, 3) Beer");
            var option = Console.ReadLine().ToLower();

            if (option.Contains("beer") || option.Contains("3") || option.Contains("drink") || option.Contains("1"))
            {
                Console.WriteLine("The bartender gives you a beer and you swig it fast.");
                GamePlay.Drunk++;
                if (GamePlay.Drunk >= 2)
                {
                    Console.WriteLine("Maybe it's time to stop now.");
                    GamePlay.AwaitInput();
                    GamePlay.Tavern();
                }
                else if (GamePlay.Drunk == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Oh dear, you pass out. Somehow you end up at your house.");
                    GamePlay.Drunk = 0;
                    GamePlay.AwaitInput();
                    GamePlay.House();
                }
                else
                {
                    Console.WriteLine("You feel fine, for now.");
                    GamePlay.AwaitInput();
                    GamePlay.Tavern();
                }
            }
            else if (option.Contains("gossip") || option.Contains("2"))
            {
                if (GamePlay.Billy == 0)
                {
                    GamePlay.Talk("Have you heard about Billy's dog Nessie? Poor old thing ran away, I hope he finds her soon. Or else she might end up in that graveyard..");
                    GamePlay.AwaitInput();
                    GamePlay.Tavern();
                }
                else if (GamePlay.ThievesEncounter > 0)
                {
                    GamePlay.Talk("There's been a pesky thief lingering around the village as of lately..Watch out for him!");
                    GamePlay.AwaitInput();
                    GamePlay.Tavern();
                }
                else
                {
                    GamePlay.Talk("You looking to get through that cave outside of town sweetie? Try playing some of the games with the tavern guests, you might be surprised what you can get!");
                    GamePlay.AwaitInput();
                    GamePlay.Tavern();
                }
            }
            else
            {
                Bartender("Sorry I didn't quite catch that..what can I help you with?\n");
            }
        }

        public void Mathematician()
        { // To start Mathgame
            String GMdialogue = " There might be something in it for you if you complete the medium difficulty..";
            if (GamePlay.MathKey == true)
            { // You've already won medium
                GMdialogue = "";
            }
            GamePlay.Talk($"Would you like to play a game?{GMdialogue}\n");
            var decision = Console.ReadLine();
            if (decision.Contains("yes") || decision.Contains("ok"))
            {
                Mathgame.MathgameStart();
            }
            else
            {
                GamePlay.Tavern();
            }
        }

        public void HangMan()
        {
            String GMdialogue = " There might be something in it for you if you complete my game..";
            if (GamePlay.HangmanKey == true)
            { // You've won medium already
                GMdialogue = "";
            }
            GamePlay.Talk($"Would you like to play hangman?{GMdialogue}\n");
            var decision = Console.ReadLine();
            if (decision.Contains("yes") || decision.Contains("ok"))
            {
                Hangman.HangmanStart();
            }
            else
            {
                GamePlay.Tavern();
            }
        }
    }
}