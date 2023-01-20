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
            //Here it takes the length of the word and makes _ depending on how many letters there are in the word
            int wordLength = genWord.Length;
            string print = "";
            for (int i = 0; i < wordLength; i++)
            {
                print += "_";
            }
            Console.WriteLine($"Welcome your word is {print}");
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