using System;
using System.Collections.Generic;
using System.Text;

namespace hangman_v1
{
    class Game
    {
        private Word full_word;
        private string masked_word;
        private List<Word> list_words;
        private List<char> list_char_yes;
        private List<char> list_char_no;
        private bool victory;
        private int number_fail = 10;

        public Game()
        {
            list_words = new List<Word>();
            Word word1 = new Word("bike"); list_words.Add(word1);
            Word word2 = new Word("car"); list_words.Add(word2);
            Word word3 = new Word("mountain"); list_words.Add(word3);
            Word word4 = new Word("river"); list_words.Add(word4);
            Word word5 = new Word("electric"); list_words.Add(word5);

            Random random = new Random();
            full_word = list_words[random.Next(0, list_words.Count)];

            list_char_yes = new List<char>();
            list_char_no = new List<char>();

            masked_word = Mask(full_word);

            victory = false;
        }

        private string Mask(Word p_word)
        {
            char symbol = '_';
            string mask = "";
            string word = p_word.GetSetWord;

            for (int i = 0; i < p_word.GetLenght; i++)
            {
                if (list_char_yes.Contains(word[i]))
                    mask += word[i];
                else
                    mask += symbol + " ";
            }
            return mask;
        }

        public void Play()
        {
            Console.Clear();
            Console.WriteLine("The game starts!");

            int counter = 1;
            while (counter != number_fail + 1 && !victory)
            {
                Console.WriteLine("\nThe word is : " + masked_word);

                Console.WriteLine($"\nTries {counter}/{number_fail}.");
                Console.Write("Choose a letter : ");
                char letter = char.Parse(Console.ReadLine());

                if (full_word.PositionChar(letter) == -1)
                {
                    list_char_no.Add(letter);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe letter isn't in the word.");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("List of denied letters : ");
                    for (int i = 0; i < list_char_no.Count; i++)
                    {
                        Console.Write(list_char_no[i] + " - ");
                    }
                    Console.Write("\n");

                    counter++;
                }
                else
                {
                    list_char_yes.Add(letter);
                    masked_word = Mask(full_word);

                    if (full_word.GetSetWord == masked_word)
                        victory = true;
                }

                Console.WriteLine("------------------------------------------------------");
            }

            if (victory)
                Console.WriteLine("You won. The word was {0}.", full_word.GetSetWord);
            else
                Console.WriteLine("You lost. The word was {0}.", full_word.GetSetWord);
        }
    }
}