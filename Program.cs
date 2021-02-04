using System;
using System.Threading;
using System.Collections.Generic;


namespace CaveAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            GamePlay.StartSetup();
            GamePlay.Intro();
            GamePlay.Outside();
            */

            
            Minigame.MinigameStart(); // For testing
            //System.Environment.Exit(1);
        }
    }

    class Data {
        
    }

    public partial class GamePlay
    {
            static string Name = "adventurer";
            static string Catchphrase = "Cowabunga!";

            private static System.Timers.Timer Timer;

            //int Drunk;

            public static void StartSetup()
            {
                Console.WriteLine("Welcome adventurer! Before we begin, what is your name?\n");
                Name = Console.ReadLine();
                List<String> inventory = new List<String>();

                Console.Clear();
                writeSlow($"Hello {Name}, I'm your guide on this adventure. I will try to interpret your words into actions in this game.\nI am the voice inside your head and more.");
                writeSlow($"\nLet's get this adventure started. It's a short one after all. Type in your catchphrase and let's go!");
                Catchphrase = Console.ReadLine();

                Console.Clear();
                if(Catchphrase.EndsWith("!") || Catchphrase.EndsWith("."))
                {
                    Catchphrase = Catchphrase.Remove(Catchphrase.Length - 1, 1);  
                }
                writeSlow($"{Catchphrase}! I couldn't have said it better myself.");
            }

            public static void Intro() {
                writeSlow($"You're a lone adventurer and wake up inside of your house. You've had many great adventures before in your life {Name}, but there has always been one that you havn't solved.");
                writeSlow($"To the south-west of your house is a cave. There's a door with a number combination on it that you've never been able to figure out.");
                writeSlow($"Perhaps someone in your town knows more?\nYou step outside your door, today is the day you get past that door.");
                Console.WriteLine("\n\n");
            }

            public static void Exit() {
                Console.Clear();
                Console.Write("You leave.");
            }
            public static void Navigation() {
                Console.Write("Where do you want to go next?");
                var input = Console.ReadLine();
            }
            public static void Nothing() {
                Console.WriteLine("Nothing interesting happens.");
            }
            public static void Outside() {
                Console.Clear();
                Console.WriteLine("You're outside of your HOUSE.\n");
                Console.WriteLine("What do you like to do?\n");
                String action = Console.ReadLine().ToLower();

                if (action.Contains("house")) {
                    House();
                } else if (action.Contains("die")) {
                    Console.WriteLine("You are dead! Game over.");
                    System.Environment.Exit(1);
                }
            }


            public static void House() {
            String action;
            Console.WriteLine("You're inside your cozy little house. In front of you is your bed, to the left is your stove and to the right is your wardrobe with a painting.");
            Wait();

                void Wait() {
                    Console.WriteLine("What do you like to do?\n");
                    action = Console.ReadLine().ToLower();
                    act();
                }

                void act() {
                    if (action.Contains("right")) {
                        Console.WriteLine("You face the WARDROBE. In front of you is a PAINTING of your grand-grand-grand-father and your WARDROBE is underneath. Maybe it's worth taking an extra LOOK at?");
                        Wait();
                    } else if (action.Contains("wardrobe")) {
                        Console.WriteLine("You search your wardrobe. Nothing is out of the ordinary.");
                        Wait();
                    } else if (action.Contains("painting") || action.Contains("search") || action.Contains("look")) {
                        Console.WriteLine("You search the painting. On the back is an old note your grandfather left you.");
                        Console.Write($"\n-----------------------------------------------------------");
                        Console.Write("\nTO {name}, FROM GRAMPA\n\n");
                        Console.Write("\nI KNOW YOU DIDN'T LIKE YOUR DAD, BUT HE WAS A GOOD MAN.");
                        Console.Write("\nI KNOW YOU NEVER VISIT HIS GRAVE- ");
                        Console.Write("\nBUT WHEN YOU FEEL READY YOU SHOULD.");
                        Console.Write("\nHE NEVER GOT TO GIVE YOU THAT GIFT AFTER ALL.");
                        Console.Write("\nCHECK UNDER THE FLOWERS. YOU WONT REGFRET IT.");
                        Console.Write("\n\nLOVE, GRAMPA");
                        Console.WriteLine("Perhaps you should follow grampas advice?");
                        Wait();
                    } else if (action.Contains("back") || action.Contains("return") || action.Contains("outside")) {
                        Outside();
                    } else {
                        Console.WriteLine("Nothing interesting happens.");
                    }


                }
            }


            public static void Tavern() {
                int Drunk = 0;

                Console.WriteLine("You arrive at the tavern. You see your neighbor Billy, the bartender, a gamemaster and a gang of thieves.");
                Console.WriteLine("Who would you like to interact with?");
                var option = Console.ReadLine();
                if (option.Contains("exit")) {
                    Exit();
                } else {
                    if (option.Contains("Billy")) {
                        BillyDialogue();
                    } else if (option.Contains("bartender")) {
                        Console.WriteLine("You approach the bartender.");
                        BartenderDialogue();
                    } else if (option.Contains("gang") || option.Contains("thieves")) {
                        ThievesDialogue();
                    } else if (option.Contains("gamemaster")) {
                        GamemasterDialogue();
                    } else {
                        Nothing();
                    }
                }

                void BillyDialogue() {
                    Console.WriteLine("You approach your neighbor Billy!");
                    Talk("Howdy there neighbor! Boy you look like you're having an adventure. Are you doing alright?");
                }

                void BartenderDialogue() {
                    Talk("Hello there, what can I do for ya?");
                    Console.WriteLine("1) Beer, 2) Gossip, 3) Beer");
                    var option = Console.ReadLine().ToLower();

                    if (option.Contains("beer") || option.Contains("3") || option.Contains("drink")) {
                        Console.WriteLine("The bartender gives you a beer and you swig it fast.");
                        Drunk++;

                        if (Drunk <= 2) {
                            Console.WriteLine("Maybe it's time to stop now.");
                        } else if (Drunk == 5) {
                            Console.Clear();
                            Console.WriteLine("Oh dear, you pass out. Somehow you end up at your house.");
                            House();
                        } else {
                            Console.WriteLine("You feel fine, for now.");
                        }
                    }
                }

                void GamemasterDialogue() {
                    Talk("Would you like to play a game?");
                    var decision = Console.ReadLine();
                    if (decision.Contains("yes")) {
                        Minigame.MinigameStart();
                    } else {
                        Exit();
                    }
                }

                void ThievesDialogue() {

                }
            }
            
            public static void Graveyard() {
                string gravestone = @"
                              _______
                        _____/      \\_____
                        |  _     ___   _   ||
                        | | \     |   | \  ||
                        | |  |    |   |  | ||
                        | |_/     |   |_/  ||
                        | | \     |   |    ||
                        | |  \    |   |    ||
                        | |   \. _|_. | .  ||
                        |                  ||
                        |  BEST DAD EVER   ||
                        |                  ||
                *       | *   **    * **   |**      **
                    \))/.,(//,,..,,\||(,,.,\\,.((//
                ";
                // if progress in story is correct

                Console.WriteLine("You arrive at the graveyard. In front of you are several gravestones, maybe SOMEONE you know lies here.");
                var input = Console.ReadLine();
                if (input.Contains("") || input.Contains("dad")) {
                    Console.WriteLine("After a few minutes of searching you find your dad's grave.");
                    Console.WriteLine(gravestone);

                    Console.WriteLine("You look at the grave. What do you do?");
                    var input2 = Console.ReadLine();
                    if (input2.Contains("behind") || input2.Contains("search")) {
                        Console.WriteLine("You find a key lying just behind the gravestone. Perhaps this will become important later?");
                        Console.WriteLine("You say a prayer and leave the graveyard.");
                        Exit();
                    } else if (input.Contains("exit")) { 
                        Exit();
                    } else {
                        Console.WriteLine("Nothing interesting happens.");
                    }
                } else if (input.Contains("exit")) {
                    Exit();
                } else {
                    Console.WriteLine("Nothing interesting happens.");
                }
            }

    }


}
