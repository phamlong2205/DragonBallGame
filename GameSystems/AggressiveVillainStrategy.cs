using DragonBallGame.CharacterClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallGame
{
    public class AggressiveVillainStrategy : IVillainStrategy
    {
        private Random _random = new Random();

        public VillainAction ChooseAction(Character villain, Character player)
        {
            double blockChance = _random.NextDouble();

            // If villain's health is below 20% and player's health is more than 20%, there's a 30% chance they will block, or simple just 10% of random block
            if ((villain.Health < (villain.MaxHealth * 0.2) && blockChance < 0.3 && player.Health > (player.MaxHealth * 0.2)) || blockChance < 0.1)
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
