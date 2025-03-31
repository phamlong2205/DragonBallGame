using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBallGame.TransformationState;

namespace DragonBallGame.CharacterClass
{
    public class Vegeta : Character
    {
        public Vegeta() : base("Vegeta", 1000, 500, "Galick Gun")
        {
        }

        public override int MaxLevel => 4;

        public override void OnDuplicateRecruited()
        {
            base.OnDuplicateRecruited();

            switch (TransformationLevel)
            {
                case 0:
                    SetTransformationState(new SuperSaiyan1());
                    break;
                case 1:
                    SetTransformationState(new SuperSaiyan2());
                    break;
                case 2:
                    SetTransformationState(new SuperSaiyanGod());
                    break;
                case 3:
                    SetTransformationState(new SuperSaiyanBlue());
                    break;
                case 4:
                    SetTransformationState(new UltraEgo());
                    break;
                default:
                    break;
            }
        }
    }
}
