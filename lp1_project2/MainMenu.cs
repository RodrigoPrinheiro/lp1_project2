using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    class MainMenu
    {
        static void Menu(string[] args)
        {



            bool isValid = true;
            bool GMods = false;


            while (isValid)
            {

                Console.WriteLine("Welcome to the Humans VS Zombiess \nWhat you " +
                    $"want to do? \n 'P': PLAY \n 'H': HELP \n 'Q': QUIT");
                string a = Console.ReadLine().ToUpper();//evitar erros
                char option = char.Parse(a);

                switch (option)
                {
                    case 'P'://Play
                        Console.WriteLine("You choose the Play option");
                        return;

                    case 'H'://Help

                        GMods = true;
                        while (GMods)
                        {


                            Console.WriteLine("What kind of help do you need? \n" +
                            "'O':What kind of GameMoods exists?\n" +
                            "'P':What kind of actions/moves can i do?\n" +
                            "'W':How can I win?\n" +
                            "'Q':Return to the MainMenu\n");
                            string b = Console.ReadLine().ToUpper();//evitar erros
                            char option2 = char.Parse(b);
                            switch (option2)//gameMoods
                            {
                                case 'O'://automatic
                                    Console.WriteLine("Automatic:\nThe game runs" +
                                        "alone, with a need of agent control from" +
                                        "the user. Its just like a spectator mod for" +
                                        "the user.");
                                    Console.WriteLine();
                                    //interactiv
                                    Console.WriteLine("Interactiv:\nEverytime the " +
                                        "Agent is called to play, the system will" +
                                        "wait for the Input from the user.\n If at" +
                                        "anytime there is no Agents controlled by" +
                                        "the user, the game goes automatic till the end.\n");
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

                                case 'Q'://quit
                                    GMods = false;
                                    break;

                                default:
                                    Console.WriteLine("Invalid Option");
                                    break;

                            }

                        }
                        break;

                    case 'C'://credits
                        Console.WriteLine("Rafael Silva - a21805637");//complete
                        break;

                    case 'Q'://Quit

                        Console.WriteLine("Are you sure you want to quit?\n" +
                            "'Q': Yes \n 'S': No, i'm sorry...");
                        string c = Console.ReadLine().ToUpper();//avoid errors
                        char option3 = char.Parse(c);
                        switch (option3)
                        {
                            case 'Q'://leave
                                Environment.Exit(0);
                                break;
                            case 'S'://stay
                                continue;
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
