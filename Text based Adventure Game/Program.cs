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

        #endregion        
        static void Main()
        {
            Cosmetic("text", "Please full screen the window then press any key to boot", 25, false, ConsoleColor.DarkRed);
            Console.ReadKey();
            Menu();
        }

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Title);
            Console.ReadKey();
        }

        static void Cosmetic(string type, string text, int time, bool NextLine, ConsoleColor colour)
        {
            if(type == "text")
            {
                for(int i = 0; i < text.Length; i++)
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
        }

    }
}
