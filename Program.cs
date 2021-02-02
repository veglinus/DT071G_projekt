using System;
using System.Threading;
using System.Collections.Generic;

using System.Timers;

namespace CaveAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            GamePlay.StartSetup();

            System.Environment.Exit(1);
        }
    }

    class Data {
        
    }

    public static class GamePlay
    {
            static string Name;
            static string Catchphrase;

            private static System.Timers.Timer Timer;

            int Drunk;

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

            public static void writeSlow(string text)
            {
                Console.Write("\n");
                foreach(char letter in text) {
                    Console.Write(letter);
                    Thread.Sleep(50);
                }
            }

            public static void Exit() {
                Console.Clear();
                Console.Write("You leave.");
            }

            public static void Navigation() {
                Console.Write("Where do you want to go next?");
                var input = Console.ReadLine();
            }

            public static void Talk(string msg) {
                Console.ForegroundColor = ConsoleColor.Green;
                writeSlow(msg);
                Console.ResetColor();
            }

            public static void Nothing() {
                Console.WriteLine("Nothing interesting happens.");
            }

            public static void Tavern() {
                int Drunk = 0;

                Console.WriteLine("You arrive at the tavern. You see your neighbor Billy, the bartender and a gang of known thieves.");
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
                    var option = Console.ReadLine();

                    if (option.Contains("beer") || option.Contains("3")) {
                        Console.WriteLine("You order a beer and swig it fast.");
                        Drunk++;

                        if (Drunk <= 2) {
                            Console.WriteLine("Maybe it's time to stop now.");
                        } else if (Drunk == 5) {
                            Console.Clear();
                            Console.WriteLine("Oh dear, you pass out.");
                            // TODO: Set progress to 0
                            // TODO: Go to house House();
                        } else {
                            Console.WriteLine("You feel fine, for now.");
                        }
                    }
                }

                void ThievesDialogue() {

                }

                void Minigame() {
                    
                    
                    Talk("How skilled are ye, my friend? (Choose difficulty)");
                    var difficulty = Console.ReadLine();

                    if (difficulty.Contains("easy")) {
                        Easy();
                    } else if (difficulty.Contains("medium")) {
                        Medium();
                    } else if (difficulty.Contains("hard")) {
                        Hard();
                    } else {
                        Talk("Sorry, what was that?");
                    }

                    void NewTimer() {
                        Timer = new System.Timers.Timer(5000);
                        Timer.Elapsed += OnTimedEvent;
                        Timer.Enabled = true;
                    }
                    void OnTimedEvent(object source, ElapsedEventArgs e) {
                        Console.Write(e.SignalTime + "...");
                    }


                    void Easy() {
                        Console.WriteLine("Right, easy it is. Let's see how fast you can do some simple multiplication.");
                        System.Random random = new System.Random();

                        int x = random.Next(10);
                        int y = random.Next(10);
                        int solution = x * y;
                        System.Threading.Thread.Sleep(3000); // Wait
                        Console.Clear();

                        Console.WriteLine($"What is {x} times {y}?");
                        NewTimer();





                    }
                    void Medium() {

                    }
                    void Hard() {

                    }



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

                Console.WriteLine("You arrive at the graveyard. In front of you are several gravestones, maybe even SOMEONE you know lies here.");
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
