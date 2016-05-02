using System;

namespace FalloutHackingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Difficulty(1 - 5)? ");
                try
                {
                    int difficulty = int.Parse(Console.ReadLine());
                    FalloutHackingGame game = new FalloutHackingGame(difficulty);
                    game.Play();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect Value Entered. Try again");
                }
            }
        }
    }
}
