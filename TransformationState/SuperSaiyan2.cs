using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBallGame.CharacterClass;

namespace DragonBallGame.TransformationState
{
    public class SuperSaiyan2 : ITransformationState
    {
        public void Handle(Character character)
        {
            character.Power += 200;
            character.MaxHealth += 150;
            character.Health = character.MaxHealth;
            character.TransformationLevel++;
            character.Form = "Super Saiyan 2";
        }
    }
}
