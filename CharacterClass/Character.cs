using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBallGame.CharacterClass;
using DragonBallGame.TransformationState;

namespace DragonBallGame.CharacterClass
{
    public abstract class Character
    {
        private string _name;
        private int _power;
        private int _health;
        private int _maxHealth;
        private string _specialAbility;
        private int _transformationLvl;
        private int _maxLevel;
        private string _form;
        private int _energy;
        private const int MAX_ENERGY = 100;
        private ITransformationState _transformationState;
        private bool _isBlocking;

        public Character(string name, int power, int health, string specialAbility)
        {
            Name = name;
            Power = power;
            Health = health;
            _maxHealth = health;
            SpecialAbility = specialAbility;
            TransformationLevel = 0;
            _form = "Base Form";
            _energy = 0;
            _transformationState = new SuperSaiyan1();
            _isBlocking = false; // Initialize as not blocking
        }

        public string Name { get => _name; set => _name = value; }
        public int Power { get => _power; set => _power = value; }
        public int Health { get => _health; set => _health = value; }
        public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public string SpecialAbility { get => _specialAbility; set => _specialAbility = value; }
        public int TransformationLevel { get => _transformationLvl; set => _transformationLvl = value; }
        public virtual int MaxLevel { get; }
        public string Form { get => _form; set => _form = value; }

        public int Energy
        {
            get => _energy;
            set
            {
                if (value > MAX_ENERGY)
                    _energy = MAX_ENERGY;
                else if (value < 0)
                    _energy = 0;
                else
                    _energy = value;
            }
        }

        public bool IsBlocking
        {
            get { return _isBlocking; }
        }

        // Method to start blocking
        public void Block()
        {
            _isBlocking = true;
        }

        // Method to stop blocking
        public void StopBlocking()
        {
            _isBlocking = false;
        }

        public void IncreaseEnergy(int amount) => Energy += amount;

        public void ResetEnergy() => Energy = 0;
        
        public virtual void OnDuplicateRecruited()
        {
            _transformationState.Handle(this);
        }

        public void SetTransformationState(ITransformationState transformationState)
        {
            _transformationState = transformationState;
        }

        public void ResetHealth()
        {
            _health = _maxHealth;
            StopBlocking(); // Ensure blocking is reset when health is reset
        }
    }
}
