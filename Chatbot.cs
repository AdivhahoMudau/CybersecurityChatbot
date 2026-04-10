using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CybersecurityChatbot
{
    internal class Chatbot
    {
        public string UserName { get; private set; }


        private ConsoleUI _ui;
        private Responses _responses;

        public bool IsRunning { get; private set; }

        public Chatbot()
        {
            _ui = new ConsoleUI();
            _responses = new Responses();

            IsRunning = true;
        }
        public void Start()
        {
            try
            {
                // 1. Play voice greeting
                PlayVoiceGreeting();

                // 2. Display ASCII art logo
                _ui.DisplayAsciiArt();

                // 3. Text- based greeting
                DisplayWelcomeMessage();

                //4. Main interaction loop
                RunConversationLoop();
            }
            catch (Exception ex)
            {
                _ui.PrintColoredText($"\nAn error occured: {ex.Message}", ConsoleColor.Red);
                _ui.PrintColoredText("Press any key to exit....", ConsoleColor.Yellow);

                Console.ReadKey();
            }
        }
        private void PlayVoiceGreeting()
        {
            try
            {
                // Get the path to the WAV file (should be in the same directory as the executable)
                string audioPath =
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");

                if (File.Exists(audioPath))
                {
                    _ui.PrintColoredText("[Playing voice greeting....]", ConsoleColor.DarkGray);

                    using (SoundPlayer player = new SoundPlayer(audioPath))
                    {
                        player.PlaySync(); // Play synchronously
                    }
                    Thread.Sleep(500); // Small pause after audio
                }
                else
                {
                    _ui.PrintColoredText("[Voice file not found. Continuing with text only.]", ConsoleColor.DarkYellow);
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                _ui.PrintColoredText($"[Could not play voice greeting: {ex.Message}]", ConsoleColor.DarkYellow);
                Thread.Sleep(1000);
            }
        } 
    private void DisplayWelcomeMessage()
        {
            _ui.PrintDivider();
            _ui.PrintColoredText("WELCOME TO CYBERSECURITY AWARENESS BOT", ConsoleColor.Green);

            _ui.PrintDivider();
            Console.WriteLine();

            // Simulate typing effect for conversation feel
            _ui.TypewriterEffect("Hello! I'm your Cybersecurity Awareness Assistant.", 40);
            Console.WriteLine();

            _ui.TypewriterEffect("I'm here to help you stay safe online in South Africa.", 40);
            Console.WriteLine("\n");

            // Get user name with validation
            _ui.PrintColoredText("What's your name?", ConsoleColor.Yellow);
            UserName = Console.ReadLine();

            // Input validation for empty name
            while (string.IsNullOrWhiteSpace(UserName))
            {



                _ui.PrintColoredText("I didn't catch that. Please tell me your name:", ConsoleColor.Yellow);
                UserName = Console.ReadLine();

            }
            _ui.TypewriterEffect($"\nNice to meet you, {UserName}! ", 40);
            _ui.TypewriterEffect("Let me help you learn about staying safe online", 40);

            Console.WriteLine();

            Thread.Sleep(500);
        }
        private void RunConversationLoop()
        {
            _ui.PrintColoredText(new string('=', 60), ConsoleColor.Cyan);
            _ui.PrintColoredText("What would you like to learn about?", ConsoleColor.Magenta);
            _ui.PrintColoredText(new string('=' , 60), ConsoleColor.Cyan);
            Console.WriteLine();

            _ui.PrintColoredText(" • Password safety", ConsoleColor.White);
            _ui.PrintColoredText(" • Phishing attacks", ConsoleColor.White);
            _ui.PrintColoredText(" • Safe browsing", ConsoleColor.White);
            _ui.PrintColoredText(" • How I'm doing", ConsoleColor.White);
            _ui.PrintColoredText(" • My purpose", ConsoleColor.White);
            _ui.PrintColoredText(" • Type 'help' for more topics", ConsoleColor.White);
            _ui.PrintColoredText(" • Type 'exit' to quit", ConsoleColor.Red);

            Console.WriteLine();

            while (IsRunning)
            {
                Console.WriteLine();
                _ui.PrintColoredText($"{UserName} >", ConsoleColor.Cyan);
                string userInput = Console.ReadLine()?.Trim().ToLower();

                //Input validation for empty input
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    _ui.TypewriterEffect("\n[Bot] I didn't quite understand that. Could you rephrase?", 30);
                    continue;
                }

                //Check for exit commands
                if (userInput == "exit" || userInput == "quit" || userInput == "bye" || userInput == "goodbye")
                {
                    _ui.TypewriterEffect($"\n[Bot] Goodbye, {UserName}! Stay safe online!", 40);
                    _ui.PrintColoredText("\nThank you for using Cybersecurity Awareness Bot!", ConsoleColor.Green);
                    IsRunning = false;
                    break;
                }
                // Get response based on user input
                string response = _responses.GetResponse(userInput, UserName);

                _ui.TypewriterEffect($"\n[Bot] {response}", 35);
                Console.WriteLine();
            }
        }
    }
}

