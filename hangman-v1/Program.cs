using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman_v1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the hangman game!");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("\t1. Play");
            Console.Write("\nSelection : ");
            string choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                    Game game = new Game();
                    game.Play();
                    break;
                default:
                    Menu();
                    break;
            }

            Console.Write("Do you want to play again ? [y/n] - ");
            string select = Console.ReadLine();
            if (select == "y")
                Menu();
            else
                Environment.Exit(0);
        }
    }
}