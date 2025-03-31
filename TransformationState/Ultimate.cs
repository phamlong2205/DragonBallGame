using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBallGame.CharacterClass;

namespace DragonBallGame.TransformationState
{
    public class Ultimate : ITransformationState
    {
        public void Handle(Character character)
        {
            character.Power += 400;
            character.MaxHealth += 300;
            character.Health = character.MaxHealth;
            character.TransformationLevel++;
            character.Form = "Ultimate";
        }
    }
}
