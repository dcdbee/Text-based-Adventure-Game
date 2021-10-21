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
        static int pDeaths;
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
            Health = MaxHealth;
            EnemyMaxHealth = EnemyHealthInput;
            EnemyHealth = EnemyMaxHealth;
            int EnemyDamage;
            Random RND = new Random();
            //logic
            Cosmetic("text", "You engage in battle with a " + EnemyName, 25, true, true, ConsoleColor.Gray);
            Thread.Sleep(2000);
            while (BattleEnd == false)
            {
                UpdateScreen(EnemyName, Messages);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press any key to attack");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                int PlayerDamage = RND.Next(1, 5);
                EnemyHealth = EnemyHealth - PlayerDamage;
                UpdateScreen(EnemyName, Messages);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You dealt " + PlayerDamage + " damage");
                Console.ReadKey();
                CheckDeath(EnemyName);
                if (BattleEnd) { break; }
                Console.ReadKey();
                EnemyDamage = RND.Next(1, 5);
                Health = Health - EnemyDamage;
                UpdateScreen(EnemyName, Messages);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The enemy dealt " + EnemyDamage + " damage!");
                Console.ReadKey();
                CheckDeath(EnemyName);
            }
            Console.ReadKey();
            Console.Clear();
            return;
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
            for(int i = 0; i < Messages.Length; i++)
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

            string userInput = Console.ReadLine().ToLower() ;
            while(userInput != "a" && userInput != "b" && userInput != "c")
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
                    Battle(20, "Werewolf");
                    Game_Forest();
                    break;
                case "b":
                    Cosmetic("text", "INPUT ACCEPTED", 25, true, true, ConsoleColor.Green);
                    Cosmetic("text", "You enter the abandoned Hut", 25, true, true, ConsoleColor.Magenta);
                    Battle(20, "Spider");
                    Cosmetic("text", "You enter the hut through the back exit and find yourself by a river.", 25, true, true, ConsoleColor.Magenta);
                    River();
                    break;
            }
            Console.WriteLine("");
            Thread.Sleep(500);
        }

        static void Game_Forest()
        {
            Cosmetic("text", "You see something bright and orange!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", 25, true, true, ConsoleColor.Green);
            Cosmetic("text", "[!] There's a forest fire, do you run to the left towards the river or continue through the woods", 25, true, true, ConsoleColor.Yellow);
            Cosmetic("text", "[A] Call Fireman Sam", 15, true, true, ConsoleColor.White);
            Cosmetic("text", "[B] Run towards the River", 15, true, true, ConsoleColor.White);
            Cosmetic("text", "[C] Continue through the woods which is now on fire", 15, true, true, ConsoleColor.White);
            string userInput = Console.ReadLine().ToLower();
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
                    Death("Fireman sam tells you to burn");
                    break;
                case "b":
                    Cosmetic("text", "INPUT ACCEPTED", 25, true, true, ConsoleColor.Green);
                    Cosmetic("text", "You run and escape the fire, coming out by the river", 25, true, true, ConsoleColor.Magenta);
                    Cosmetic("text", "You pick a fight with a Salmon", 25, true, true, ConsoleColor.Red);
                    Battle(15, "Salmon");
                    River();
                    break;
                case "c":
                    Cosmetic("text", "INPUT ACCEPTED", 25, true, true, ConsoleColor.Green);
                    Cosmetic("text", "You continue run but the fire catches up", 25, true, true, ConsoleColor.Magenta);
                    Death("You perish in a forest fire");
                    break;
            }
        }

        static void River()
        {
            Cosmetic("text", "[!] The river has two bridges which one do you cross. ", 25, true, true, ConsoleColor.Yellow);
            Cosmetic("text", "[A] Bridge no.1", 15, true, true, ConsoleColor.White);
            Cosmetic("text", "[B] Bridge no.2", 15, true, true, ConsoleColor.White);
            string userInput = Console.ReadLine().ToLower();
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
                    Cosmetic("text", "You begin to cross the bridge before an angry troll lad comes after ye", 25, true, true, ConsoleColor.Magenta);
                    Battle(20, "Angry Troll Lad");
                    Field();
                    break;
                case "b":
                    Cosmetic("text", "INPUT ACCEPTED", 25, true, true, ConsoleColor.Green);
                    Cosmetic("text", "You were stupid and picked the wrong bridge.", 75, true, true, ConsoleColor.Magenta);
                    Cosmetic("text", "An angry dragon comes up from under the bridge.", 25, true, true, ConsoleColor.Red);
                    Battle(35, "Dragon");
                    Field();
                    break;

            }
        }

        static void Field()
        {
            Cosmetic("text", "You somehow survived and crossed the bridge into an open field.", 35, true, true, ConsoleColor.Magenta);
            Cosmetic("text", "There's an AI in the field!", 25, true, true, ConsoleColor.Magenta);
            Cosmetic("text", "You must roll a 6 in order to pass! If I roll a 6 first you will die!", 25, true, true, ConsoleColor.Yellow);
            Random rnd = new Random();
            int aiRoll = 0;
            int pRoll = 0;
            while(aiRoll != 6 && pRoll != 6)
            {
                Cosmetic("text", "[!] Press any key to roll a dice", 25, true, true, ConsoleColor.Blue);
                Console.ReadKey();
                pRoll = rnd.Next(1, 7);
                Cosmetic("text", "[!] You rolled a " + pRoll , 25, true, true, ConsoleColor.Cyan);
                aiRoll = rnd.Next(1, 7);
                Cosmetic("text", "[!] AI rolled a " + aiRoll, 25, true, true, ConsoleColor.Cyan);
            }
            if(aiRoll == 6)
            {
                Death("AI Rolled a 6, the die exploded taking you out with them.");
            }
            else
            {
                Cosmetic("text", "AI pulls out a knife", 25, true, true, ConsoleColor.Blue);
                Battle(20, "AI the bad loser");
                Cosmetic("text", "You completed the game and only died " + pDeaths + " times", 25, true, true, ConsoleColor.Blue);
                Thread.Sleep(2000);
                Menu();
            }
        }

        static void Death(string deathReason)
        {
            pDeaths++;
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