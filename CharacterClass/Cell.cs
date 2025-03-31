using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallGame.CharacterClass
{
    public class Cell : Character
    {
        public Cell() : base("Cell", 1250, 800, "Kamehameha") { }

        public override int MaxLevel => 0;
    }
}
