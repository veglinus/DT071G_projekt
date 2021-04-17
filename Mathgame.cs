using System;
using System.Threading;
using System.Timers;
using CaveAdventure;

/*
TODO:

enter causes crash while waiting for number

*/
public static class Mathgame
{
    private static System.Timers.Timer Timer;

    public static void writeSlow(string text)
    {
        Console.Write("\n");
        foreach(char letter in text) {
            Console.Write(letter);
            Thread.Sleep(50);
        }
    }

    public static void Talk(string msg) {
        Console.ForegroundColor = ConsoleColor.Green;
        writeSlow(msg);
        Console.ResetColor();
    }
    public static void MathgameStart() {
        try
        {
            bool timeout = false;
            
            
            Talk("How skilled are ye, my friend? (Choose difficulty: Easy, medium, hard)\n");
            var difficulty = Console.ReadLine().ToLower();

            if (difficulty.Contains("easy")) {
                SetupGame(5000, 5, "Right, easy it is. Let's see how fast you can do some simple multiplication.");
            } else if (difficulty.Contains("medium")) {
                SetupGame(3000, 10, "This might be a bit of a challenge. Hang on.");
            } else if (difficulty.Contains("hard")) {
                SetupGame(2500, 15, "I don't think you're gonna be good enough for this.");
            } else {
                Talk("Sorry, what was that?");
            }

            void SetupGame(int time, int rounds, string difficulty) {
                int progress = 0;
                int points = 0;

                Talk(difficulty);
                Talk("Be quick! I'm an impatient man.");
                NewRound();

                void NewRound() {
                    int timeleft = time / 1000;

                    timeout = false; // Reset timeout
                    System.Random random = new System.Random();
                    int x = random.Next(10);
                    int y = random.Next(10);
                    int solution = x * y;
                    System.Threading.Thread.Sleep(1500); // Wait
                    Console.Clear();

                    Console.WriteLine($"What is {x} times {y}? Time left: {timeleft}");
                    NewTimer();

                    try
                    {
                        int input = Convert.ToInt32(Console.ReadLine());
                        Timer.Stop();
                        progress++;
                        //Console.WriteLine($"progress: {progress} out of {rounds}");

                        if (input == solution) { // Correct answer
                    
                            if (timeout == true) { // But user too slow to 
                                Talk("That's correct! But you were a bit too slow..");
                            } else { // Correct answer in time
                                Talk($"That's correct!");
                                points++;
                            }
                        
                        } else { // Wrong answer
                            Talk($"Oh dear, that's wrong. The correct answer was {solution}.");
                        }

                        CheckForEnd();
                    }
                    catch (System.Exception)
                    {
                        Talk($"Oh dear, that's wrong. The correct answer was {solution}.");
                        CheckForEnd();
                    }

                    void CheckForEnd() {
                        if (progress == rounds) { // klar med game
                            Talk($"Well done! You got {points} points out of {rounds}!");
                            Talk("Would you like to play again? (yes or no)\n");
                            var decision = Console.ReadLine();

                            if (difficulty == "medium" && points > 8 || difficulty == "hard" && points > 8) { // User wins coin
                                // TODO: add reward coin
                            }
                            if (decision.Contains("yes")) {
                                Console.Clear();
                                MathgameStart();
                            } else {
                                GamePlay.Exit();
                            }

                        } else { // inte klar med game
                            Talk($"Let's try another..");
                            NewRound();
                        }
                    }

                    void NewTimer() { // New timer
                        Timer = new System.Timers.Timer(time);
                        Timer.Elapsed += OnTimedEvent; // Event to change time 
                        Timer.Enabled = true;
                        Timer.Interval = 1000;
                    }
                    void OnTimedEvent(object source, ElapsedEventArgs e) {
                        timeleft--;
                        var lastLeft = Console.CursorLeft; // Saves position of cursor before moving to renew time
                        var lastTop = Console.CursorTop;

                        Console.CursorVisible = false; // Prevents flashing when changing cursor position
                        Console.SetCursorPosition(31, 0); 
                        Console.Write($"\b{timeleft}"); // Removes last number and adds remaining time left
                        Console.SetCursorPosition(lastLeft, lastTop);
                        Console.CursorVisible = true; // Prevents flashing when changing cursor position

                        if (timeleft == 0) {
                            timeout = true;
                            Timer.Stop();
                        }
                        //Console.WriteLine("You take a while longer than Billy would like you to.");
                    }
                }
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("You trip over Dessie, causing him to have to start the game over.");
            MathgameStart();
        }
    }
}