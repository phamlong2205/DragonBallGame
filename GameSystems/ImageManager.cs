using SplashKitSDK;
using System.Collections.Generic;
using DragonBallGame.CharacterClass;

namespace DragonBallGame
{
    public class ImageManager
    {
        private Dictionary<string, Dictionary<int, Bitmap>> _characterImages;

        public ImageManager()
        {
            _characterImages = new Dictionary<string, Dictionary<int, Bitmap>>
            {
                { "Son Goku", new Dictionary<int, Bitmap>
                    {
                        { 0, SplashKit.LoadBitmap("Goku_Base", "Resources/goku.png") },
                        { 1, SplashKit.LoadBitmap("Goku_SSJ1", "Resources/goku_ss1.png") },
                        { 2, SplashKit.LoadBitmap("Goku_SSJ2", "Resources/goku_ss2.png") },
                        { 3, SplashKit.LoadBitmap("Goku_SSJ3", "Resources/goku_ss3.png") },
                        { 4, SplashKit.LoadBitmap("Goku_God", "Resources/goku_god.png") },
                        { 5, SplashKit.LoadBitmap("Goku_Blue", "Resources/goku_blue.png") },
                        { 6, SplashKit.LoadBitmap("Goku_UI", "Resources/goku_ultrainstinct.png") }
                    }
                },
                { "Vegeta", new Dictionary<int, Bitmap>
                    {
                        { 0, SplashKit.LoadBitmap("Vegeta_Base", "Resources/vegeta.png") },
                        { 1, SplashKit.LoadBitmap("Vegeta_SSJ1", "Resources/vegeta_ss1.png") },
                        { 2, SplashKit.LoadBitmap("Vegeta_SSJ2", "Resources/vegeta_ss2.png") },
                        { 3, SplashKit.LoadBitmap("Vegeta_God", "Resources/vegeta_god.png") },
                        { 4, SplashKit.LoadBitmap("Vegeta_Blue", "Resources/vegeta_blue.png") },
                        { 5, SplashKit.LoadBitmap("Vegeta_UE", "Resources/vegeta_ultraego.png") }
                    }
                },
                { "Son Gohan", new Dictionary<int, Bitmap>
                    {
                        { 0, SplashKit.LoadBitmap("Gohan_Base", "Resources/gohan.png") },
                        { 1, SplashKit.LoadBitmap("Gohan_SSJ1", "Resources/gohan_ss1.png") },
                        { 2, SplashKit.LoadBitmap("Gohan_SSJ2", "Resources/gohan_ss2.png") },
                        { 3, SplashKit.LoadBitmap("Gohan_Ultimate", "Resources/gohan_ultimate.png") },
                        { 4, SplashKit.LoadBitmap("Gohan_Beast", "Resources/gohan_beast.png") }
                    }
                },
                { "Frieza", new Dictionary<int, Bitmap>
                    {
                        { 0, SplashKit.LoadBitmap("Frieza", "Resources/frieza.png") }
                    }
                },
                { "Cell", new Dictionary<int, Bitmap>
                    {
                        { 0, SplashKit.LoadBitmap("Cell", "Resources/cell.png") }
                    }
                },
                { "Buu", new Dictionary<int, Bitmap>
                    {
                        { 0, SplashKit.LoadBitmap("Buu", "Resources/buu.png") }
                    }
                },
                { "Black Goku", new Dictionary<int, Bitmap>
                    {
                        { 0, SplashKit.LoadBitmap("Black", "Resources/black.png") }
                    }
                }
            };
        }

        public Bitmap GetCharacterImage(Character character)
        {
            if (_characterImages.ContainsKey(character.Name) &&
                _characterImages[character.Name].ContainsKey(character.TransformationLevel))
            {
                return _characterImages[character.Name][character.TransformationLevel];
            }

            // Return a default image if no specific image is found
            return SplashKit.LoadBitmap("Default", "Resources/default.png");
        }
    }
}
