using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            bool isValid = true;
            bool GMods = true;

            while (isValid)
            {
                string a = Console.ReadLine().ToUpper();//evitar erros
                char option = char.Parse(a);

                Console.WriteLine("Welcome to the Humans VS Zombiess \nWhat you " +
                    $"want to do? \n '1': PLAY \n '2': HELP \n '3': QUIT");

                switch (option)
                {
                    case 'P'://Play
                        Console.WriteLine("You choose the Play option");
                        break;


                    case 'H'://Help
                        while (GMods)
                        {
                            Console.WriteLine("What kind of help do you need? \n" +
                            "'1':What kind of GameMoods exists?\n" +
                            "'2':What kind of actions/moves can i do?\n");


                            switch (option)//gameMoods
                            {
                                case 'O'://automatic
                                    Console.WriteLine("Automatic:\nThe game runs" +
                                        "alone, with a need of agent control from" +
                                        "the user. Its just like a spectator mod for" +
                                        "the user.");
                                    break;

                                case 'I'://interactiv
                                    Console.WriteLine("Interactiv:\nEverytime the " +
                                        "Agent is called to play, the system will" +
                                        "wait for the Input from the user.\n If at" +
                                        "anytime there is no Agents controlled by" +
                                        "the user, the game goes automatic till the end.");
                                    break;

                                case 'P'://actions
                                    Console.WriteLine("Actions:\n If you are a " +
                                        "Human you only can move\n If you are a " +
                                        "Zombie, you can move or you cant infect" +
                                        "other Human.\n You can infect other Humans" +
                                        "when you are in the cell which is nearby to" +
                                        "the human.\n\n Moves: No matter what kind" +
                                        "of Agent you are, you only can move one cell" +
                                        "nearby to you. ");
                                    break;

                                case 'W'://winCondition
                                    Console.WriteLine("If you are a zombie you need " +
                                        "to infect all the Humans in the board " +
                                        "before the game reach the max Turns. \n" +
                                        "If you are a Human its the opposite, you" +
                                        "need to survive till the last Turn.");
                                    break;

                                case 'E'://quit
                                    GMods = false;
                                    break;

                                default:
                                    Console.WriteLine("Invalid Option");
                                    break;

                            }
                        }
                        break;

                    case 'C'://credits
                        Console.WriteLine();//complete
                        break;
                    case 'Q'://Quit

                        Console.WriteLine("Are you sure you want to quit?\n" +
                            "'1': Yes \n '2': No, i'm sorry...");
                        switch (option)
                        {
                            case 'Q'://sair
                                Environment.Exit(0);
                                break;
                            case 'S'://ficar
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
    }
}
