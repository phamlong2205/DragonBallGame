using DragonBallGame.CharacterClass;
using System;


namespace DragonBallGame
{
    public static class CharacterFactory
    {
        public static Character CreateCharacter(string characterType)
        {
            switch (characterType)
            {
                case "Goku":
                    return new Goku();
                case "Vegeta":
                    return new Vegeta();
                case "Gohan":
                    return new Gohan();
                case "Frieza":
                    return new Frieza();
                case "Cell":
                    return new Cell();
                case "Buu":
                    return new Buu();
                case "Black":
                    return new Black();
                default:
                    throw new ArgumentException("Invalid character type");
            }
        }
    }
}
