using SplashKitSDK;
using DragonBallGame.CharacterClass;

namespace DragonBallGame
{
    public class BattleManager
    {
        private Player _player;
        private Window _window;


        public BattleManager(Player player, Window window)
        {
            _player = player;
            _window = window;
        }

        public string GetSelectedDifficulty()
        {
            while (true)
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White);

                // Draw Difficulty Selection UI
                SplashKit.DrawText("Select Difficulty:", Color.Black, 300, 150);

                // Draw Difficulty Buttons
                Rectangle easyButton = SplashKit.RectangleFrom(300, 200, 200, 40);
                Rectangle mediumButton = SplashKit.RectangleFrom(300, 260, 200, 40);
                Rectangle hardButton = SplashKit.RectangleFrom(300, 320, 200, 40);
                Rectangle extremeButton = SplashKit.RectangleFrom(300, 380, 200, 40);

                SplashKit.FillRectangle(Color.LightGreen, easyButton);
                SplashKit.DrawText("Easy", Color.Black, 385, 215);

                SplashKit.FillRectangle(Color.Yellow, mediumButton);
                SplashKit.DrawText("Medium", Color.Black, 375, 275);

                SplashKit.FillRectangle(Color.Orange, hardButton);
                SplashKit.DrawText("Hard", Color.Black, 385, 335);

                SplashKit.FillRectangle(Color.Red, extremeButton);
                SplashKit.DrawText("Extreme", Color.Black, 375, 395);

                SplashKit.RefreshScreen(60);

                // Handle Mouse Click on Difficulty Buttons
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Point2D mousePosition = SplashKit.MousePosition();

                    if (SplashKit.PointInRectangle(mousePosition, easyButton))
                    {
                        return "Easy";
                    }
                    else if (SplashKit.PointInRectangle(mousePosition, mediumButton))
                    {
                        return "Medium";
                    }
                    else if (SplashKit.PointInRectangle(mousePosition, hardButton))
                    {
                        return "Hard";
                    }
                    else if (SplashKit.PointInRectangle(mousePosition, extremeButton))
                    {
                        return "Extreme";
                    }
                }
            }
        }

        public string StartBattle(Character selectedCharacter)
        {
            string difficulty = GetSelectedDifficulty(); // Allow the player to choose the difficulty for the battle
            BattleSystem battleSystem = new BattleSystem(_window);
            (string battleResult, int reward) = battleSystem.BattleState(selectedCharacter, difficulty);
            _player.AddZeni(reward);
            return battleResult;
        }
    }
}
