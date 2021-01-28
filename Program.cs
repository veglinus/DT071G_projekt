using System;
using System.Threading;
using System.Collections.Generic;

namespace CaveAdventure
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome adventurer! Before we begin, what is your name?\n");
            String name = Console.ReadLine();
            List<String> inventory = new List<String>();

            Console.Clear();
            writeSlow($"Hello {name}, I'm your guide on this adventure. I will try to interpret your words into actions in this game.\nI am the voice inside your head and more.");
            writeSlow($"\nLet's get this adventure started. It's a short one after all. Type in your catchphrase and let's go!");
            String catchphrase = Console.ReadLine();


            Console.Clear();
            if(catchphrase.EndsWith("!") || catchphrase.EndsWith("."))
            {
                catchphrase = catchphrase.Remove(catchphrase.Length - 1, 1);  
            }
            writeSlow($"{catchphrase}! I couldn't have said it better myself.");

            System.Environment.Exit(1);


            void writeSlow(string text) {
                Console.Write("\n");
                foreach(char letter in text) {
                    Console.Write(letter);
                    Thread.Sleep(50);
                }
            }

            
        }
    }
}
