using DragonBallGame.CharacterClass;

namespace DragonBallGame
{
    public class VillainAI
    {
        private IVillainStrategy _strategy;

        public VillainAI()
        { 
            _strategy = new DefaultVillainStrategy();
        }

        public VillainAction Action(Character villain, Character player)
        {
            SetStrategy(villain, player);
            return _strategy.ChooseAction(villain, player);
        }

        private void SetStrategy(Character villain, Character player)
        {
            int powerDifference = player.Power - villain.Power;

            if (Math.Abs(powerDifference) <= 200)
            {
                _strategy = new DefaultVillainStrategy();
            }
            else if (powerDifference >= 200)
            {
                _strategy = new DefensiveVillainStrategy();
            }
            else
            {
                _strategy = new AggressiveVillainStrategy();
            }
        }
    }


    public enum VillainAction
    {
        Block,
        Attack
    }
}