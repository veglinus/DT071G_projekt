using System;
using System.Threading;
using System.Collections.Generic;

namespace CaveAdventure
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Welcome adventurer! Before we begin, what is your name?\n");
            String name = Console.ReadLine();
            List<String> inventory = new List<String>();

            Console.Clear();
            writeSlow($"Hello {name}, I'm your guide on this adventure. I will try to interpret your words into actions in this game.\nI am the voice inside your head and more.");
            writeSlow($"\nLet's get this adventure started. It's a short one after all. Type in your catchphrase and let's go!\n");
            String catchphrase = Console.ReadLine();


            Console.Clear();
            if(catchphrase.EndsWith("!") || catchphrase.EndsWith("."))
            {
                catchphrase = catchphrase.Remove(catchphrase.Length - 1, 1);  
            }
            writeSlow($"{catchphrase}! I couldn't have said it better myself.");


            // fade to black and intro text

            writeSlow($"You're a lone adventurer and wake up inside of your house. You've had many great adventures before in your life {name}, but there has always been one that you havn't solved.");
            writeSlow($"To the south-west of your house is a cave. There's a door with a number combination on it that you've never been able to figure out.");
            writeSlow($"Perhaps someone in your town knows more?\nYou step outside your door, today is the day you get past that door.");
            Console.WriteLine("\n\n");
            Console.WriteLine("You're outside of your HOUSE. What would you like to do?\n");

            String action = Console.ReadLine();



            void displayMap() {
                Console.Clear();
                 
            }


            void outside() {
                Console.Clear();
                Console.WriteLine("You're outside of your HOUSE.\n");
                Console.WriteLine("What do you like to do?\n");
                String action = Console.ReadLine();

                if (action.Contains("house")) {
                    house();
                } else if (action.Contains("die")) {
                    Console.WriteLine("You are dead! Game over.");
                    System.Environment.Exit(1);
                }
            }


            void house() {
            String action;
            Console.WriteLine("You're inside your cozy little house. In front of you is your bed, to the left is your stove and to the right is your wardrobe with a painting.");
            wait();

                void wait() {
                    Console.WriteLine("What do you like to do?\n");
                    action = Console.ReadLine();
                    act();
                }


                void act() {
                    if (action.Contains("right")) {
                        Console.WriteLine("You face the WARDROBE. In front of you is a PAINTING of your grand-grand-grand-father and your WARDROBE is underneath. Maybe it's worth taking an extra LOOK at?");
                        wait();
                    } else if (action.Contains("wardrobe")) {
                        Console.WriteLine("You search your wardrobe. Nothing is out of the ordinary.");
                        wait();
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
                        wait();
                    } else if (action.Contains("back") || action.Contains("return") || action.Contains("outside")) {
                        outside();
                    } else {
                        Console.WriteLine("Nothing interesting happens.");
                    }

                    
                }
            }


            void movement() {
                // Positioning system, coordinates (x, y)
                int X = 0;
                int Y = 0;
                var keypressed = Console.ReadKey(true).Key;
                switch (keypressed)
                { // switch case for what key is pressed by user
                    case ConsoleKey.UpArrow:
                        X++;
                        break;
                    case ConsoleKey.DownArrow:
                        X--;
                        break;
                    case ConsoleKey.RightArrow:
                        Y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        Y--;
                        break;
                    default: // Any other key simply exits program
                        break;
                }
            }

            void writeSlow(string text) {
                Console.Write("\n");
                foreach(char letter in text) {
                    Console.Write(letter);
                    //Thread.Sleep(50);
                    Thread.Sleep(0);
                }
            }

            
        }
    }
}
