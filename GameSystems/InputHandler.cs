using SplashKitSDK;

namespace DragonBallGame
{
    public class InputHandler
    {
        public void HandleMouseClick(Point2D mousePosition, GameMenu menu)
        {
            // Handle Arrow Clicks
            Rectangle leftArrowRect = SplashKit.RectangleFrom(50, 250, 40, 40);
            if (SplashKit.PointInRectangle(mousePosition, leftArrowRect))
            {
                menu.NavigateLeft();
                return;
            }

            Rectangle rightArrowRect = SplashKit.RectangleFrom(710, 250, 40, 40);
            if (SplashKit.PointInRectangle(mousePosition, rightArrowRect))
            {
                menu.NavigateRight();
                return;
            }

            // Handle Recruit Button Click
            Rectangle recruitButtonRect = SplashKit.RectangleFrom(250, 550, 100, 40);
            if (SplashKit.PointInRectangle(mousePosition, recruitButtonRect))
            {
                menu.RecruitCharacter();
                return;
            }

            // Handle Battle Button Click
            Rectangle battleButtonRect = SplashKit.RectangleFrom(450, 550, 100, 40);
            if (SplashKit.PointInRectangle(mousePosition, battleButtonRect))
            {
                menu.Battle();
                return;
            }
        }
    }
}
