using System;
using System.Collections.Generic;
using System.IO;

namespace FalloutHackingGame
{
    class FalloutHackingGame
    {
        // Difficulties
        //
        // 1    Very Easy   5-6 words       4-5 characters each
        // 2    Easy        7-8 words       6-8 characters each
        // 3    Average     9-11 words      9-10 characters each
        // 4    Hard        12-13 words     11-13 characters each
        // 5    Very Hard   14-15 words     14-15 characters each

        private Random random = new Random();

        private int numWords,
                    charactersPerWord;

        private string fileName = "enable1.txt",
                       password;

        private List<string> words = new List<string>(); // stored in uppercase

        public FalloutHackingGame() : this(3) { }

        public FalloutHackingGame(int difficulty)
        {
            //this.difficulty = difficulty;

            switch (difficulty)
            {
                default:
                case 1:
                    numWords = random.Next(5, 7);
                    charactersPerWord = random.Next(4, 6);
                    break;
                case 2:
                    numWords = random.Next(7, 9);
                    charactersPerWord = random.Next(6, 9);
                    break;
                case 3:
                    numWords = random.Next(9, 12);
                    charactersPerWord = random.Next(9, 11);
                    break;
                case 4:
                    numWords = random.Next(12, 14);
                    charactersPerWord = random.Next(11, 14);
                    break;
                case 5:
                    numWords = random.Next(14, 16);
                    charactersPerWord = random.Next(14, 16);
                    break;
            }

            GetWordsFromFile(fileName);
        }

        public void Play()
        {
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            for (int guesses = 4; guesses > 0; guesses--)
            {
                Console.Write("Guess ({0} left)? ", guesses);
                string guess = Console.ReadLine().ToUpper();

                if (guess.Length != charactersPerWord)
                {
                    Console.WriteLine("The word you entered is not the correct length. Try again");
                    guesses++;
                    continue;
                }

                int numCorrectCharacters = 0;
                for (int i=0; i<guess.Length; i++)
                {
                    if (guess[i] == password[i])
                    {
                        numCorrectCharacters++;
                    }
                }
                Console.WriteLine("{0}/{1} correct", numCorrectCharacters, charactersPerWord);

                if (numCorrectCharacters == charactersPerWord)
                {
                    Console.WriteLine("You win!");
                    return;
                }
            }
            Console.WriteLine("You lose! The correct password was: {0}", password);
        }

        private void GetWordsFromFile(string fileName)
        {
            string[] allWords = File.ReadAllLines(fileName);

            while (words.Count < numWords)
            {
                string nextWord = allWords[random.Next(allWords.Length)];

                if (nextWord.Length == charactersPerWord)
                {
                    words.Add(nextWord.ToUpper());
                }
            }
            password = words[random.Next(words.Count)];
        }
    }
}
