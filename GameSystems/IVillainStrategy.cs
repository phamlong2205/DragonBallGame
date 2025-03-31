using DragonBallGame.CharacterClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallGame
{
    public interface IVillainStrategy
    {
        VillainAction ChooseAction(Character villain, Character player);
    }
}
