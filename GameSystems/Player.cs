using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBallGame.CharacterClass;

namespace DragonBallGame
{
    public class Player
    {
        private int _zeni;
        private List<Character> _recruitedCharacters;

        public Player()
        {
            _zeni = 100; // Initial Zeni
            _recruitedCharacters = new List<Character>();
        }

        public int Zeni
        {
            get { return _zeni; }
        }

        public void AddZeni(int amount)
        {
            _zeni += amount;
        }

        public void DeductZeni(int amount)
        {
            _zeni -= amount;
        }

        public void AddRecruitedCharacter(Character character)
        {
            _recruitedCharacters.Add(character);
        }

        public Character GetRecruitedCharacter(string name)
        {
            return _recruitedCharacters.Find(c => c.Name == name);
        }

        public List<Character> RecruitedCharacters
        {
            get { return _recruitedCharacters; }
        }
    }

}
