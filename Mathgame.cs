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
    public static void MathgameStart() {
        try
        {
            bool timeout = false;
            
            
            GamePlay.Talk("How skilled are ye, my friend? (Choose difficulty: Easy, medium, hard)\n");
            var difficulty = Console.ReadLine().ToLower();

            if (difficulty.Contains("easy")) {
                SetupGame(8000, 5, difficulty, "Right, easy it is. Let's see how fast you can do some simple multiplication.");
            } else if (difficulty.Contains("medium")) {
                SetupGame(5000, 7, difficulty, "This might be a bit of a challenge. Hang on.");
            } else if (difficulty.Contains("hard")) {
                SetupGame(4000, 10, difficulty, "I don't think you're gonna be good enough for this.");
            } else {
                GamePlay.Talk("Sorry, what was that?");
            }

            void SetupGame(int time, int rounds, string difficulty, string talkdif) {
                int progress = 0;
                int points = 0;

                GamePlay.Talk(talkdif);
                GamePlay.Talk("Be quick! I'm an impatient man.");
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
                        string fullinput = Console.ReadLine();
                        Timer.Stop();
                        progress++;

                        int input;
                        Int32.TryParse(fullinput, out input);
                        //Console.WriteLine($"progress: {progress} out of {rounds}");

                        if (input == solution || fullinput == "cheat") { // Correct answer
                    
                            if (timeout == true) { // But user too slow to 
                                GamePlay.Talk("That's correct! But you were a bit too slow..");
                            } else { // Correct answer in time
                                GamePlay.Talk($"That's correct!");
                                points++;
                            }

                        } else { // Wrong answer
                            GamePlay.Talk($"Oh dear, that's wrong. The correct answer was {solution}.");
                        }

                        CheckForEnd();
                    }
                    catch (System.Exception e)
                    {
                        Timer.Stop();
                        GamePlay.Talk($"Oh dear, that's wrong. The correct answer was {solution}.");
                        //Console.WriteLine("\nError: " + e);
                        CheckForEnd();
                    }

                    void CheckForEnd() {
                        Timer.Stop();
                        if (progress == rounds) { // Game is done

                            if ((difficulty == "medium" && points >= 5) || (difficulty == "hard" && points >= 6)) { // User wins key
                                GamePlay.Talk("You got the math key!\n");
                                GamePlay.MathKey = true;
                                GamePlay.Save();
                            } else {
                                GamePlay.Talk("Unfortunately that wasn't enough to win my prize..");
                            }

                            GamePlay.Talk($"Well done! You got {points} points out of {rounds}!");
                            GamePlay.Talk("Would you like to play again? (yes or no)\n");
                            var decision = Console.ReadLine();

                            if (decision.Contains("yes")) { // Play again
                                Console.Clear();
                                MathgameStart();
                            } else {
                                GamePlay.Tavern(); // Exit
                            }

                        } else { // Not done with game yet
                            GamePlay.Talk($"Let's try another..");
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
            Console.WriteLine("You trip over Walter, causing him to have to start the game over.");
            MathgameStart();
        }
    }
}