using SplashKitSDK;
using System;
using System.Collections.Generic;

namespace DragonBallGame
{
    public class MessageManager
    {
        private List<(string message, DateTime time)> _messages; // Store messages with their timestamp
        private const double DURATION = 3.0; // Duration to display messages in seconds
        private Font _font; 

        public MessageManager()
        {
            _messages = new List<(string, DateTime)>();
            _font = SplashKit.LoadFont("Arial", "Font/arial.ttf");
        }

        public void AddMessage(string message)
        {
            _messages.Clear();
            _messages.Add((message, DateTime.Now));
        }

        public void DrawMessages()
        {
            List<(string message, DateTime time)> expiredMessages = new List<(string, DateTime)>();

            foreach (var (message, time) in _messages)
            {
                double elapsedSeconds = (DateTime.Now - time).TotalSeconds;

                if (elapsedSeconds > DURATION)
                {
                    expiredMessages.Add((message, time));
                }
                else
                {
                    int textWidth = SplashKit.TextWidth(message, _font, 14);

                    // Calculate the x-coordinate for center alignment
                    int xCoordinate = (800 - textWidth) / 2;

                    // Draw the message centered horizontally using the loaded font
                    SplashKit.DrawText(message, Color.Red, _font, 14, xCoordinate, 525);
                }
            }

            // Remove expired messages from the list
            foreach (var expiredMessage in expiredMessages)
            {
                _messages.Remove(expiredMessage);
            }
        }
    }
}

