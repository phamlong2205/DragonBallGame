using DragonBallGame.CharacterClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallGame
{

    public class RecruitResult
    {
        public RecruitStatus Status { get; set; }
        public Character Character { get; set; }
    }

    public enum RecruitStatus
    {
        NotEnoughZeni,
        NoAvailableCharacters,
        NewCharacterRecruited,
        CharacterEvolved
    }
}
