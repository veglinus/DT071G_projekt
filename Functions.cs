using System;
using System.Threading;
using System.Collections.Generic;

namespace CaveAdventure
{
    public partial class GamePlay {
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

        
    }
}