using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallGame.CharacterClass
{
    public class Frieza : Character
    {
        public Frieza() : base("Frieza", 1000, 500, "Death Beam") { }

        public override int MaxLevel => 0;
    }
}
