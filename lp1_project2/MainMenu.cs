using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    /// <summary>
    /// Main menu of the game, it has help, options and play functions.
    /// </summary>
    class MainMenu
    {
        /// <summary>
        /// Method called when we want to add a menu on a specific place.
        /// </summary>
        public static void Menu()
        {
            bool isValid = true;
            bool GMods = false;

            while (isValid)
            {
                char option = ' ';
                Console.WriteLine("Welcome to the Humans VS Zombies \nWhat you " +
                    $"want to do? \n 'P': PLAY \n 'H': HELP \n 'Q': QUIT");
                string a = Console.ReadLine().ToUpper();//evitar erros
                if (a != "")
                    option = char.Parse(a);

                switch (option)
                {
                    // Play
                    case 'P':
                        Console.WriteLine("You choose the Play option");
                        return;

                    // Help
                    case 'H':

                        GMods = true;
                        while (GMods)
                        {

                            Console.WriteLine("What kind of help do you need? \n" +
                            "'O':What kind of GameMoods exists?\n" +
                            "'P':What kind of actions/moves can i do?\n" +
                            "'W':How can I win?\n" +
                            "'Q':Return to the MainMenu\n");

                            // Make every input be upper case.
                            string b = Console.ReadLine().ToUpper();
                            char option2 = char.Parse(b);

                            // Game Modes
                            switch (option2)
                            {

                                case 'O':
                                    // Automatic
                                    Console.WriteLine("Automatic:\nThe game runs" +
                                        "alone, with a need of agent control from" +
                                        "the user. Its just like a spectator mod for" +
                                        "the user.");
                                    Console.WriteLine();
                                    // Interactive
                                    Console.WriteLine("Interactive:\nEvery time the " +
                                        "Agent is called to play, the system will" +
                                        "wait for the Input from the user.\n If at" +
                                        "anytime there is no Agents controlled by" +
                                        "the user, the game goes automatic till the end.\n");
                                    break;

                                // Actions
                                case 'P':
                                    Console.WriteLine("Actions:\n If you are a " +
                                        "Human you only can move\n If you are a " +
                                        "Zombie, you can move or you cant infect" +
                                        "other Human.\n You can infect other Humans" +
                                        "when you are in the cell which is nearby to" +
                                        "the human.\n\n Moves: No matter what kind" +
                                        "of Agent you are, you only can move one cell" +
                                        "nearby to you with QWE AD ZXC with S being the center. ");
                                    break;

                                // Win Condition
                                case 'W':
                                    Console.WriteLine("If you are a zombie you need " +
                                        "to infect all the Humans in the board " +
                                        "before the game reach the max Turns. \n" +
                                        "If you are a Human its the opposite, you" +
                                        "need to survive till the last Turn.");
                                    break;

                                // Quit
                                case 'Q':
                                    GMods = false;
                                    break;

                                default:
                                    Console.WriteLine("Invalid Option");
                                    break;

                            }

                        }
                        break;

                    // Credits
                    case 'C':
                        // Complete
                        Console.WriteLine("Rafael Silva - a21805637");
                        break;

                    // Quit
                    case 'Q':

                        Console.WriteLine("Are you sure you want to quit?\n" +
                            "'Q': Yes \n 'S': No, I'm sorry...");

                        // Avoid errors
                        string c = Console.ReadLine().ToUpper();
                        char option3 = char.Parse(c);
                        switch (option3)
                        {
                            // Leave
                            case 'Q':
                                Environment.Exit(0);
                                break;

                            // Stay
                            case 'S':
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
