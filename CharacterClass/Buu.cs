using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallGame.CharacterClass
{
    public class Buu : Character
    {
        public Buu() : base("Buu", 1800, 1000, "Vanishing Ball") { }

        public override int MaxLevel => 0;
    }
}
