using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DragonBallGame.TransformationState;

namespace DragonBallGame.CharacterClass
{
    public class Goku : Character
    {
        public Goku() : base("Son Goku", 950, 500, "Kamehameha") 
        {
        }

        public override int MaxLevel => 5;

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
                    SetTransformationState(new SuperSaiyan3());
                    break;
                case 3:
                    SetTransformationState(new SuperSaiyanGod());
                    break;
                case 4:
                    SetTransformationState(new SuperSaiyanBlue());
                    break;
                case 5:
                    SetTransformationState(new UltraInstinct());
                    break;
                default:
                    break;
            }
        }
    }
}