﻿using System;
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
            GamePlay.Intro();*/
            GamePlay.Outside();
            

            
            //Minigame.MinigameStart(); // For testing
            //System.Environment.Exit(1);
        }
    }

    class Data {
        
    }

    public partial class GamePlay
    {
            static string Name = "adventurer";
            static string Catchphrase = "Cowabunga!";

            static int Billy = 0;

            private static System.Timers.Timer Timer;

           static string Position = "Outside";

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
                Outside();
            }

            public static void ExitContext() {
                switch (Position)
                {
                    default:
                    Outside();
                    break;
                }
            }

            public static string UserInput() {
                var data = Console.ReadLine().ToLower();
                if (data.Contains("exit") || data.Contains("back")) {
                    Outside();
                    return "";
                } else {
                    return data;
                }
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
                Console.WriteLine("What would you like to do?\n");
                String action = Console.ReadLine().ToLower();

                if (action.Contains("house")) {
                    House();
                } else if (action.Contains("die")) {
                    Console.WriteLine("You are dead! Game over.");
                    System.Environment.Exit(1);
                } else if (action.Contains("tavern") ||action.Contains("bar")) {
                    Tavern();
                } else if (action.Contains("graveyard") ||action.Contains("grave")) {
                    Graveyard();
                
                } else {
                    Console.WriteLine("Sorry, I didn't quite catch that.");
                    Outside();
                }
            }


            public static void House() {
            String action;
            Console.Clear();
            Console.WriteLine("You're inside your cozy little house. In front of you is your bed, to the left is your stove and to the right is your wardrobe with a painting.");
            Wait();

                void Wait() {
                    Console.WriteLine("What would you like to do?\n");
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
                        Console.WriteLine("Nothing interesting happens. (Say EXIT to leave)");
                        Wait();
                    }
                }
            }


            public static void Tavern() {
                int Drunk = 0;
                String billyOption = "your neighbor Billy, ";

                Console.Clear();
                if (Billy != 3) {
                    billyOption = "";
                }
                Console.WriteLine($"You arrive at the tavern. You see {billyOption}the bartender, a gamemaster and a gang of thieves.\n");
                Console.WriteLine("Who would you like to interact with?\n");
                var option = Console.ReadLine().ToLower();

                if (option.Contains("billy")) {
                    BillyDialogue();
                } else if (option.Contains("bartender")) {
                    Console.WriteLine("You approach the bartender.");
                    BartenderDialogue();
                } else if (option.Contains("gang") || option.Contains("thieves")) {
                    ThievesDialogue();
                } else if (option.Contains("gamemaster")) {
                    GamemasterDialogue();
                } else if (option.Contains("exit") || option.Contains("back")) {
                    Exit();
                } else {
                    Nothing();
                }
                

                void BillyDialogue() {
                    Console.WriteLine("You approach your neighbor Billy!");

                    Talk("Howdy there neighbor! Boy you look like you're having an adventure. Are you doing alright?");
                    if (Billy == 0) {
                        Talk("Can I ask you for a favor? I havn't seen Nessie since last night. Give me a shout if you see her alright?");
                        Billy = 1;
                        Console.WriteLine("You nod and leave Billy. (Press any key to continue)");
                        Console.ReadLine();
                    } else if (Billy == 1) {
                        Talk("Have you caught a glimpse of my dog Nessie yet?");
                        Console.WriteLine("You shake your head and leave Billy. (Press any key to continue)");
                        Console.ReadLine();
                        Tavern();
                    } else if (Billy == 2) {
                        Talk("Have you caught a glimpse of my dog Nessie yet?");
                        Console.WriteLine("Where did you see the dog?");
                        var response = Console.ReadLine().ToLower();

                        if (response.Contains("graveyard")) {
                            Talk("She was at the graveyard?! Boy is she far from home. Thanks for helping out neighbor. Here's a little reward.");
                            Console.WriteLine("You got an old coin! (Press any key to continue)");
                            Console.ReadLine();
                            Billy = 3;
                            Tavern();
                        } else if (option.Contains("exit") || option.Contains("back")) {
                            Tavern();
                        } else {
                            Talk("No.. I don't think she would be there. You probably saw something else.");
                            Console.WriteLine("Billy looks sad. You better find his dog soon. You walk away. (Press any key to continue)");
                            Console.ReadLine();
                            Tavern();
                        }
                    }
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

                Console.WriteLine("You arrive at the graveyard. In front of you are several gravestones, maybe SOMEONE you know lies here.\n");
                Console.WriteLine("What would you like to do?\n");
                String input = Console.ReadLine().ToLower();
                if (input.Contains("papa") || input.Contains("dad")) {
                    Console.WriteLine("After a few minutes of searching you find your dad's grave.");
                    Console.WriteLine(gravestone);

                    Console.WriteLine("You look at the grave. What do you do?");
                    var input2 = Console.ReadLine();
                    if (input2.Contains("behind") || input2.Contains("search")) {
                        Console.WriteLine("You find a key lying just behind the gravestone. Perhaps this will become important later?");
                        Console.WriteLine("You say a prayer and leave the graveyard.");
                        Exit();
                    } else if (input.Contains("exit")|| input.Contains("back")) { 
                        Exit();
                    } else {
                        Console.WriteLine("Nothing interesting happens.");
                    }
                } else if (input.Contains("exit") || input.Contains("back")) {
                    Exit();
                } else {
                    Console.WriteLine("Nothing interesting happens.");
                }
            }

    }


}
