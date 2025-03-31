using DragonBallGame.CharacterClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallGame
{
    public class DefaultVillainStrategy : IVillainStrategy
    {
        private Random _random = new Random();

        public VillainAction ChooseAction(Character villain, Character player)
        {
            double blockChance = _random.NextDouble();

            // If villain's health is below 30% and player's health is more than 30%, there's a 60% chance they will block, or simple just 20% of random block
            if ((villain.Health < (villain.MaxHealth * 0.3) && blockChance < 0.6 && player.Health > (player.MaxHealth * 0.3)) || blockChance < 0.2)
            {
                return VillainAction.Block;
            }
            else
            {
                return VillainAction.Attack;
            }
        }
    }
}
