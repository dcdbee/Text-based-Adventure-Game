using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Text_based_Adventure_Game
{
    class Program
    {
        //regions//loltest

        #region Global Variables
        static string PlayerName = "Null";
        static int Coins = 100;
        static int Health;
        static int MaxHealth = 20;
        static int EnemyHealth;
        static int EnemyMaxHealth;
        static bool BattleEnd = false;
        #endregion

        #region Ascii
        //Bloody-https://patorjk.com/software/taag/#p=testall&v=0&f=Small%20Slant&t=Adventure%20Game //a text base adventure (sub title)
        static string Title = @" 


                                                             ▄▄▄      ▓█████▄  ██▒   █▓▓█████  ███▄    █ ▄▄▄█████▓ █    ██  ██▀███  ▓█████      ▄████  ▄▄▄       ███▄ ▄███▓▓█████ 
                                                            ▒████▄    ▒██▀ ██▌▓██░   █▒▓█   ▀  ██ ▀█   █ ▓  ██▒ ▓▒ ██  ▓██▒▓██ ▒ ██▒▓█   ▀     ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀ 
                                                            ▒██  ▀█▄  ░██   █▌ ▓██  █▒░▒███   ▓██  ▀█ ██▒▒ ▓██░ ▒░▓██  ▒██░▓██ ░▄█ ▒▒███      ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███   
                                                            ░██▄▄▄▄██ ░▓█▄   ▌  ▒██ █░░▒▓█  ▄ ▓██▒  ▐▌██▒░ ▓██▓ ░ ▓▓█  ░██░▒██▀▀█▄  ▒▓█  ▄    ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄ 
                                                             ▓█   ▓██▒░▒████▓    ▒▀█░  ░▒████▒▒██░   ▓██░  ▒██▒ ░ ▒▒█████▓ ░██▓ ▒██▒░▒████▒   ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒
                                                             ▒▒   ▓▒█░ ▒▒▓  ▒    ░ ▐░  ░░ ▒░ ░░ ▒░   ▒ ▒   ▒ ░░   ░▒▓▒ ▒ ▒ ░ ▒▓ ░▒▓░░░ ▒░ ░    ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░
                                                              ▒   ▒▒ ░ ░ ▒  ▒    ░ ░░   ░ ░  ░░ ░░   ░ ▒░    ░    ░░▒░ ░ ░   ░▒ ░ ▒░ ░ ░  ░     ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░
                                                              ░   ▒    ░ ░  ░      ░░     ░      ░   ░ ░   ░       ░░░ ░ ░   ░░   ░    ░      ░ ░   ░   ░   ▒   ░      ░      ░   
                                                                  ░  ░   ░          ░     ░  ░         ░             ░        ░        ░  ░         ░       ░  ░       ░      ░  ░
                                                                       ░           ░                                                                                              ";
        static string PlayText = @"



                                       
                                                                                                     ___           _____ __    _____ __ __ 
                                                                                                    |_  |         |  _  |  |  |  _  |  |  |
                                                                                                     _| |_    _   |   __|  |__|     |_   _|
                                                                                                    |_____|  |_|  |__|  |_____|__|__| |_|  
                                       


";

        static string QuitText = @"                    
                                                                                                       ___         _____ _____ _____ _____ 
                                                                                                      |_  |       |     |  |  |     |_   _|
                                                                                                      |  _|   _   |  |  |  |  |-   -| | |  
                                                                                                      |___|  |_|  |__  _|_____|_____| |_|  
                                                                                                                     |__|                  
                                       


";

        static string Stickman = @"
                                                                                                                        
                                                                                                           .    *    _@   .    .
                                                                                                          .  o   .  </\_   o  *
                                                                                                            .     ~\/\  '      o
                                                                                                          o     .    /   .  *
                                                                                                                     ~        
";

        #endregion        
        static void Main()
        {
            Console.WriteLine(Console.WindowWidth);
            Cosmetic("text", "Please full screen the window then press any key to boot", 25, false, false, ConsoleColor.Gray);
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        static void Battle()
        {
            BattleEnd = false;
            Health = 20;
            EnemyHealth = 20;
            EnemyMaxHealth = 20;
            int EnemyDamage;
            Random RND = new Random();
            while (BattleEnd == false)
            {
                UpdateScreen();
                Console.WriteLine("Press any key to attack");
                Console.ReadKey();
                EnemyHealth = EnemyHealth - RND.Next(1, 5);
                UpdateScreen();
                CheckDeath();
                if (BattleEnd) { break; }
                Console.ReadKey();
                EnemyDamage = RND.Next(1, 5);
                Health = Health - EnemyDamage;
                UpdateScreen();
                Console.WriteLine("The enemy dealt " + EnemyDamage);
                CheckDeath();
                Console.ReadKey();
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("hello");
            Console.ReadKey();
        }

        static void CheckDeath()
        {
            if (EnemyHealth <= 0)
            {
                Console.Write("Enemy died you win");
                BattleEnd = true;
            }
            else if (Health <= 0)
            {
                Console.WriteLine("You died");
                BattleEnd = true;
            }
        }

        static void UpdateScreen()
        {
            Console.Clear();
            Console.WriteLine(@"

                 


                                                                ");
            Console.Write("                  ");
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            for (int i = 0; i < Health; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("█");
            }
            for (int j = 0; j < MaxHealth - Health; j++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("█");
            }
            Console.WriteLine(Health);
            Console.WriteLine(@"

                 


                                                                ");
            Console.Write("                  ");
            for (int i = 0; i < EnemyHealth; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("█");
            }
            for (int j = 0; j < EnemyMaxHealth - EnemyHealth; j++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("█");
            }
            Console.WriteLine(EnemyHealth);
        }

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Title);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(PlayText);
            Console.WriteLine(QuitText);
            string UserInput;
            Console.Write("Input: ");
            UserInput = Console.ReadLine();
            while (UserInput != "1" && UserInput != "2")
            {
                Cosmetic("text", "ERROR: ", 25, true, true, ConsoleColor.DarkRed);
                Cosmetic("text", "Please enter either 1 or 2", 25, true, true, ConsoleColor.Gray);
                Console.Write("Input: ");
                UserInput = Console.ReadLine();
            }
            Cosmetic("text", "INPUT ACCEPTED", 25, true, true, ConsoleColor.Green);
            if (UserInput == "2")
            {
                QuitGame();
            }
            else
            {
                Cosmetic("text", "Do you wish to enter a username (1) or have one randomly generated (2)", 25, true, true, ConsoleColor.Magenta);
                UserInput = Console.ReadLine();
                while (UserInput != "1" && UserInput != "2")
                {
                    Cosmetic("text", "ERROR: ", 25, true, true, ConsoleColor.DarkRed);
                    Cosmetic("text", "Please enter either 1 or 2", 25, true, true, ConsoleColor.Gray);
                    Console.Write("Input: ");
                    UserInput = Console.ReadLine();
                }
                Cosmetic("text", "INPUT ACCEPTED", 25, true, true, ConsoleColor.Green);
                if (UserInput == "1")
                {
                    Cosmetic("text", "Please enter a username!", 25, true, true, ConsoleColor.Magenta);
                    Console.WriteLine("Input: ");
                    PlayerName = Console.ReadLine();
                    while (PlayerName == null)
                    {
                        Cosmetic("text", "ERROR: ", 25, true, true, ConsoleColor.DarkRed);
                        Cosmetic("text", "Please enter a valid username", 25, true, true, ConsoleColor.Gray);
                        Console.Write("Input: ");
                        PlayerName = Console.ReadLine();
                    }
                    Cosmetic("text", "INPUT ACCEPTED", 25, true, true, ConsoleColor.Green);
                    Cosmetic("text", "Your username has been set to " + PlayerName, 25, true, true, ConsoleColor.Magenta);
                    StartGame();
                }
                else
                {
                    GenerateName();
                }
            }
            Console.ReadKey();
        }

        static void GenerateName()
        {
            Random RND = new Random();
            string[] Adjectives = { "Adorable", "Agreeable", "Amused", "Annoying", "Ashamed", "Awful", "Bloody", "Blushing", "Brave", "Busy", "Cautious", "Clean", "Condemned", "Courageous", "Crowded", "Doubtful", "Faithful", "Fantastic", "Fine", };
            string[] Nouns = { "Actor", "Airport", "Animal", "Battery", "Beach", "Army", "Bed", "Boy", "Camera", "Candle", "Carpet", "Melon", "Crayon", "Daughter", "Dog", "Diamond", "Elephant", "Engine", "Footbal", "Fountain", "Forest", "Furniture", "Garage", };
            PlayerName = Adjectives[RND.Next(1, Adjectives.Length)] + Nouns[RND.Next(1, Nouns.Length)] + RND.Next(100, 1000);
            Cosmetic("text", "Your randomly selected name is " + PlayerName, 25, true, true, ConsoleColor.Magenta);
            StartGame();
        }

        static void StartGame()
        {
            Console.ReadKey();
            Console.Clear();
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Cosmetic("text", PlayerName, 0, true, true, ConsoleColor.Magenta);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Stickman);
            Console.ForegroundColor = ConsoleColor.Red;
            Cosmetic("text", "Coins: " + Coins , 0, true, true, ConsoleColor.Red);
            Cosmetic("text", "[!] PRESS ANY KEY TO START", 25, true, true, ConsoleColor.Green);

            Console.ReadKey();

            Battle();
        }

        static void QuitGame()
        {
            Cosmetic("text", "INITIATING SHUTDOWN", 25, false, true, ConsoleColor.DarkRed);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(" .");
            Thread.Sleep(100);
            Console.Write(" .");
            Thread.Sleep(100);
            Console.Write(" .");
            Thread.Sleep(100);
            Thread.Sleep(2500);
            Environment.Exit(0);
        }

        static void Cosmetic(string type, string text, int time, bool NextLine, bool centered, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            if (type == "text")
            {
                if (centered) { Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop); }
                else { Console.SetCursorPosition(0, 0); }
                for (int i = 0; i < text.Length; i++)
                {
                    Console.Write(text[i]);
                    Thread.Sleep(time);
                }
                if (NextLine) { Console.WriteLine(" "); }
            }

            else if (type == "Ascii")
            {
                Console.WriteLine(text);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}