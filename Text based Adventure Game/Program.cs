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
        //regions

        #region Global Variables
        static string PlayerName = "Null";
        static int Coins = 100;
        static int Health;
        static int MaxHealth = 20;
        static int EnemyHealth;
        static int EnemyMaxHealth;
        static bool BattleEnd = false;
        static string PlayerWeapon = "Fists";
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
            Console.Title = "Adventure Game";
            Cosmetic("text", "Please full screen the window then press any key to boot", 25, false, false, ConsoleColor.Gray);
            Console.ReadKey();
            Console.Clear();
            Background();
            Menu();
        }

        #region Battle

        static void Battle(int EnemyHealthInput, string EnemyName)
        {
            //variables
            string[] Messages = { };
            BattleEnd = false;
            Health = 20;
            EnemyHealth = EnemyHealthInput;
            EnemyMaxHealth = 20;
            int EnemyDamage;
            Random RND = new Random();
            //logic
            Cosmetic("text", "You engage in battle with a " + EnemyName, 25, true, true, ConsoleColor.Gray);
            Thread.Sleep(500);
            while (BattleEnd == false)
            {
                UpdateScreen(EnemyName, Messages);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press any key to attack");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                int PlayerDamage = RND.Next(1, 5);
                EnemyHealth = EnemyHealth - PlayerDamage;
                AppendMsg("You dealt " + PlayerDamage + " damage!", Messages);
                UpdateScreen(EnemyName, Messages);
                CheckDeath(EnemyName);
                if (BattleEnd) { break; }
                Console.ReadKey();
                EnemyDamage = RND.Next(1, 5);
                Health = Health - EnemyDamage;
                AppendMsg("The enemy dealt " + EnemyDamage + " damage!", Messages);
                UpdateScreen(EnemyName, Messages);
                CheckDeath(EnemyName);
            }
            Console.ReadKey();
            Console.Clear();
            return;
        }

        static void AppendMsg(string msg, string[] Messages)
        {
            for (int i = 0; i < Messages.Length; i++)
            {
                if (Messages[i] == null)
                {
                    Messages[i] = msg;
                }
            }
        }

        static void CheckDeath(string enemyName = "null")
        {
            if (EnemyHealth <= 0)
            {
                Cosmetic("text", enemyName + "Was defeated!", 25, true, true, ConsoleColor.Yellow);
                Random rnd = new Random();
                int t_coinIncome = rnd.Next(5, 11);
                Cosmetic("text", "You have received +" + t_coinIncome + " Coins!", 25, true, true, ConsoleColor.Yellow);
                Coins += t_coinIncome;
                BattleEnd = true;
                Thread.Sleep(1500);
                Console.Clear();
            }
            else if (Health <= 0)
            {
                BattleEnd = true;
                Death("You were defeated by a " + enemyName);
            }
        }

        static void UpdateScreen(string EnemyName, string[] Messages)
        {
            Console.Clear();
            Console.WriteLine(@"

                 


                                                                ");
            Console.Write("                  ");
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Your Health");
            Console.WriteLine("");
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
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(EnemyName + "'s Health");
            Console.WriteLine("");
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
            Console.WriteLine("");
            Console.WriteLine(Messages.Length);
            for (int i = 0; i < Messages.Length; i++)
            {
                Console.WriteLine(Messages[i]);
                Console.WriteLine("hello");
            }
        }
        #endregion


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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Cosmetic("text", PlayerName, 0, true, true, ConsoleColor.Magenta);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Stickman);
            Console.ForegroundColor = ConsoleColor.Red;
            Cosmetic("text", "Coins: " + Coins, 0, true, true, ConsoleColor.Red);
            Cosmetic("text", "[!] PRESS ANY KEY TO START", 25, true, true, ConsoleColor.Green);
            Console.ReadKey();
            Game();
        }
        static void Game()
        {
            Console.Clear();
            //Cosmetic("text", "[!] Achievment Unlocked: Completed the game", 25, true, true, ConsoleColor.Green);
            Cosmetic("text", "[!] Please chose from one of the three weapons", 50, true, true, ConsoleColor.Green);
            Cosmetic("text", "[A] Axe", 15, true, true, ConsoleColor.White);
            Cosmetic("text", "[B] Sword", 15, true, true, ConsoleColor.White);
            Cosmetic("text", "[C] Dagger", 50, true, true, ConsoleColor.White);
            Console.WriteLine("Input: ");

            string userInput = Console.ReadLine().ToLower();
            while (userInput != "a" && userInput != "b" && userInput != "c")
            {
                Cosmetic("text", "INVALID INPUT", 25, true, true, ConsoleColor.DarkRed);
                Cosmetic("text", "Please enter one of the options above", 50, true, true, ConsoleColor.White);
                Console.WriteLine("Input: ");
                userInput = Console.ReadLine();
            }
            userInput = userInput.ToLower();
            switch (userInput)
            {
                case "a":
                    Cosmetic("text", "INPUT ACCEPTED", 25, true, true, ConsoleColor.Green);
                    Cosmetic("text", "You equipped an Axe", 25, true, true, ConsoleColor.DarkRed);
                    PlayerWeapon = "Axe";
                    break;
                case "b":
                    Cosmetic("text", "INPUT ACCEPTED", 25, true, true, ConsoleColor.Green);
                    Cosmetic("text", "You equipped a Sword", 25, true, true, ConsoleColor.DarkRed);
                    PlayerWeapon = "Sword";
                    break;
                case "c":
                    Cosmetic("text", "INPUT ACCEPTED", 25, true, true, ConsoleColor.Green);
                    Cosmetic("text", "You equipped a Dagger", 25, true, true, ConsoleColor.DarkRed);
                    Thread.Sleep(700);
                    Death("You tripped, fell and impaled yourself on your dagger");
                    break;
            }
            Console.WriteLine("");
            Thread.Sleep(500);
            Cosmetic("text", "[!] On your left you see a forest and to your right an abandoned hut. Where do you wish to go.", 25, true, true, ConsoleColor.Green);
            Cosmetic("text", "[A] Forest", 15, true, true, ConsoleColor.White);
            Cosmetic("text", "[B] Hut", 15, true, true, ConsoleColor.White);
            Console.WriteLine("Input: ");

            userInput = Console.ReadLine().ToLower();
            while (userInput != "a" && userInput != "b")
            {
                Cosmetic("text", "INVALID INPUT", 25, true, true, ConsoleColor.DarkRed);
                Cosmetic("text", "Please enter one of the options above", 50, true, true, ConsoleColor.White);
                Console.WriteLine("Input: ");
                userInput = Console.ReadLine();
            }
            userInput = userInput.ToLower();
            switch (userInput)
            {
                case "a":
                    Cosmetic("text", "INPUT ACCEPTED", 25, true, true, ConsoleColor.Green);
                    Cosmetic("text", "You continue onwards into the dark Forest", 25, true, true, ConsoleColor.Magenta);
                    Battle(10, "Werewolf");
                    break;
                case "b":
                    Cosmetic("text", "INPUT ACCEPTED", 25, true, true, ConsoleColor.Green);
                    Cosmetic("text", "You enter the abandoned Hut", 25, true, true, ConsoleColor.Magenta);
                    break;
            }
            Console.WriteLine("");
            Thread.Sleep(500);


        }
        static void Death(string deathReason)
        {
            Coins = 100;
            Health = MaxHealth;
            Cosmetic("text", deathReason, 50, true, true, ConsoleColor.White);
            Cosmetic("text", "YOU DIED", 25, true, true, ConsoleColor.DarkRed);
            Cosmetic("text", "[!] Press any key to try again", 25, true, true, ConsoleColor.Green);
            Console.ReadKey();
            StartGame();
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

        static void Background()
        {
            Random rnd = new Random();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, rnd.Next(0, Console.WindowHeight));
                Console.WriteLine("*");
            }
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