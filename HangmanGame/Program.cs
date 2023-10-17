namespace HangmanGame
{
     class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("-------------------");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            Console.Clear();
            
            string[] words =
            {
                "apple", "banana", "orange", "pear", "grape",
                "pineapple", "strawberry", "blueberry", "raspberry", "blackberry",
                "watermelon", "cantaloupe", "honeydew", "kiwi", "mango",
                "cherry", "peach", "plum", "apricot", "pomegranate",
                "lemon", "lime", "coconut", "avocado", "dragonfruit",
                "fig", "grapefruit", "guava", "lychee", "papaya",
                "persimmon", "starfruit", "tangerine", "tomato", "breadfruit",
                "durian", "jackfruit", "kumquat", "mangosteen", "nectarine",
                "olive", "pumpkin", "rhubarb", "ugli", "yuzu", "computer",
                "laptop", "mouse", "keyboard", "monitor", "printer",
                "bread", "bagel", "muffin", "croissant", "pretzel",
                "waffle", "pancake", "french toast", "crepe", "biscuit",
            };
            Random random = new Random();
            string wordToGuess = words[random.Next(0, words.Length)];
            char[] wordToGuessArray = wordToGuess.ToCharArray();
            char[] wordToGuessArrayHidden = wordToGuess.ToCharArray();
            
            for (int i = 0; i < wordToGuessArrayHidden.Length; i++)
            {
                wordToGuessArrayHidden[i] = '_';
            }
            
            int lives = 5;
            bool won = false;
            List<char> guessedLetters = new List<char>();
            
            while (lives > 0 && !won)
            {
                Console.WriteLine("Lives: " + lives);
                Console.WriteLine("Guessed letters: " + string.Join(",", guessedLetters));
                Console.WriteLine("Guess the word: " + string.Join(" ", wordToGuessArrayHidden));
                Console.Write("Guess a letter: ");
                char guessedLetter = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (guessedLetters.Contains(guessedLetter))
                {
                    Console.WriteLine("You already guessed that letter!");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                guessedLetters.Add(guessedLetter);
                if (wordToGuessArray.Contains(guessedLetter))
                {
                    Console.WriteLine("Correct!");
                    for (int i = 0; i < wordToGuessArray.Length; i++)
                    {
                        if (wordToGuessArray[i] == guessedLetter)
                        {
                            wordToGuessArrayHidden[i] = guessedLetter;
                        }
                    }
                    if (!wordToGuessArrayHidden.Contains('_'))
                    {
                        won = true;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                    lives--;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            
            if (won)
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine("You lost!");
            }
            Console.WriteLine("The word was: " + wordToGuess);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}