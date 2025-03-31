namespace DragonBallGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            GameMenu menu = new GameMenu(player);
            menu.Run();
        }
    }
}
