using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityChatbot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";
            Console.CursorVisible = true;

            // Handle console window resizing and closing
            Console.SetWindowSize(120, 40);

            // Create and run the chatbot
            Chatbot chatbot = new Chatbot();
            chatbot.Start();
        }
    }
}
