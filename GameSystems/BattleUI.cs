using SplashKitSDK;
using DragonBallGame.CharacterClass;

namespace DragonBallGame
{
    public class BattleUI
    {
        private Window _window;
        private ImageManager _imageManager;

        public Window Window => _window;

        public BattleUI(Window window, ImageManager imageManager)
        {
            _window = window;
            _imageManager = imageManager;
        }

        public void DrawBattleState(Character player, Character villain)
        {
            // Draw Character Images
            Bitmap playerImage = _imageManager.GetCharacterImage(player);
            Bitmap villainImage = _imageManager.GetCharacterImage(villain);

            SplashKit.DrawBitmap(playerImage, 50, 130); // Player image on the left
            SplashKit.DrawBitmap(villainImage, _window.Width - 250, 150); // Villain image on the right

            // Draw Health Bars and Energy Bars
            DrawHealthBar(50, 80, player.Health, player.MaxHealth, Color.Green, $"{player.Name}");
            DrawEnergyBar(50, 110, player.Energy, 100, Color.Cyan);

            DrawHealthBar(_window.Width - 250, 80, villain.Health, villain.MaxHealth, Color.Red, $"{villain.Name}");
            DrawEnergyBar(_window.Width - 250, 110, villain.Energy, 100, Color.Cyan);

            SplashKit.DrawText("Press SPACE to attack, B to block, E to escape", Color.Red, 220, 30);
        }

        private void DrawHealthBar(int x, int y, int currentHealth, int maxHealth, Color barColor, string name)
        {
            int barWidth = 200;
            int barHeight = 20;
            double healthPercentage = (double)currentHealth / maxHealth;
            int currentBarWidth = (int)(barWidth * healthPercentage);

            // Draw health bar background (grey)
            SplashKit.FillRectangle(Color.Gray, x, y, barWidth, barHeight);

            // Draw current health (colored bar)
            SplashKit.FillRectangle(barColor, x, y, currentBarWidth, barHeight);

            // Draw character name above health bar
            SplashKit.DrawText(name, Color.Black, x, y - 20);
        }

        private void DrawEnergyBar(int x, int y, int currentEnergy, int maxEnergy, Color barColor)
        {
            int barWidth = 200;
            int barHeight = 10;
            double energyPercentage = (double)currentEnergy / maxEnergy;
            int currentBarWidth = (int)(barWidth * energyPercentage);

            // Draw energy bar background (grey)
            SplashKit.FillRectangle(Color.Gray, x, y, barWidth, barHeight);

            // Draw current energy (colored bar)
            SplashKit.FillRectangle(barColor, x, y, currentBarWidth, barHeight);
        }
    }
}