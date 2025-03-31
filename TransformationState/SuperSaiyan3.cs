using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBallGame.CharacterClass;

namespace DragonBallGame.TransformationState
{
    public class SuperSaiyan3 : ITransformationState
    {
        public void Handle(Character character)
        {
            character.Power += 300;
            character.MaxHealth += 200;
            character.Health = character.MaxHealth;
            character.TransformationLevel++;
            character.Form = "Super Saiyan 3";
        }
    }
}

