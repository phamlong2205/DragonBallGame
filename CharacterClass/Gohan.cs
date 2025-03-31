using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBallGame.TransformationState;

namespace DragonBallGame.CharacterClass
{
    public class Gohan : Character
    {
        public Gohan() : base("Son Gohan", 1050, 550, "Masenko") 
        {
        }

        public override int MaxLevel => 3;

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
                    SetTransformationState(new Ultimate());
                    break;
                case 3:
                    SetTransformationState(new Beast());
                    break;
                default:
                    break;
            }
        }
    }
}
