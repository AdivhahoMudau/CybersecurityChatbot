using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CybersecurityChatbot
{
    internal class ConsoleUI
    {
        public void DisplayAsciiArt()
            //Displaying cybersecurity logo
        {
            string asciiArt = @" 
    ╔══════════════════════════════════════════════════════════════════════════╗
    ║                                                                          ║
    ║     ██████╗██╗   ██╗██████╗ ███████╗██████╗                              ║
    ║    ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗                             ║
    ║    ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝                             ║
    ║    ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗                             ║
    ║    ╚██████╗   ██║   ██████╔╝███████╗██║  ██║                             ║
    ║     ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝                             ║
    ║                                                                          ║
    ║           █████╗ ██╗    ██╗ █████╗ ██████╗ ███████╗                      ║
    ║          ██╔══██╗██║    ██║██╔══██╗██╔══██╗██╔════╝                      ║
    ║          ███████║██║ █╗ ██║███████║██████╔╝█████╗                        ║
    ║          ██╔══██║██║███╗██║██╔══██║██╔══██╗██╔══╝                        ║
    ║          ██║  ██║╚███╔███╔╝██║  ██║██║  ██║███████╗                      ║
    ║          ╚═╝  ╚═╝ ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝                      ║
    ║                                                                          ║
    ║              C Y B E R S E C U R I T Y   A W A R E N E S S               ║
    ║                            A S S I S T A N T                             ║
    ║                                                                          ║
    ║                    Protecting South Africans Online                      ║
    ║                                                                          ║
    ╚══════════════════════════════════════════════════════════════════════════╝";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(asciiArt);
            Console.ResetColor();
            Thread.Sleep(1000);
        }
        public void PrintColoredText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public void TypewriterEffect(string text, int delayMs = 30)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);

            }
            Console.WriteLine();
        }
        public void PrintDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('=', 60));
            Console.ResetColor();
        }
        public void PrintHeader(string title)
        {
            Console.WriteLine();
            PrintDivider();
            PrintColoredText($"{title.ToUpper()}", ConsoleColor.Cyan);
            PrintDivider();
            Console.WriteLine();
        }
    }
                
        }
