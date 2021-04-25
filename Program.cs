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
            */
            GamePlay.Outside();
            //GamePlay.Thief();
            //Mathgame.MathgameStart(); // For testing
            //Hangman.HangmanStart();
            //System.Environment.Exit(1);
        }
    }

    class Data {
        
    }

    public partial class GamePlay
    {
            public static string Name = "adventurer"; // Used for name
            public static string Catchphrase = "Cowabunga!"; // Catchphrase, used later
            public static int Billy = 0; // Billy dialogue progress
            static string Position = "Outside"; // Standard position of player
            private static System.Timers.Timer Timer; // Timer for Mathgame
            public static int Drunk = 0; // Used for drunkness
            public static int ThievesEncounter = 0;


            // All the keys needed to progress the game
            public static bool BillyKey = false;
            public static bool HangmanKey = false;
            public static bool MathKey = false;
            public static bool GraveKey = false;
            public static bool BraveKey = false;


            // General functions
            public static void writeSlow(string text)
            {
                Console.Write("\n");
                foreach(char letter in text) {
                    Console.Write(letter);
                    //Thread.Sleep(50);
                    Thread.Sleep(0);
                }
            }
            public static void Talk(string msg) {
                Console.ForegroundColor = ConsoleColor.Green;
                writeSlow(msg);
                Console.ResetColor();
            }
            public static void AwaitInput() {
                Console.WriteLine("\n\nPress any key to continue..\n");
                Console.ReadLine();
            }
            public static void Nothing() {
                Console.WriteLine("Nothing interesting happens.");
            }
            // End of general functions


            public static void StartSetup()
            {
                Console.WriteLine("Welcome adventurer! Before we begin, what is your name?\n");
                var newName = Console.ReadLine();
                if (newName != "") {
                    Name = newName;
                } else {
                    Console.WriteLine("Sorry I didn't quite catch that, let's try again.");
                    StartSetup();
                }
                List<String> inventory = new List<String>();

                Console.Clear();
                writeSlow($"Hello {Name}, I'm your guide on this adventure. I will try to interpret your words into actions in this game.\nI am the voice inside your head and more.");
                writeSlow($"\nLet's get this adventure started. It's a short one after all. Type in your catchphrase and let's go!\n");
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
                Console.WriteLine("\n\nPress any key to continue..\n");
                Console.ReadLine();
            }

            public static void Exit() {
                Console.Clear();
                Console.Write("You leave.");
                Outside();
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

            public static void Outside() {
                Console.Clear();
                Console.WriteLine("You're outside of your house.\nYou can go to your house, the bar, graveyard or cave.");
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
                } else if (action.Contains("cave")) {
                    Cave();
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
                    if (action.Contains("right") || action.Contains("wardrobe")) {
                        Console.WriteLine("You face the WARDROBE. In front of you is a PAINTING of your grand-grand-grand-father and your WARDROBE is underneath. Maybe it's worth taking an extra LOOK at?");
                        Wait();
                    } else if (action.Contains("wardrobe")) {
                        Console.WriteLine("You search your wardrobe. Nothing is out of the ordinary.");
                        Wait();
                    } else if (action.Contains("painting") || action.Contains("search") || action.Contains("look")) {
                        Console.WriteLine("You search the painting. On the back is an old note your grandfather left you.");
                        Console.Write($"\n-----------------------------------------------------------");
                        Console.Write($"\nTO {Name}, FROM GRAMPA\n\n");
                        Console.Write("\nI KNOW YOU DIDN'T LIKE YOUR DAD, BUT HE WAS A GOOD MAN.");
                        Console.Write("\nI KNOW YOU NEVER VISIT HIS GRAVE- ");
                        Console.Write("\nBUT WHEN YOU FEEL READY YOU SHOULD.");
                        Console.Write("\nHE NEVER GOT TO GIVE YOU THAT GIFT AFTER ALL.");
                        Console.Write("\nCHECK UNDER THE FLOWERS. YOU WONT REGFRET IT.");
                        Console.Write("\n\nLOVE, GRAMPA\n");
                        Console.WriteLine("Perhaps you should follow grampas advice?");
                        Wait();
                    } else if (action.Contains("back") || action.Contains("return") || action.Contains("outside") || action.Contains("exit")) {
                        Outside();
                    } else {
                        Console.WriteLine("Nothing interesting happens. (Say EXIT to leave)");
                        Wait();
                    }
                }
            }

            public static void Cave() {
                Console.WriteLine("You arrive at the opening to the cave. It's blocked by a door, which seems to need 3 keys to open. The door says:");
                Console.WriteLine("A KEY FOR THE KINDNESS OF YOUR HEART");
                Console.WriteLine("A KEY FROM THE MOST LOVED ONE");
                Console.WriteLine("A KEY FOR YOUR WISDOM, PERHAPS EVEN LUCK");
                Console.WriteLine("A KEY FOR KNOWLEDGE");
                Console.WriteLine("AND A KEY FROM THE BRAVE");
                Console.WriteLine("THY WHICH SITS ON ALL KEYS SHALL BE GREATLY REWARDED\n");


                var choice = UserInput();
                if (choice == "Simsalabim") {
                    // TODO: Ending
                    GamePlay.Talk("Congratulations! You've won!");
                } else if (choice.Contains("back") || choice.Contains("return") || choice.Contains("outside") || choice.Contains("exit")) {
                    Outside();
                } else {
                    Cave();
                }
            }

            public static void Tavern() {
                String billyOption = "your neighbor Billy, "; // If user has interactions left with Billy

                Console.Clear();
                if (Billy != 3) { // Clear billy option when his quest is complete
                    billyOption = "";
                }
                Console.WriteLine($"You arrive at the tavern. You see {billyOption}the bartender, Mark the hangman, Dessie the mathematician and a gang of thieves.\n");
                Console.WriteLine("Who would you like to interact with?\n");
                var option = Console.ReadLine().ToLower();

                if (option.Contains("billy")) { // Choose who to speak to
                    new Dialogue().Billy();
                } else if (option.Contains("bartender")) {
                    Console.WriteLine("You approach the bartender.");
                    new Dialogue().Bartender();
                } else if (option.Contains("mathematician") || option.Contains("dessie")) {
                    new Dialogue().Mathematician();
                } else if (option.Contains("hangman") || option.Contains("mark")) {
                    new Dialogue().HangMan();
                } else if (option.Contains("exit") || option.Contains("back")) {

                    if (ThievesEncounter == 0) { // Random encounter chance to run into the thief encounter
                        var chance = new Random().Next(0, 10);
                        if (chance > 5 || option.Contains("random")) { // If lucky or user forced the random option, go to thief scenario
                            new ThiefEncounter().Thief();
                        }
                    } else {
                        Exit();
                    }
                    
                } else {
                    Nothing();
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
                    GraveStone();

                    void GraveStone() {
                        Console.WriteLine("You look at the grave. What do you do?\n");
                        var input2 = Console.ReadLine().ToLower();
                        if (input2.Contains("behind") || input2.Contains("search")) {
                            Console.WriteLine("You find a key lying just behind the gravestone. Perhaps this will become important later?");
                            Console.WriteLine("You say a prayer and leave.");
                            GraveKey = true;
                            GraveStone();
                        } else if (input.Contains("exit")|| input.Contains("back")) { 
                            Graveyard();
                        } else {
                            Console.WriteLine("Nothing interesting happens.");
                            GraveStone();
                        }
                    }

                } else if (input.Contains("exit") || input.Contains("back")) {
                    Exit();
                } else {
                    Console.WriteLine("Nothing interesting happens.");
                    Graveyard();
                }
            }

    }
}