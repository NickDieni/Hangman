using System.Diagnostics;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace Hangman
{

    public class Program
    {
        
        static void Main(string[] args)
        {
            //Here I create a object so I can call into the Word method and use it
            Wordmaker myClass = new Wordmaker();
            myClass.Word();
            string randomWord = myClass.Word();
            string genWord = randomWord.ToLower();
            Console.WriteLine("Word has been generated press a button to continue");
            Console.ReadKey();
            Console.Clear();
            Game(genWord);
        }

        static void Game(string genWord)
        {
            char[] wordLetters = genWord.ToCharArray();

            //Here it takes the length of the word and makes _ depending on how many letters there are in the word
            string blankword = new string('_', genWord.Length);
            Console.WriteLine($"Welcome your word is {blankword}");
            Console.WriteLine("");
            Console.Write("Guess a letter that is in the word: ");
            

            bool isReady = blankword.Contains("_");
            while (blankword.Contains("_"))
            {
                string guess = Console.ReadLine();

                if (genWord.Contains(guess))
                {
                    for (int i = 0; i < genWord.Length; i++)
                    {
                        if (genWord[i] == guess[0])
                        {
                            blankword = blankword.Remove(i, 1).Insert(i, guess);
                        }
                    }
                    Console.Clear();
                    Console.WriteLine($"Correct!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect!");
                    
                }
                Console.WriteLine($"The word is {blankword}");
                Console.WriteLine();
                Console.Write("Guess another letter: ");
            }
            Console.WriteLine($"Congratulations, you guessed the word! The word was \"{blankword}\"");
        }
    }

    public class Wordmaker
    {
    public string? randomWord;
        public string Word()
        {
            string sti = @"C:\Datamappe", datafil = @"C:\Datamappe\WordList.txt"; ;

            //Here it check if the file already exists or not
            if (!File.Exists(datafil))
            {
                Directory.CreateDirectory(sti);
                File.WriteAllText(datafil, "hill\r\ntooth\r\nmetal\r\ndivision\r\nsack\r\nsisters\r\ntendency\r\ntime\r\nborder\r\nchicken\r\ndesk\r\nprice");
            }
            else if (File.Exists(datafil))
            {
                File.Delete(datafil);
                Directory.CreateDirectory(sti);
                File.AppendAllText(datafil, "hill\r\ntooth\r\nmetal\r\ndivision\r\nsack\r\nsisters\r\ntendency\r\ntime\r\nborder\r\nchicken\r\ndesk\r\nprice");
            }
            //Here it takes a random word from the list that is created 
            string[] lines = File.ReadAllLines(datafil);
            Random random = new Random();
            int randomIndex = random.Next(lines.Length);
            randomWord = lines[randomIndex];
            //Here i return the randomWord back to Main
            return randomWord;
        }
    }
}   
