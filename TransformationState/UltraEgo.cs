using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBallGame.CharacterClass;

namespace DragonBallGame.TransformationState
{
    public class UltraEgo : ITransformationState
    {
        public void Handle(Character character)
        {
            character.Power += 1000;
            character.MaxHealth += 400;
            character.Health = character.MaxHealth;
            character.TransformationLevel++;
            character.Form = "Ultra Ego";
        }
    }
}

