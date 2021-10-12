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
        #region Global Variables
        static int Coins;  
        #endregion
        //regions
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

        #endregion        
        static void Main()
        {
            Console.WriteLine(Console.WindowWidth);
            Cosmetic("text", "Please full screen the window then press any key to boot", 25, false, false, ConsoleColor.Gray);
            Console.ReadKey();
            Console.Clear(); 
            Menu();
        }

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Title);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(PlayText);
            Console.WriteLine(QuitText);
            Console.ReadKey();
            string UserInput = Console.ReadLine();
            Console.Write("Input: ");
            while (UserInput != "1" && UserInput != "2") 
            { 
                Cosmetic("text", "ERROR: ", 25, true, true, ConsoleColor.DarkRed); 
                Cosmetic("text", "Please enter either 1 or 2", 25, true, true, ConsoleColor.Gray);
                Console.Write("Input: ");
                UserInput = Console.ReadLine();
            }
            Cosmetic("text", "INPUT ACCEPTED", 25, true, true, ConsoleColor.Green);
            if(UserInput == "2") 
            {
                QuitGame();
            }
            Console.ReadKey();
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
                if(centered) {Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);}
                else { Console.SetCursorPosition(0, 0); }
                for (int i = 0; i < text.Length; i++)
                {
                    Console.Write(text[i]);
                    Thread.Sleep(time);
                }
                if (NextLine) { Console.WriteLine(" "); }
            }

            else if(type == "Ascii")
            {
                Console.WriteLine(text);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
