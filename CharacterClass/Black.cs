using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallGame.CharacterClass
{
    public class Black : Character
    {
        public Black() : base("Black Goku", 2500, 1500, "Fierce God Slicer") { }

        public override int MaxLevel => 0;
    }
}
