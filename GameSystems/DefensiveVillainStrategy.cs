using DragonBallGame.CharacterClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallGame
{
    public class DefensiveVillainStrategy : IVillainStrategy
    {
        private Random _random = new Random();

        public VillainAction ChooseAction(Character villain, Character player)
        {
            double blockChance = _random.NextDouble();

            // If villain's health is below 50% and player's health is more than 30%, there's a 70% chance they will block, or simple just 40% of random block
            if ((villain.Health < (villain.MaxHealth * 0.5) && blockChance < 0.7 && player.Health > (player.MaxHealth * 0.3)) || blockChance < 0.4)
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
