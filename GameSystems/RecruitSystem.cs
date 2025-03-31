using System;
using System.Collections.Generic;
using DragonBallGame.CharacterClass;

namespace DragonBallGame
{
    public class RecruitSystem
    {
        private static RecruitSystem _instance;
        private List<Character> _recruitedCharacters;
        private Random _random;

        private RecruitSystem()
        {
            _recruitedCharacters = new List<Character>();
            _random = new Random();
        }

        public static RecruitSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RecruitSystem();
                }
                return _instance;
            }
        }

        public RecruitResult RecruitRandomCharacter(Player player)
        {
            if (player.Zeni < 100)
            {
                return new RecruitResult
                {
                    Status = RecruitStatus.NotEnoughZeni
                };
            }
            
            List<Character> availableCharacters = GetAvailableCharacters(player);

            if (availableCharacters.Count == 0)
            {
                return new RecruitResult
                {
                    Status = RecruitStatus.NoAvailableCharacters
                };
            }

            player.DeductZeni(100);

            // Select a random character
            int randomIndex = _random.Next(availableCharacters.Count);
            Character randomCharacter = availableCharacters[randomIndex];
            Character existingCharacter = player.GetRecruitedCharacter(randomCharacter.Name);

            if (existingCharacter != null)
            {
                existingCharacter.OnDuplicateRecruited();
                return new RecruitResult
                {
                    Status = RecruitStatus.CharacterEvolved,
                    Character = existingCharacter
                };
            }
            else
            {
                return new RecruitResult
                {
                    Status = RecruitStatus.NewCharacterRecruited,
                    Character = randomCharacter
                };
            }
        }


        private List<Character> GetAvailableCharacters(Player player)
        {
            List<Character> allCharacters = new List<Character>
            {
                new Goku(),
                new Vegeta(),
                new Gohan()
            };

            List<Character> availableCharacters = new List<Character>();

            foreach (Character character in allCharacters)
            {
                Character recruitedCharacter = player.RecruitedCharacters.Find(c => c.Name == character.Name);

                if (recruitedCharacter == null || recruitedCharacter.TransformationLevel <= recruitedCharacter.MaxLevel)
                {
                    availableCharacters.Add(character);
                }
            }

            return availableCharacters;
        }

    }
}