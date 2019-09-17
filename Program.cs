using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            String tryAgain = "yes";
            List<String> wordBank = new List<String>();
            wordBank.Add("string");
            wordBank.Add("lotus");
            do
            {
                Console.WriteLine("\nHere's a simple game of hangman: \nGiven the length of a word, please guess the word by entering a letter each time. \nThere are already " + wordBank.Count + " premade words.");
                Console.Write("\nWould you like to input your own words? ");
                String userIn = Console.ReadLine();
                while (!userIn.ToLower().Equals("yes") && !userIn.ToLower().Equals("no"))
                {
                    Console.Write("Invalid answer. Yes or No? ");
                    userIn = Console.ReadLine();
                    if (userIn.ToUpper().Equals("YES"))
                    {
                        Console.Write("Please input your word: ");
                        String wordsIn = Console.ReadLine();
                        while (invalidWord(wordsIn))
                        {
                            Console.Write("Please enter a valid word: ");
                            wordsIn = Console.ReadLine();
                        }
                        while (repeatWord(wordBank, wordsIn))
                        {
                            Console.Write("Already a word in the list! Add a different one: ");
                            wordsIn = Console.ReadLine();
                        }
                        wordBank.Add(wordsIn);
                        Console.Write("\nWould you like to include more words? ");
                        userIn = Console.ReadLine();
                    }
                }
                String word = getWord(wordBank);
                char[] guess = new char[word.Length];
                for (int i = 0; i < guess.Length; i++)
                {
                    guess[i] = '-';
                }
                String s1 = printCharArr(guess);
                int wrong = 0;
                while (!s1.Equals(word) && wrong < 6)
                {
                    Console.Write("\n\n" + s1 + " Length: " + word.Length + "\nYou have " + (6 - wrong) + " more guesses. \n" + hangman(wrong) + "Guess a letter: ");
                    String c = Console.ReadLine();
                    while ((c.Length != 1) || !c.Any(char.IsLetter))
                    {
                        Console.Write("Please enter a valid letter: ");
                        c = Console.ReadLine();
                    }
                    char guessedL = char.Parse(c);
                    if (!word.Contains(guessedL))
                    {
                        wrong++;
                    }
                    else
                    {
                        for (int i = 0; i < word.Length; i++)
                        {
                            if (guessedL == word[i])
                            {
                                guess[i] = guessedL;
                            }
                        }
                    }
                    s1 = printCharArr(guess);
                }
                if (wrong == 6)
                    Console.WriteLine("\n" + hangman(wrong));
                Console.Write("\n\nWord: " + word + " Try Again? ");
                tryAgain = Console.ReadLine();
                while (!tryAgain.ToLower().Equals("yes") && !tryAgain.ToLower().Equals("no"))
                {
                    Console.Write("Invalid answer. Yes or No? ");
                    tryAgain = Console.ReadLine();
                }
            }
            while (tryAgain.ToUpper().Equals("YES"));
        }

        static String getWord(List<String> w)
        {
            Random r = new Random();
            int n = r.Next(0, w.Count - 1);
            String word = w[n];
            return word;
        }

        static String printCharArr(char[] c)
        {
            String s = "";
            for (int i = 0; i < c.Length; i++)
            {
                s += c[i];
            }
            return s;
        }

        static bool invalidWord(String s)
        {
            if (!s.All(char.IsLetter))
                return true;
            if (s.Length == 0)
                return true;
            if (s.Any(char.IsDigit))
                return true;
            return false;
        }

        static bool repeatWord(List<String> w, String s)
        {
            for (int i = 0; i < w.Count; i++)
            {
                if (w[i].Equals(s))
                    return true;
            }
            return false;
        }

        static String hangman(int count)
        {
            switch (count)
            {
                case 1:
                    return "______________\n" +
                           "|      |      \n" +
                           "|      O      \n" +
                           "|             \n" +
                           "|             \n" +
                           "|             \n";
                case 2:
                    return "______________\n" +
                           "|      |      \n" +
                           "|      O      \n" +
                           "|      |      \n" +
                           "|             \n" +
                           "|             \n";
                case 3: 
                    return "______________\n" +
                           "|      |      \n" +
                           "|      O      \n" +
                           "|     /|      \n" +
                           "|             \n" +
                           "|             \n";
                case 4:
                    return "______________\n" +
                           "|      |      \n" +
                           "|      O      \n" +
                           "|     /|\\     \n" +
                           "|             \n" +
                           "|             \n";
                case 5:
                    return "______________\n" +
                           "|      |      \n" +
                           "|      O      \n" +
                           "|     /|\\     \n" +
                           "|     /       \n" +
                           "|             \n";
                case 6:
                    return "______________\n" +
                           "|      |      \n" +
                           "|      O      \n" +
                           "|     /|\\     \n" +
                           "|     / \\     \n" +
                           "|             \n" +
                           "Look what you did :(";
                default:
                    return "______________\n" +
                           "|      |      \n" +
                           "|             \n" +
                           "|             \n" +
                           "|             \n" +
                           "|             \n"; ;
            }
        }
    }
}
